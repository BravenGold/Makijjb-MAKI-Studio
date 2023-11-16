  /********************************
  * SaladPool.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This is where the magic happens for the object pool. This creates the 
  * object pool and handles it functionality.
  ********************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladPool : MonoBehaviour
{
    private static SaladPool instance;
    private static readonly object lockObject = new object();
    [SerializeField]public GameObject Saladprefab;
    [SerializeField]private Queue<GameObject> SaladobjPool = new Queue<GameObject>();
    [SerializeField]private int poolstarting = 10;
    public int count = 0; 

    private void Awake() {
        lock (lockObject) {
            if (instance == null) {
                instance = this;
            } else {
                Destroy(this.gameObject);
            }
        }
    }
    //Handles the "spawing" of the salad prefab. 
    private void Start(){
        for(int i=0;i<poolstarting;i++){
            GameObject Food = Instantiate(Saladprefab);
            Food foodComponent = Food.GetComponent<Salad>();
            foodComponent.Cookable();
            foodComponent.Timer();
            foodComponent.PointAllocation();

            SaladobjPool.Enqueue(Food);
            Food.SetActive(false);
        }
    }
    //Handles the fetching of the salad prefab. 
    public GameObject GetSalad(){
        if(SaladobjPool.Count > 0){
                GameObject Food = SaladobjPool.Dequeue();
                Food.SetActive(true);
                count++;
                return Food;
        }else{
            return null;
        }
    }
    //This returns the salad prefab to the queue
    public void ReturnSalad(GameObject Food){
        SaladobjPool.Enqueue(Food);
        Food.SetActive(false);
        count--;
    }
    //This method keeps track of how many food items are out of the queue
    public int Foodcount(){
        return count;
    }
    //This refers to the instance of the objectpool 
    public static SaladPool GetInstance(){
        return instance;
    }
}
