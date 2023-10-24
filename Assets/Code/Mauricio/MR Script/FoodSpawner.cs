using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{

    [SerializeField] GameObject[] foodPrefabs;
    [SerializeField] float SpawnTime = 0.5f;
    [SerializeField] float MinTrans;
    [SerializeField] float MaxTrans;
    private int itemsSpawned = 0; // Counter for spawned items
    private int maxItemsToSpawn = 3; // Maximum items to spawn

    // Start is called before the first frame update
    void Start(){
        //StartCoroutine(FoodSpawn());
    }

    // Update is called once per frame
    public void FoodSpawn(){
        if(itemsSpawned < maxItemsToSpawn){
            var wanted = Random.Range(MinTrans, MaxTrans);
            var position = transform.position - new Vector3(wanted, 1, 0);

            // Use Physics2D.OverlapCircle to check for colliders on the "Food" layer
            bool canSpawn = Physics2D.OverlapCircle(position, 0.5f) == null;

            if (canSpawn && foodPrefabs.Length > 0){
                GameObject gameObject = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], position, Quaternion.identity);
                itemsSpawned++;
            }
        }
    }

    public float valuereturn(){
        return maxItemsToSpawn;
    }
}
