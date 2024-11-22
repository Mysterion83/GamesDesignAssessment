using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SCP173AI : MonoBehaviour
{
    CameraObjectDetection CameraObjectDetection;
    public Transform Target;
    Rigidbody rb;
    [SerializeField]
    float Speed;
    [SerializeField]
    float KillRange;
    BlinkingSystem PlayerBlinking;

    // Start is called before the first frame update
    void Start()
    {
        CameraObjectDetection = gameObject.GetComponentInChildren<CameraObjectDetection>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerBlinking = GameObject.FindGameObjectWithTag("Player").GetComponent<BlinkingSystem>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CameraObjectDetection.SeenByCamera ^ PlayerBlinking.IsBlinking)
        {
            MoveTowardsPlayer();
            if (CanKillPlayer())
            {
                Debug.Log("Can Kill Player");
            }
        }
    }
    bool CanKillPlayer()
    {
        return Vector3.Distance(transform.position, Target.position) < KillRange;
    }
    void MoveTowardsPlayer()
    {
        
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, transform.position.y, Target.position.z), Speed);
        transform.LookAt(Target.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        rb.AddForce(transform.forward * Speed);
    }
}
