using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherFunctionality : MonoBehaviour
{
    int platesAdded = 0, clicks = 0;
    float xcoord = -0.12f, ycoord = 0.7f;
    public GameObject Player;
    public PlateObjectPool POP;
    private GameObject[] newPlate = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        POP = FindObjectOfType<PlateObjectPool>();
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
                newPlate[platesAdded] = POP.GetPlate();
                newPlate[platesAdded].transform.position = transform.position + new Vector3(xcoord,ycoord);
                platesAdded++;
                clicks++;
                xcoord += .03f;
                ycoord -= .04f;
            }
            else if (platesAdded < 0)
            {
                platesAdded = 0;
                clicks = 0;
            }
            else
            {
                Debug.Log("Dishwasher is full click to empty");
                platesAdded = 0;
                clicks = 0;
                for (int i = 0; i < 5; i++)
                {
                    POP.ReturnPlate(newPlate[i]);
                }
                xcoord = -0.12f;
                ycoord = 0.7f;
            }
        }
        else
        {
            Debug.Log("not close enough to interact");
        }
    }

}

