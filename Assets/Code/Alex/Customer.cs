using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private bool orderPlaced = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check to see if the customer has collided with the played and if the order has already been placed
        if (collision.gameObject.tag == "Player" && orderPlaced == false)
        {
            Debug.Log("CUSTOMER CLICKED AND ORDER PLACED");
            orderPlaced = true;
            // Call functions in the future
        }
    }
}
