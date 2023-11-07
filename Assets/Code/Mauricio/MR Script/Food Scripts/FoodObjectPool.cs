using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FoodObjectPool : MonoBehaviour{

    [SerializeField]public GameObject Foodprefab;
    [SerializeField]private Queue<GameObject> FoodPool = new Queue<GameObject>();
    [SerializeField]private int poolstarting = 30;
    public int count = 0; 

    private void Start(){
        for(int i=0;i<poolstarting;i++){
            GameObject Food = Instantiate(Foodprefab);
            Food foodComponent = Food.GetComponent<Food>();
            foodComponent.Cookable();
            foodComponent.Timer();
            foodComponent.PointAllocation();

            FoodPool.Enqueue(Food);
            Food.SetActive(false);
        }
    }

    public GameObject GetFood(){
        if(FoodPool.Count > 0){
                GameObject Food = FoodPool.Dequeue();
                Food.SetActive(true);
                count++;
                return Food;
        }else{
            return null;
        }
    }

    public void ReturnFood(GameObject Food){
        FoodPool.Enqueue(Food);
        Food.SetActive(false);
        count--;
    }
    public int Foodcount(){
        return count;
    }
}
