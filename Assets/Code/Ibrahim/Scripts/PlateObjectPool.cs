using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject PlatePrefab;
    [SerializeField]
    private Queue<GameObject> PlatePool = new Queue<GameObject>();
    [SerializeField]
    private int InitialPoolSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < InitialPoolSize; i++)
        {
            GameObject Plate = Instantiate(PlatePrefab);
            PlatePool.Enqueue(Plate);
            Plate.SetActive(false);
        }
    }

    //GetPlate is called when we want a plate from the object pool
    public GameObject GetPlate()
    {
        if(PlatePool.Count > 0)
        {
            GameObject Plate = PlatePool.Dequeue();
            Plate.SetActive(true);
            return Plate;
        }
        else
        {
            Debug.Log("Error: Should not be trying to access more than 5 plates. This error was generated from GetPlate method.");
            return null;
        }
    }

    //ReturnPlate is called by the Plate object to return the Plate to the object pool
    public void ReturnPlate(GameObject Plate)
    {
        PlatePool.Enqueue(Plate);
        Plate.SetActive(false);
    }
}
