using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

    // Framework code for object pools

    //Get an object from the queue
    public GameObject GetObject(GameObject gameObject)
    {
        // Check if the requested object is here
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            // If the list is empty, create an object
            if (objectList.Count == 0)
                return CreateNewObject(gameObject);
            else
            {
                // If the requested object is here, set active and return it
                GameObject _object = objectList.Dequeue();
                _object.SetActive(true);
                return _object;
            }
        }
        else
            return CreateNewObject(gameObject);
    }

    // Creating a new object
    private GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject newGO = Instantiate(gameObject);
        newGO.name = gameObject.name;
        return newGO;
    }

    // Returning a game object back to the pool / queue after use
    public void ReturnGameObject(GameObject gameObject)
    {
        if (objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(gameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(gameObject);
            objectPool.Add(gameObject.name, newObjectQueue);
        }

        gameObject.SetActive(false);
    }
}
