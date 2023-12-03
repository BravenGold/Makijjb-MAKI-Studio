  /********************************
  * SteakPool.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This is where the magic happens for the object pool. This creates the 
  * object pool and handles it functionality.
  ********************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenPool : MonoBehaviour
{
    private static ChickenPool instance;
    private static readonly object lockobject = new object();
    [SerializeField]public GameObject Chickenprefab;
    [SerializeField]private Queue<GameObject> chickenobjPool = new Queue<GameObject>();
    [SerializeField]private int poolstarting = 10;
    public int count = 0; 

    private void Awake(){
        lock(lockobject){
            if(instance==null){
                instance=this;
            }else{
                Destroy(this.gameObject);
            }
        }
    }

    //Handles the "spawing" of the chicken prefab. 
    private void Start(){
        for(int i=0;i<poolstarting;i++){
            GameObject Food = Instantiate(Chickenprefab);
            Food foodComponent = Food.GetComponent<Chicken>();
            foodComponent.Cookable();
            foodComponent.Timer();
            foodComponent.PointAllocation();

            chickenobjPool.Enqueue(Food);
            Food.SetActive(false);
        }
    }
    //Handles the fetching of the chicken prefab. 
    public GameObject GetChicken(){
        if(chickenobjPool.Count > 0){
                GameObject Food = chickenobjPool.Dequeue();
                Food.SetActive(true);
                count++;
                return Food;
        }else{
            return null;
        }
    }
    //This returns the chicken prefab to the queue
    public void ReturnChicken(GameObject Food){
        chickenobjPool.Enqueue(Food);
        Food.SetActive(false);
        count--;
    }
    //This method keeps track of how many food items are out of the queue
    public int Foodcount(){
        return count;
    }

    //This refers to the instance of the objectpool 
    public static ChickenPool GetInstance(){
        return instance;
    }
}
