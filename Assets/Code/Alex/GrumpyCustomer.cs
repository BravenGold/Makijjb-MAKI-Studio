using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// GrumpyCustomer is a subclass of Customer that prefers
public class GrumpyCustomer : Customer
{
    // No additional variables needed! Inherits variables from customer superclass


    // COLLISION CHECKERS
    // OnCollisionEnter2D is overwritten to have different conditions than a regular customer
    // NOTE: Keyword new is "required" according to documentation to make sure this function overloads the old one
    new public void OnCollisionEnter2D(Collision2D collision)
    {
        // GrumpyCustomers DEMAND Chicken
        string orderTag = "Chicken";
        // Check to see if the customer has collided with the played and if the order has already been placed
        if (collision.gameObject.tag == "Player" && orderPlaced == false)
        {
            // Print to debug log
            Debug.Log("CUSTOMER CLICKED AND ORDER PLACED");

            // Enable the order graphic (Chicken)
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            // Make sure customer knows order has been placed
            orderPlaced = true;


        }

        // Check to see if the order has been placed and the customer is colliding with the correct dish
        if ((collision.gameObject.tag == orderTag) && orderPlaced == true)
        {
            // Print to debug log
            Debug.Log("FOOD RECEIVED");

            // Disable the order graphic (Chicken) 
            gameObject.transform.GetChild(1).gameObject.SetActive(false);

            // The order has been received. Important for pathing script!
            orderReceived = true;

            /* NOTE:
             * Scoring will be added here somehow eventually! Promise!
             */
        }
    }
}
