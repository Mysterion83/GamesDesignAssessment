using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class SCP173AI : MonoBehaviour
{
    GameManager gm;
    CameraObjectDetection CameraObjectDetection;
    public Transform Target;
    Rigidbody rb;
    [SerializeField]
    float KillRange;
    BlinkingSystem PlayerBlinking;
    NavMeshAgent AI;

    // Start is called before the first frame update
    void Start()
    {
        CameraObjectDetection = gameObject.GetComponentInChildren<CameraObjectDetection>();
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerBlinking = GameObject.FindGameObjectWithTag("Player").GetComponent<BlinkingSystem>();
        AI = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CameraObjectDetection.SeenByCamera ^ PlayerBlinking.IsBlinking && PlayerBlinking.InBlinkingArea)
        {
            MoveTowardsPlayer();
            if (CanKillPlayer())
            {
                Debug.Log("Can Kill Player");
                gm.KillPlayer();
            }
        }
        else
        {
            AI.isStopped = true;
            AI.velocity = Vector3.zero;
        }
    }
    bool CanKillPlayer()
    {
        return Vector3.Distance(transform.position, Target.position) < KillRange;
    }
    void MoveTowardsPlayer()
    {
        AI.isStopped = false;
        AI.SetDestination(Target.position); 
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(Target.position.x, transform.position.y, Target.position.z), Speed);
        transform.LookAt(Target.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //rb.AddForce(transform.forward * Speed);
    }
}
