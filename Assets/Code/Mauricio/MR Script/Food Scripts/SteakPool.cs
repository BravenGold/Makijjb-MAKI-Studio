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

public class SteakPool : MonoBehaviour
{
    private static SteakPool instance;
    private static readonly object lockobject = new object();
    [SerializeField]public GameObject Steakprefab;
    [SerializeField]private Queue<GameObject> SteakobjPool = new Queue<GameObject>();
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

    private void Start(){
        for(int i=0;i<poolstarting;i++){
            GameObject Food = Instantiate(Steakprefab);
            Food foodComponent = Food.GetComponent<Steak>();
            foodComponent.Cookable();
            foodComponent.Timer();
            foodComponent.PointAllocation();

            SteakobjPool.Enqueue(Food);
            Food.SetActive(false);
        }
    }

    //Handles the "spawing" of the steak prefab. 
    public GameObject GetSteak(){
        if(SteakobjPool.Count > 0){
                GameObject Food = SteakobjPool.Dequeue();
                Food.SetActive(true);
                count++;
                return Food;
        }else{
            return null;
        }
    }

    //This brings the steak bask to the queue. 
    public void ReturnSteak(GameObject Food){
        SteakobjPool.Enqueue(Food);
        Food.SetActive(false);
        count--;
    }
    //Counts the amount of food objects in existence.
    public int Foodcount(){
        return count;
    }
    //A refrence of the Steakpool method can be done using this method
    public static SteakPool GetInstance(){
        return instance;
    }
}
/*

Intent
Object pooling can offer a significant performance boost; 
it is most effective in situations where the cost of initializing a class instance is high, 
the rate of instantiation of a class is high, 
and the number of instantiations in use at any one time is low.
------------------------------------------------------------------------------------------
Problem
Object pools (otherwise known as resource pools) are used to manage the object caching. 
A client with access to a Object pool can avoid creating a new Objects by simply asking 
the pool for one that has already been instantiated instead. 
Generally the pool will be a growing pool, i.e. the pool itself will create new objects if 
the pool is empty, or we can have a pool, which restricts the number of objects created.

It is desirable to keep all Reusable objects that are not currently in use in the same object 
pool so that they can be managed by one coherent policy. To achieve this, the Reusable Pool 
class is designed to be a singleton class.
------------------------------------------------------------------------------------------

Structure           
    ReusablePool.getinstance()acquareReusable() --------------------------------------
Client ---------------------------------------->|           Reusable pool            | 
                                                |------------------------------------|
                                                |-reusables                          |
                                                |------------------------------------|
                                                |+statice getInstance():ReusuablePool|
                                                |+acquireReusable(): Reusable        |
                                                |+releaseReusable(in a :Reusable)    |
                                                |+setMaxPoolSize(inSize)             |
                                                -------------------------------------|
------------------------------------------------------------------------------------------

Would something else have worked as well or better than this pattern? When would be a bad time to use this pattern?
--It'd be anytime where things aren't created and destroyed rapidly. For example if we use the object pool to create a level's
structure. And the structure is not destroyed then it'd be useless because we'd just be spawning something and not needing
to destroy it. 


*/