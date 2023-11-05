using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FoodReturn : MonoBehaviour{

    public bool isInRange;
    public KeyCode interactKey;
    //public UnityEvent interactAction;
    private FoodObjectPool objectPool;
    private Collider2D foodCollision;
    // Start is called before the first frame update
    void Start(){
        objectPool = FindAnyObjectByType<FoodObjectPool>();
    }

    // Update is called once per frame
    void Update(){
        if(isInRange){
            if(Input.GetKeyDown(interactKey)){
                Debug.Log("test");
                objectPool.ReturnFood(foodCollision.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Food")){
            isInRange = true;
            foodCollision = collision;
            Debug.Log("Food is now in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Food")){
            isInRange = false;
            Debug.Log("Food is now out of range");
        }        
    }
}

