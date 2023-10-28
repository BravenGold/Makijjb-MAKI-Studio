using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnable : MonoBehaviour{

    public InCollider Food; 
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Food")){
            Food.ChangeSign(true);
            Debug.Log("Food is in the box");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Food")){
            Food.ChangeSign(false);
            Debug.Log("Food is out of the box");
        }        
    }
}
