  /********************************
  * Interactbuttons.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This script dictates whether the menu is 
  * open or is closed. 
  * 
  *  
  ********************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactbutton : MonoBehaviour{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public GameObject text;
    void Start()
    {
        
    }

    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                text.SetActive(false);
                interactAction.Invoke();
            }
        }
    }
    //This method uses a 2D collider to allow a player to do something in range
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isInRange = true;
            text.SetActive(true);
            Debug.Log("Player is now in range");
        }
    }
    //This method tells whether something leave the range. 
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isInRange = false;
            text.SetActive(false);
            Debug.Log("Player is now out of range");
        }        
    }

}
