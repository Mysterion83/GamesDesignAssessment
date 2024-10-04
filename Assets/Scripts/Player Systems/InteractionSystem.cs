using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    float MaxInteractionDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Ray InteractionRay = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(InteractionRay,out RaycastHit hit, MaxInteractionDistance))
            {
                if (hit.collider.gameObject.tag == "Interactable")
                {
                    Interactable interaction = hit.collider.gameObject.GetComponent<Interactable>();
                    interaction.Interact();
                }
            }
        }
    }
}
