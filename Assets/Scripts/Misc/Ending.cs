using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    float Timer;
    [SerializeField]
    InteractableAnimationObject Door;
    // Start is called before the first frame update
    void Start()
    {
        Door.Interact();
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer += Time.deltaTime;
    }
}
