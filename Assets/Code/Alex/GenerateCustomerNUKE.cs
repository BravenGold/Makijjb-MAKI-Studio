using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCustomerNUKE : MonoBehaviour
{

    [SerializeField]
    private GameObject CustomerPrefab;

    [SerializeField]
    private float SpawnInterval = 0.001f;

    //private float MaxCustomers = 5f;
    //private float CurrentCustomers = 0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCustomer(SpawnInterval, CustomerPrefab));
    }
    private IEnumerator SpawnCustomer(float interval, GameObject customer)
    {
        yield return new WaitForSeconds(interval);
        GameObject NewCustomer = Instantiate(customer, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f), 0), Quaternion.identity);
        //CurrentCustomers++;
        //if (CurrentCustomers < MaxCustomers)
        //{
            StartCoroutine(SpawnCustomer(interval, customer));
        //}
    }
}
