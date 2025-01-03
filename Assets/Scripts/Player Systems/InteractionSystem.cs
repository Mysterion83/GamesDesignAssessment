using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField]
    float MaxInteractionDistance = 5f;
    [SerializeField]
    TextMeshProUGUI TooltipText;

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
            Interactable interaction = hit.collider.gameObject.GetComponent<Interactable>();
            if (interaction == null) return;
            string AdditionalTooltipText = interaction.GetAdditionalToolTip();
            if (AdditionalTooltipText != null)
            {
                TooltipText.text += $"\n{AdditionalTooltipText}";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                interaction.Interact();
            }
        }
        else if (hit.collider.gameObject.tag == "Dial")
        {
            TooltipText.text = "[Mouse Up] Rotate Dial Right\n[Mouse Down] Rotate Dial Left";
            InteractableDial interaction = hit.collider.gameObject.GetComponent<InteractableDial>();
            interaction.Rotate(Input.mouseScrollDelta.y * Time.deltaTime);
        }
    }
}
