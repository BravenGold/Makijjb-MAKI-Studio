using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherFunctionality : MonoBehaviour
{
    int platesAdded = 0, clicks = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (platesAdded < 5)
        {
            platesAdded++;
            clicks++;
            Debug.Log("Plates: " + platesAdded);
        }
        else if (clicks == 6)
        {
            platesAdded = 0;
            Debug.Log("Plates: " + platesAdded);
            clicks = 0;
        }
        else if (platesAdded < 0)
        {
            platesAdded = 0;
            clicks = 0;
        }
        else
        {
            Debug.Log("Dishwasher is full click to empty");
            clicks++;
        }
    }
}
