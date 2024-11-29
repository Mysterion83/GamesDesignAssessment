using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    float MaxInteractionDistance = 5f;
    [SerializeField]
    TextMeshProUGUI TooltipText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TooltipText.text = null;
        Ray InteractionRay = new Ray(transform.position, transform.forward);
        if (!Physics.Raycast(InteractionRay, out RaycastHit hit, MaxInteractionDistance))
        {
            return;
        }
        if (hit.collider.gameObject.tag == "Interactable")
        {
            TooltipText.text = "[E] Interact";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interactable interaction = hit.collider.gameObject.GetComponent<Interactable>();
                interaction.Interact();
            }
        }
        
    }
}
