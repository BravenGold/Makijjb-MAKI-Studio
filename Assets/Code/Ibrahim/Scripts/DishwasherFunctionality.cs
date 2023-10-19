using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherFunctionality : MonoBehaviour
{
    int platesAdded = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("dishwasher hit");
        if (platesAdded < 5)
        {
            platesAdded++;
            Debug.Log(platesAdded);
        }
        else
        {
            Debug.Log("Dishwasher is full");
        }
    }
}
