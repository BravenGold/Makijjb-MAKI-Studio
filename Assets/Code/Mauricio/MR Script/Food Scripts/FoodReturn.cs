using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class FoodReturn : MonoBehaviour{

    public bool isInRange;
    public KeyCode interactKey;
    //public UnityEvent interactAction;
    private FoodObjectPool objectPool;
    private SteakPool Spool;
    private SaladPool Sapool;
    private Collider2D foodCollision;
    private int foodid = 0;
    // Start is called before the first frame update
    void Start(){
        objectPool = FindAnyObjectByType<FoodObjectPool>();
        Spool = FindAnyObjectByType<SteakPool>();
        Sapool = FindAnyObjectByType<SaladPool>();
    }

    // Update is called once per frame
    void Update(){
        if(isInRange && foodid==1){
            if(Input.GetKeyDown(interactKey)){
                objectPool.ReturnFood(foodCollision.gameObject);
            }
        }else if(isInRange&&foodid==2){
            if(Input.GetKeyDown(interactKey)){
                Spool.ReturnSteak(foodCollision.gameObject);
            }
        }else if(isInRange&&foodid==3){
            if(Input.GetKeyDown(interactKey)){
                Sapool.ReturnSalad(foodCollision.gameObject);
            }
        }else if(isInRange&&foodid==4){
            Debug.Log("Chicken Holder");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Food")){
            isInRange = true;
            foodCollision = collision;
            foodid = 1;
            Debug.Log("Food is now in range");
        }else if(collision.gameObject.CompareTag("Steak")){
            isInRange = true;
            foodCollision = collision;
            foodid=2;
            Debug.Log("Steak is now in range");
        }else if(collision.gameObject.CompareTag("Salad")){
            isInRange = true;
            foodid=3;
            foodCollision = collision;
            Debug.Log("Salad is now in range");
        }else if(collision.gameObject.CompareTag("Chicken")){
            isInRange = true;
            foodCollision = collision;
            foodid=4;
            Debug.Log("Chicken is now in range");
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Food")){
            isInRange = false;
            foodid=0;
            Debug.Log("Food is now out of range");
        }else if(collision.gameObject.CompareTag("Steak")){
            isInRange = false;
            foodCollision = collision;
            foodid=0;
            Debug.Log("Steak is now in range");
        }else if(collision.gameObject.CompareTag("Salad")){
            isInRange = false;
            foodid=0;
            foodCollision = collision;
            Debug.Log("Salad is now out of range");
        }else if(collision.gameObject.CompareTag("Chicken")){
            isInRange = false;
            foodCollision = collision;
            foodid=0;
            Debug.Log("Chicken is out of range");
        }
    }
}

