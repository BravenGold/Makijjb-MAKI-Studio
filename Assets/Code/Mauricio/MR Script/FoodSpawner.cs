using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{

    private FoodObjectPool objectPool;

    // Start is called before the first frame update
    void Start(){
        objectPool = FindObjectOfType<FoodObjectPool>();
    }

    public void FoodSpawn(){
        GameObject newFood = objectPool.GetFood();
        newFood.transform.position = this.transform.position;
    }

}
