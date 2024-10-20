using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SCP173AI : MonoBehaviour
{
    CameraObjectDetection CameraObjectDetection;
    public Transform Target;
    [SerializeField]
    float Speed;

    // Start is called before the first frame update
    void Start()
    {
        CameraObjectDetection = gameObject.GetComponentInChildren<CameraObjectDetection>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CameraObjectDetection.SeenByCamera)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, transform.position.y, Target.position.z), Speed * Time.deltaTime);
            transform.LookAt(Target.position);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
    }
}
