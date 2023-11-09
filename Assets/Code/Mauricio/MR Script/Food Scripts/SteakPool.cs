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
            Steak foodComponent = Food.GetComponent<Steak>();
            foodComponent.Cookable();
            foodComponent.Timer();
            foodComponent.PointAllocation();

            SteakobjPool.Enqueue(Food);
            Food.SetActive(false);
        }
    }

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

    public void ReturnSteak(GameObject Food){
        SteakobjPool.Enqueue(Food);
        Food.SetActive(false);
        count--;
    }
    public int Foodcount(){
        return count;
    }

    public static SteakPool GetInstance(){
        return instance;
    }
}
