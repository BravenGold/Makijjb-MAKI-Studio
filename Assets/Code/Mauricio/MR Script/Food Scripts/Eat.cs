using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    //public UnityEvent interactAction;
    private FoodObjectPool objectPool;
    private SteakPool Spool;
    private SaladPool Sapool;
    private ChickenPool CPool;
    private Collider2D foodCollision;
    private int foodid = 0;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start(){
        objectPool = FindAnyObjectByType<FoodObjectPool>();
        Spool = FindAnyObjectByType<SteakPool>();
        Sapool = FindAnyObjectByType<SaladPool>();
        CPool = FindAnyObjectByType<ChickenPool>();
    }

    // Update is called once per frame
    void Update(){
        if(isInRange && foodid==1){
            if(Input.GetKeyDown(interactKey)){
                objectPool.ReturnFood(foodCollision.gameObject);
            }
        }
        
        else if(isInRange&&foodid==2){
            if(Input.GetKeyDown(interactKey)){
                Steak SteakComponent = foodCollision.GetComponent<Steak>();
                if(SteakComponent.cooked==true){
                    SteakComponent.StopCookingAnimation();
                    SteakComponent.cooked=false;
                    gameManager.AddScore(SteakComponent.points);
                    Spool.ReturnSteak(foodCollision.gameObject);
                }else{
                    Debug.Log("Cannot Eat Raw Food");
                }
            }
        }
        
        else if(isInRange&&foodid==3){
            if(Input.GetKeyDown(interactKey)){
                Salad SaladComponent = foodCollision.GetComponent<Salad>();
                gameManager.AddScore(SaladComponent.points);
                Sapool.ReturnSalad(foodCollision.gameObject);
            }
        }
        
        else if(isInRange&&foodid==4){
                if(Input.GetKeyDown(interactKey)){
                Chicken ChickenComponent = foodCollision.GetComponent<Chicken>();
                if(ChickenComponent.cooked==true){
                    ChickenComponent.StopCookingAnimation();
                    ChickenComponent.cooked=false;
                    gameManager.AddScore(ChickenComponent.points);
                    Spool.ReturnSteak(foodCollision.gameObject);
                }else{
                    Debug.Log("Cannot Eat Raw Food");
                }
            }
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
