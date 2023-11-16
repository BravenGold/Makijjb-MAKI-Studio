using System.Collections.Generic;
using UnityEngine;

// Customer object pool implementation
public class CustomerObjectPool : MonoBehaviour
{
    // Store the customer objects in a list of game objects.
    public List<GameObject> gameObjectList;

    // Start to initialize the pool
    void Start()
    {
        InitializePool();
    }

    // Since the customers already exist in the scene, they are simply added to the list and set inactive
    void InitializePool()
    {
        foreach (GameObject obj in gameObjectList)
        {
            obj.SetActive(false);
        }
    }

    // This function grabs an object from the list, removes it, and returns the object to the caller
    // In this case, PathingV2 calls this function to initialize the customers it controls
    public GameObject GetCustomerFromPool()
    {
        foreach (GameObject obj in gameObjectList)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        Debug.LogWarning("CustomerObject pool is empty.");
        return null;
    }

    // Function to return an object to the ppol
    public void ReturnCustomerToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
