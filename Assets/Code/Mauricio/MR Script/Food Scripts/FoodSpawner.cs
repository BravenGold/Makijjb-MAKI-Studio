using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{

    private FoodObjectPool objectPool;
    private SteakPool Spool;
    private SaladPool Sapool;

    // Start is called before the first frame update
    void Start(){
        objectPool = FindObjectOfType<FoodObjectPool>();
        Spool = FindObjectOfType<SteakPool>();
        Sapool = FindObjectOfType<SaladPool>();
        
    }

    public void FoodSpawn(){
        GameObject newFood = objectPool.GetFood();
        newFood.transform.position = this.transform.position;
    }

    public void SteakSpawn(){
        GameObject newSteak = Spool.GetSteak();
        newSteak.transform.position = this.transform.position;
    }
    public void SaladSpawn(){
        GameObject newSalad = Sapool.GetSalad();
        newSalad.transform.position = this.transform.position;
    }
}
