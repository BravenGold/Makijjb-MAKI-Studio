using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MouseClickMovement : MonoBehaviour
{
    public bool moving { get; private set; }
    public float speed = 2.0f;

    float step;
    Vector2 destination;    
    float distance;

    public List<GameObject> waypoints;

    public Vector2 lastClickedPos { get; private set; }



    //New Var For Animation
    private Animator anim;
    public int action = 0;

    //Way Point
    int index=0;
    int currentIndex;

    int startIndex1 = 0;
    int endIndex1 = 2;

    int startIndex2 = 3;
    int endIndex2 = 4;

    int startIndex3 = 5;
    int endIndex3 = 7;

    int startIndex4 = 5;
    int endIndex4 = 9;
     
   
    int kitchenIndex1=0;
    int washAreaIndex1 = 11;
    int fridgeIndex1 =13;
    

    public int t;
    public int kit=0;
    public int wa;
    public int f;

    public GameObject table1;
    public GameObject table2;
    public GameObject table3;
    public GameObject table4;
    public GameObject kitchen;
    private GameObject selectedGameObject = null;

    private void Awake()
    {
       
        //Grab references for animator from object
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Table1"))
            {
                t = 1;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);                

            }
            else if (hit.collider != null && hit.collider.CompareTag("Table2"))
            {
                t = 2;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);                

            }
            else if (hit.collider != null && hit.collider.CompareTag("Table3"))
            {
                t = 3;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);
                
            }
            else if (hit.collider != null && hit.collider.CompareTag("Table4"))
            {
                t = 4;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);
 
            }
            else if (hit.collider != null && hit.collider.CompareTag("Kitchen"))
            {
                t = 5;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);
                          
            }
            else if (hit.collider != null && hit.collider.CompareTag("WashArea"))
            {
                t = 6;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);

            }
            else if (hit.collider != null && hit.collider.CompareTag("Fridge"))
            {
                t = 7;
                selectedGameObject = hit.collider.gameObject;
                UnityEngine.Debug.Log(selectedGameObject);

            }
        }

        //if (moving)
        {
            step = speed * Time.deltaTime;
            destination = waypoints[index].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, destination, step);
            distance = Vector2.Distance(transform.position, destination);

            if (t == 1)
            {

                if (distance <= 0.5)
                {
                    
                    if (index == startIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index++;
                        action = 1;
                    }
                    else if (index == startIndex1+1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index++;
                        action = 1;
                    }

                    //if in T2
                    else if (index == endIndex2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index =3;
                        action = 1;
                    }
                    else if (index == endIndex2-1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T3
                    else if (index == endIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 1;
                        action = 1;
                    }
                    else if (index == endIndex3 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 2;
                        action = 1;
                    }
                    else if (index == endIndex3 - 2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T4                   
                    else if (index == endIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 1;
                        action = 1;
                    }
                    else if (index == endIndex4 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 4;
                        action = 1;
                    }
                    else if (index == endIndex4 - 4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Kitchen
                    else if (index == kitchenIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Wash Area
                    else if (index == washAreaIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1 - 1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }
                    //if in Fridge
                    else if (index == fridgeIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }
                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }

            }
            else if (t == 2)
            {
                if (distance <= 0.5)
                {
                    //if in Base
                    if (index == 0)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex2;
                        action = 1;
                    }
                    else if (index == startIndex2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex2 + 1;
                        action = 1;
                    }

                    //if in T1
                    else if (index == endIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index--;
                        action = 1;
                    }
                    else if (index == endIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index =0;
                        action = 1;
                    }

                    //if in T3
                    else if (index == endIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 1;
                        action = 1;
                    }
                    else if (index == endIndex3 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 2;
                        action = 1;
                    }
                    else if (index == endIndex3 - 2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T4                   
                    else if (index == endIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 1;
                        action = 1;
                    }
                    else if (index == endIndex4 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 4;
                        action = 1;
                    }
                    else if (index == endIndex4 - 4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Kitchen
                    else if (index == kitchenIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Wash Area
                    else if (index == washAreaIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1 - 1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }
                    //if in Fridge
                    else if (index == fridgeIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }
                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }
            }
            else if (t == 3)
            {
                if (distance <= 0.5)
                {
                    //if in Base
                    if (index == 0)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex3;
                        action = 1;
                    }
                    else if (index == startIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex3 + 1;
                        action = 1;
                    }
                    else if (index == startIndex3+1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex3 + 2;
                        action = 1;
                    }

                    //if in T1
                    else if (index == endIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index--;
                        action = 1;
                    }
                    else if (index == endIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T2
                    else if (index == endIndex2)
                    {
                        index = 3;
                        action = 1;
                    }
                    else if (index == endIndex2 - 1)
                    {
                        index = 0;
                        action = 1;
                    }

                    //if in T4                   
                    else if (index == endIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 1;
                        action = 1;
                    }
                    else if (index == endIndex4 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 3;
                        action = 1;
                    }




                    //if in Kitchen
                    else if (index == kitchenIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Wash Area
                    else if (index == washAreaIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1 - 1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Fridge
                    else if (index == fridgeIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }
                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }
            }
            else if (t == 4)
            {
                if (distance <= 0.5)
                {
                    //if in Base
                    if (index == 0)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex4;
                        action = 1;
                    }
                    else if (index == startIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex4 + 3;
                        action = 1;
                    }
                    else if (index == startIndex4 + 3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = startIndex4 + 4;
                        action = 1;
                    }
                    

                    //if in T1
                    else if (index == endIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index--;
                        action = 1;
                    }
                    else if (index == endIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T2
                    else if (index == endIndex2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 3;
                        action = 1;
                    }
                    else if (index == endIndex2 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T3
                    else if (index == endIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 1;
                        action = 1;
                    }
                    else if (index == endIndex3 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 2;
                        action = 1;
                    }

                    //if in Kitchen
                    else if (index == kitchenIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Wash Area
                    else if (index == washAreaIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1 - 1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Fridge
                    else if (index == fridgeIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }
            }
            else if (t == 5) //Kitchen
            {
                UnityEngine.Debug.Log("index " + index);
                if (distance <= 0.5)
                {
                    //if in T1
                    if (index == endIndex1)
                    {

                        UnityEngine.Debug.Log("index " + index);
                        index--;
                        action = 1;
                       
                    }
                    else if (index == endIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                        
                    }


                    //if in T2
                    else if (index == endIndex2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 3;
                        action = 1;
                    }
                    else if (index == endIndex2 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T3
                    else if (index == endIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 1;
                        action = 1;
                    }
                    else if (index == endIndex3 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 2;
                        action = 1;
                    }
                    else if (index == endIndex3 - 2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T4                   
                    else if (index == endIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 1;
                        action = 1;
                    }
                    else if (index == endIndex4 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 4;
                        action = 1;
                    }
                    else if (index == endIndex4 - 4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Wash Area
                    else if (index == washAreaIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1-1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1-1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Fridge
                    else if (index == fridgeIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }
            }
            else if (t == 6)//Wash Area
            {                

                if (distance <= 0.5)
                {
                    //if in Kitchen or Base
                    if (index == 0)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1-1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1;
                        action = 1;
                    }

                    //if in T1
                    if (index == endIndex1)
                    {

                        UnityEngine.Debug.Log("index " + index);
                        index--;
                        action = 1;

                    }
                    else if (index == endIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;

                    }


                    //if in T2
                    else if (index == endIndex2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 3;
                        action = 1;
                    }
                    else if (index == endIndex2 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T3
                    else if (index == endIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 1;
                        action = 1;
                    }
                    else if (index == endIndex3 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 2;
                        action = 1;
                    }
                    else if (index == endIndex3 - 2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T4                   
                    else if (index == endIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 1;
                        action = 1;
                    }
                    else if (index == endIndex4 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 4;
                        action = 1;
                    }
                    else if (index == endIndex4 - 4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Fridge
                    else if (index == fridgeIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }
            }

            else if (t == 7)//Fridge
            {

                if (distance <= 0.5)
                {
                    //if in Kitchen or Base
                    if (index == 0)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1 - 1;
                        action = 1;
                    }
                    else if (index == fridgeIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = fridgeIndex1;
                        action = 1;
                    }

                    //if in T1
                    if (index == endIndex1)
                    {

                        UnityEngine.Debug.Log("index " + index);
                        index--;
                        action = 1;

                    }
                    else if (index == endIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;

                    }


                    //if in T2
                    else if (index == endIndex2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 3;
                        action = 1;
                    }
                    else if (index == endIndex2 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T3
                    else if (index == endIndex3)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 1;
                        action = 1;
                    }
                    else if (index == endIndex3 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex3 - 2;
                        action = 1;
                    }
                    else if (index == endIndex3 - 2)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in T4                   
                    else if (index == endIndex4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 1;
                        action = 1;
                    }
                    else if (index == endIndex4 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = endIndex4 - 4;
                        action = 1;
                    }
                    else if (index == endIndex4 - 4)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                    //if in Wash Area
                    else if (index == washAreaIndex1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = washAreaIndex1 - 1;
                        action = 1;
                    }
                    else if (index == washAreaIndex1 - 1)
                    {
                        UnityEngine.Debug.Log("index " + index);
                        index = 0;
                        action = 1;
                    }

                }
                else
                {
                    action = 0;// Reached the last waypoint, set to idle animation
                }
            }

            //Code for Animation
            //transform.position = Vector2.MoveTowards(transform.position, destination, step);

            if (transform.position.x < destination.x)
            {
                transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
                action = 1; // Set to walk animation
            }
            else if (transform.position.x > destination.x)
            {
                transform.localScale = new Vector3(-3.5f, 3.5f, 3.5f);
                action = 1; // Set to walk animation
            }
            else
            {
                // If neither left nor right, player should be walking forward or backward
                if (transform.position.y < destination.y)
                {
                    anim.SetBool("walkUpDown", action != 0); // Enable the "walk" parameter when not idle
                    // Moving up
                    action = 1; // Set to walk animation
                }
                else if (transform.position.y > destination.y)
                {
                    // Moving down
                    action = 1; // Set to walk animation
                }
                else
                {
                    // Player is not moving
                    action = 0;
                }
            }

        }
        // Set animator parameters
        anim.SetBool("walkSide", action != 0); // Enable the "walk" parameter when not idle
    }
}