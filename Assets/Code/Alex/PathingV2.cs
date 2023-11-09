using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathingV2 : MonoBehaviour
{
    public GameObject customerObject;
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public float speed;
    private bool orderReceived = false;

    private Vector3 actualPosition;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualPosition = customerObject.transform.position;
        customerObject.transform.position = Vector3.MoveTowards(actualPosition, pathPoints[x].transform.position, speed * Time.deltaTime);

        if(actualPosition == pathPoints[x].transform.position && x != numberOfPoints - 1)
        {
            if (orderReceived == false)
            {
                x++;
            }
            else
            {
                x--;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Steak" || collision.gameObject.tag == "Chicken") && orderReceived == true)
        {
            Debug.Log("FOOD RECEIVED");
            orderReceived = true;
            // Call functions in the future
        }
    }
}
