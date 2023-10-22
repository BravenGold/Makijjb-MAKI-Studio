using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{

    [SerializeField] GameObject[] FoodPrefab;
    [SerializeField] float SpawnTime = 0.5f;
    [SerializeField] float MinTrans;
    [SerializeField] float MaxTrans;
    private int itemsSpawned = 0; // Counter for spawned items
    private int maxItemsToSpawn = 3; // Maximum items to spawn

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(FoodSpawn());
    }

    // Update is called once per frame
    public IEnumerator FoodSpawn(){
    while (itemsSpawned < maxItemsToSpawn)
    {
        var wanted = Random.Range(MinTrans, MaxTrans);
        var position = transform.position - new Vector3(wanted, 1, 0);

        // Use Physics2D.OverlapCircle to check for colliders on the "Food" layer
        bool canSpawn = Physics2D.OverlapCircle(position, 0.5f) == null;
        
        if (canSpawn){
            GameObject gameObject = Instantiate(FoodPrefab[Random.Range(0, FoodPrefab.Length)], position, Quaternion.identity);
            itemsSpawned++; // Increment the counter for spawned items
        }

        yield return new WaitForSeconds(SpawnTime);
    }
    }

    public float valuereturn(){
        return maxItemsToSpawn;
    }
}
