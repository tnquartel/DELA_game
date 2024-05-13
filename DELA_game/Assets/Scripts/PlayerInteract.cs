using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteract : MonoBehaviour
{
    private bool isInteracting;
    public UnityEvent interactEvent;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach(Collider collider in colliderArray)
            {
                if(collider.TryGetComponent(out NPCInteractable npcInteractable)){
                    isInteracting = true;
                    interactEvent.Invoke();
                    npcInteractable.Interact(collider.gameObject);
                }
            }
        }else if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            isInteracting = false;
            interactEvent.Invoke();
        }
    }

    public NPCInteractable GetInteractable()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach(Collider collider in colliderArray)
        {
            if(collider.TryGetComponent(out NPCInteractable npcInteractable)){
                return npcInteractable;
            }
        }

        return null;
    }

    public bool getIsInteracting(){
        return isInteracting;       
    }
}
