using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour{
    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] float MinTrans;
    [SerializeField] float MaxTrans;
    private int itemsSpawned = 0; // Counter for spawned items
    private int maxItemsToSpawn = 30; // Maximum items to spawn

    // Start is called before the first frame update
    void Start(){
        FoodSpawn();
    }

    public void FoodSpawn(){
        while(itemsSpawned < maxItemsToSpawn){
            var wanted = Random.Range(MinTrans, MaxTrans);
            var position = transform.position + new Vector3(0, 1, 0);
            bool canSpawn = Physics2D.OverlapCircle(position, 0.5f) == null;
            GameObject gameObject = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], position, Quaternion.identity);
            itemsSpawned++;
        }
    }

    public float valuereturn(){
        return maxItemsToSpawn;
    }
}
