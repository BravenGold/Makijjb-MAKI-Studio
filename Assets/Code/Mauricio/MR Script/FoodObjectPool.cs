using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FoodObjectPool : MonoBehaviour{

    [SerializeField]private GameObject Foodprefab;
    [SerializeField]private Queue<GameObject> FoodPool = new Queue<GameObject>();
    [SerializeField]private int poolstarting = 30;

    private void Start(){
        for(int i=0;i<poolstarting;i++){
            GameObject Food = Instantiate(Foodprefab);
            FoodPool.Enqueue(Food);
            Food.SetActive(false);
        }
    }

    public GameObject GetFood(){
        if(FoodPool.Count > 0){
                GameObject Food = FoodPool.Dequeue();
                Food.SetActive(true);
                return Food;
        }
        return null;
    }

    public void ReturnFood(GameObject Food){
        FoodPool.Enqueue(Food);
        Food.SetActive(false);
    }
}
