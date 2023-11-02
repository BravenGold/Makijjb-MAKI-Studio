using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFoodSpawner : MonoBehaviour{

    [SerializeField] GameObject[] FoodPrefab;
    //[SerializeField] float SpawnTime = 0.001f;
    [SerializeField] float MinTrans;
    [SerializeField] float MaxTrans;
    private float amount = 9999999999999990999;
    float a = 0; 
    public int tracker = 0;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(FoodSpawn());
    }

    // Update is called once per frame
    IEnumerator FoodSpawn(){
        while(a<(amount+amount)){
            var wanted = Random.Range(MinTrans, MaxTrans);
            //var position = new Vector3(wanted,transform.position.y);
            var position = transform.position - new Vector3(wanted,1,0);
            GameObject gameObject = Instantiate(FoodPrefab[Random.Range(0,FoodPrefab.Length)], position, Quaternion.identity);
            tracker++;
            //Debug.Log(tracker);
            yield return 0;
            a++;
        }
    }
}