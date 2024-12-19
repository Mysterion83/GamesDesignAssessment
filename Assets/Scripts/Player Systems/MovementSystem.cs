using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovementSystem : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    public bool CanMove = true;
    [SerializeField]
    public bool Freeze = false;
    [SerializeField]
    float MovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanMove)
        {
            Vector3 rawInput = GetRawInput();
            rawInput = rawInput.normalized;
            rawInput *= MovementSpeed;// * Time.deltaTime;
            rb.velocity = new Vector3(rawInput.x, rb.velocity.y, rawInput.z);
        }
        if (Freeze)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    public void UnfreezeRotation()
    {
        rb.freezeRotation = false;
        rb.AddTorque(0, 5, 1);
    }
    Vector3 GetRawInput()
    {
        Vector3 rawInput = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            rawInput += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rawInput += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rawInput += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rawInput += transform.right;
        }
        return rawInput;
    }
}
