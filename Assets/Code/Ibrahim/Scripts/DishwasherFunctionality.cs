using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherFunctionality : MonoBehaviour
{
    int platesAdded = 0, clicks = 0;
    public bool AddOrRemovePlates;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //AddOrRemovePlates = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 1.5)
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
        else
        {
            Debug.Log("not close enough to interact");
        }
    }

}

