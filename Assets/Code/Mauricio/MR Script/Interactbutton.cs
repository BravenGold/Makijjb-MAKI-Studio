using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactbutton : MonoBehaviour{

    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                text.SetActive(false);
                interactAction.Invoke();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isInRange = true;
            text.SetActive(true);
            Debug.Log("Player is now in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            isInRange = false;
            text.SetActive(false);
            Debug.Log("Player is now out of range");
        }        
    }

}
