using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]
    float Sensitivity = 100f;

    [SerializeField]
    Transform ParentRotation;

    Vector3 PlayerMouseInput;
    Vector3 CameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        CameraRotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        CameraUpdate();
    }
    void CameraUpdate()
    {
        PlayerMouseInput = new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensitivity, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensitivity, 0);
        CameraRotation.x -= PlayerMouseInput.y;
        CameraRotation.y += PlayerMouseInput.x;

        CameraRotation.x = Mathf.Clamp(CameraRotation.x, -90f, 90f);

        transform.rotation = Quaternion.Euler(CameraRotation);
        ParentRotation.rotation = Quaternion.Euler(0, CameraRotation.y, 0);
    }
}
