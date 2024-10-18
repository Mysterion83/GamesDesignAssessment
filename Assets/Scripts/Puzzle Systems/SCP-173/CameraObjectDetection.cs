using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObjectDetection : MonoBehaviour
{
    Camera Camera;
    MeshRenderer Renderer;
    Plane[] CameraFrustum;
    Bounds Bounds;
    [SerializeField]
    public bool SeenByCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        Camera = Camera.main;
        Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraFrustum = GeometryUtility.CalculateFrustumPlanes(Camera);
        if (GeometryUtility.TestPlanesAABB(CameraFrustum, Bounds))
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
