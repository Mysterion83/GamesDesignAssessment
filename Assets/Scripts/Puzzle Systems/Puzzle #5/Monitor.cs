using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{
    GameManager gm;
    GameObject PlayerCam;
    [SerializeField]
    public GameObject InteractCollider;
    Desktop Desktop;
    // Start is called before the first frame update
    private void Start()
    {
        Desktop = gameObject.GetComponentInChildren<Desktop>();
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void MonitorInteract()
    {
        Debug.Log("Interacted With Monitor Class");
        InteractCollider.SetActive(false);
        gm.FreezePlayer();
        MovePlayerCamera();
    }
    public void MonitorQuit()
    {
        //InteractCollider.SetActive(true);
        Desktop.UpdateCurrentApp(0);
        ResetPlayerCamera();
        gm.UnFreezePlayer();
    }

    void MovePlayerCamera()
    {
        PlayerCam = GameObject.FindGameObjectWithTag("MainCamera");
        PlayerCam.transform.position = gameObject.transform.position - new Vector3(-1.5f,0,0);
        PlayerCam.transform.rotation = Quaternion.Euler(0,-90,0);
    }
    void ResetPlayerCamera()
    {
        PlayerCam.transform.localPosition = new Vector3(0, 0.5f, 0);
    }
}
