using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{

    [SerializeField] GameObject[] FoodPrefab;
    [SerializeField] float SpawnTime = 0.5f;
    [SerializeField] float MinTrans;
    [SerializeField] float MaxTrans;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(FoodSpawn());
    }

    // Update is called once per frame
    IEnumerator FoodSpawn(){
        while(true){
            var wanted = Random.Range(MinTrans, MaxTrans);
            var position = new Vector3(wanted,transform.position.y);
            GameObject gameObject = Instantiate(FoodPrefab[Random.Range(0,FoodPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnTime);
            //Destroy(gameObject, 5f);
        }
    }
    void Update()
    {
        
    }
}
