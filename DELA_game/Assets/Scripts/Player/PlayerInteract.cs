using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    private float interactRange = 2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    npcInteractable.Interact(collider.gameObject);
                }
            }
        }
    }

    public NPCInteractable GetInteractable()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach(Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPCInteractable npcInteractable)){
                return npcInteractable;
            }
        }

        return null;
    }
}
