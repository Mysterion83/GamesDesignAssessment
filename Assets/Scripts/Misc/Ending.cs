using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    float Timer;
    [SerializeField]
    InteractableAnimationObject Door;
    [SerializeField]
    AudioController AC;
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
    void PlayGunCock()
    {
        AC.Play(0, 1, 1);
    }
    void PlayGunShot()
    {
        AC.Play(1, 1, 1);
    }
}
