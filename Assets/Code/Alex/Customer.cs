using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Public varaibles so other scripts (PathingV2) can access the status of customers
    public bool orderPlaced = false;
    public bool orderReceived = false;

    // Start to disable the order graphics
    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    // COLLISION CHECKERS
    virtual public void OnCollisionEnter2D(Collision2D collision)
    {
        // Default caveman customer will order Steak
        string orderTag = "Steak";
        // Check to see if the customer has collided with the played and if the order has already been placed
        if (collision.gameObject.tag == "Player" && orderPlaced == false)
        {
            // Print to debug log
            Debug.Log("CUSTOMER CLICKED AND ORDER PLACED");

            // Enable the order graphic (Steak)
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            // Make sure customer knows order has been placed
            orderPlaced = true;


        }

        // Check to see if the order has been placed and the customer is colliding with the correct dish
        if ((collision.gameObject.tag == orderTag) && orderPlaced == true)
        {
            // Print to debug log
            Debug.Log("FOOD RECEIVED");

            // Disable the order graphic (Chicken) 
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            // The order has been received. Important for pathing script!
            orderReceived = true;

            /* NOTE:
             * Scoring will be added here somehow eventually! Promise!
             */
        }
    }
}
