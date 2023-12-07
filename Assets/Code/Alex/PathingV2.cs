using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the movement and pooling interactions for customers
public class PathingV2 : MonoBehaviour
{
    // VARIABLES

    // Reference to customers scripts, allowing access to variables in the customer script
    public Customer customerReference;

    // Reference to the object pool to take and store customers
    // public CustomerObjectPool customerObjectPool;

    // The actual customer object this instance of PathingV2 will control
    public GameObject customerObject;

    // The list of points this particular customer will follow
    public GameObject[] pathPoints;

    // Customer move speed
    public float speed;

    // Index of the current point. Initialized to zero by default
    private int currentPointIndex = 0;

    // Store the starting position of the customer to reset the position when needed
    private Vector3 startingPosition;


    // Start is called before the first frame update
    void Start()
    {
        // Access the customer object pool and set this customer to be active!
        // customerObject = customerObjectPool.GetCustomerFromPool();

        // Store the starting position for resetting purposes
        startingPosition = customerObject.transform.position;
    }

    // Update loop. If the order has not been received, the customer will wait at the table
    // Else, the customer will leave and be returned to the object pool when offscreen.
    void Update()
    {
        if (!customerReference.orderReceived)
        {
            MoveToNextPoint();
        }
        else
        {
            MoveBackToStart();
        }
    }

    // A function to path the customer to the table
    private void MoveToNextPoint()
    {
        // Check to see if the index exceeds the amount of points in the list
        if (currentPointIndex < pathPoints.Length)
        {
            // Specify the target position from the node and the step from the specified speed
            Vector3 targetPosition = pathPoints[currentPointIndex].transform.position;
            float step = speed * Time.deltaTime;

            // Move the customer to the targeted position
            customerObject.transform.position = Vector3.MoveTowards(customerObject.transform.position, targetPosition, step);

            // Once the node has been reached, increment the point index
            if (Vector3.Distance(customerObject.transform.position, targetPosition) < 0.01f)
            {
                currentPointIndex++;
            }
        }
    }

    // A function to return the customer to its original position by traversing the nodes in reverse
    // This gets called once the correct order has been received
    private void MoveBackToStart()
    {
        // Path back to the start. Check to see that the current index is not the starting position
        if (currentPointIndex > 0)
        {
            // Keep track of the previous index
            int previousIndex = currentPointIndex - 1;

            // Specify the target position from the node and the step from the specified speed
            Vector3 targetPosition = pathPoints[previousIndex].transform.position;
            float step = speed * Time.deltaTime;

            // Move the customer to the targeted position
            customerObject.transform.position = Vector3.MoveTowards(customerObject.transform.position, targetPosition, step);

            // Once the node has been reached, decrement the point index
            if (Vector3.Distance(customerObject.transform.position, targetPosition) < 0.01f)
            {
                currentPointIndex--;
            }
        }
        // Once the start has been reached, reset important values and return to the pool!
        else
        {
            // Reset values
            currentPointIndex = 0;
            customerObject.transform.position = startingPosition;
            customerReference.orderPlaced = false;
            customerReference.orderReceived = false;

            // Return to pool
            // customerObjectPool.ReturnCustomerToPool(customerObject);
        }
    }
}
