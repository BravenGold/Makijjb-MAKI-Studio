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

    public void ReturnChicken(GameObject Food){
        chickenobjPool.Enqueue(Food);
        Food.SetActive(false);
        count--;
    }
    public int Foodcount(){
        return count;
    }

    public static ChickenPool GetInstance(){
        return instance;
    }
}
