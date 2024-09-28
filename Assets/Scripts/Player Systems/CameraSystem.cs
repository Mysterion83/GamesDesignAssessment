using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]
    bool CanMove = true;
    [SerializeField]
    float Sensitivity = 100f;

    //Stores the current transform of the parent object
    [SerializeField]
    Transform ParentRotation;

    //storing mouse input
    Vector3 PlayerMouseInput;

    //storing camera rotation
    Vector3 CameraRotation;
    // Start is called before the first frame update
    void Start()
    {
        CameraRotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove) CameraUpdate();
    }
    void CameraUpdate()
    {
        //gets the mouse input
        PlayerMouseInput = new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * Sensitivity, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Sensitivity, 0);
        //gets the camera x rotation
        CameraRotation.x -= PlayerMouseInput.y;
        //gets the camera y rotation
        CameraRotation.y += PlayerMouseInput.x;

        //Clamps vertical rotation to prevent upside-down camera
        CameraRotation.x = Mathf.Clamp(CameraRotation.x, -90f, 90f);

        //Rotates Camera
        transform.rotation = Quaternion.Euler(CameraRotation);
        //Rotates Parent Object (player object)
        ParentRotation.rotation = Quaternion.Euler(0, CameraRotation.y, 0);
    }
}
