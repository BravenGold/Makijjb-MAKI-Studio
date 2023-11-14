using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public Transform holdSpot2;
    public LayerMask pickUpMask;

    public Vector3 Direction { get; set; }
    public GameObject itemHolding;
    public GameObject itemHolding2;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!itemHolding)
            {
                Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, 0.4f, pickUpMask);
                if (pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdSpot.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
            else if (!itemHolding2)
            {
                Collider2D pickUpItem2 = Physics2D.OverlapCircle(transform.position + Direction, 0.4f, pickUpMask);
                if (pickUpItem2)
                {
                    itemHolding2 = pickUpItem2.gameObject;
                    itemHolding2.transform.position = holdSpot2.position;
                    itemHolding2.transform.parent = transform;
                    if (itemHolding2.GetComponent<Rigidbody2D>())
                        itemHolding2.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (itemHolding)
            {
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
            }

            if (itemHolding2)
            {
                itemHolding2.transform.position = transform.position + Direction;
                itemHolding2.transform.parent = null;
                if (itemHolding2.GetComponent<Rigidbody2D>())
                    itemHolding2.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding2 = null;
            }
        }
    }

}
