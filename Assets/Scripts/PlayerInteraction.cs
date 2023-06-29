using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;
    public float interactionDistance = 2f;

    public GameObject interactionObject;
    public TextMeshProUGUI interactionText;
    public bool canDrop;

    void Update()
    {
        InteractionRay();
    }
    
    void InteractionRay()
    {
        Ray ray = cam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                hitSomething = true;
                interactionText.text = interactable.GetDiscription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    canDrop = true;
                    hit.collider.GetComponent<Gun>().taken(cam);
                    interactable.Interact();
                }

                
            }
        }
        interactionObject.SetActive(hitSomething);
    }
}
