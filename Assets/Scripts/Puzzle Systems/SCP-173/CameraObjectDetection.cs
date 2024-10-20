using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectDetection : MonoBehaviour
{
    Camera Camera;
    [SerializeField]
    public bool SeenByCamera = false;
    [SerializeField]
    public float DetectionRange = 50f;
    [SerializeField]
    public float ViewLeniency = .65f;
    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!(Vector3.Dot(Camera.transform.forward, (gameObject.transform.position - Camera.transform.position).normalized) < ViewLeniency) && Physics.Raycast(Camera.transform.position,(gameObject.transform.position - Camera.transform.position).normalized,out RaycastHit hitInfo, DetectionRange) && hitInfo.transform.name == this.name)
        {
            SeenByCamera = true;
            Debug.Log(SeenByCamera);
        }
        else
        {
            SeenByCamera = false;
            Debug.Log(SeenByCamera);
        }
    }
}
