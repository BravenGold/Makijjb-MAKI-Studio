using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable{
    public void Interact();
}

public class Interactable : MonoBehaviour{
    public Transform InteracterSource;
    public float InteractRange;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            Ray r = new Ray(InteracterSource.position, InteracterSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) { 
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj)){
                    interactObj.Interact();
                }
            }
        }
    }
}
