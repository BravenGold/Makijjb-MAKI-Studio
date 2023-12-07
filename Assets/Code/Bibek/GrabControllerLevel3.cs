using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabControllerLevel3 : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    private bool isHoldingItem = false;
    private GameObject heldItem = null;

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);

        if (grabCheck.collider != null && (grabCheck.collider.tag == "Steak" || grabCheck.collider.tag == "Salad" || grabCheck.collider.tag == "Chicken" || grabCheck.collider.tag == "Fridge" || grabCheck.collider.tag == "Oven" || grabCheck.collider.tag == "Trash" || grabCheck.collider.tag == "Counter"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (!isHoldingItem)
                {
                    // Pick up the item
                    heldItem = grabCheck.collider.gameObject;
                    heldItem.transform.parent = boxHolder;
                    heldItem.transform.position = boxHolder.position;
                    heldItem.GetComponent<Rigidbody2D>().isKinematic = true;
                    isHoldingItem = true;
                }
                else
                {
                    // Release the item
                    if (heldItem != null)
                    {
                        heldItem.transform.parent = null;
                        heldItem.GetComponent<Rigidbody2D>().isKinematic = false;
                        heldItem = null;
                    }
                    isHoldingItem = false;
                }
            }
        }
        else if (isHoldingItem && Input.GetKeyDown(KeyCode.G))
        {
            // Release the item if the player is holding one but not over a grabbable object
            if (heldItem != null)
            {
                heldItem.transform.parent = null;
                heldItem.GetComponent<Rigidbody2D>().isKinematic = false;
                heldItem = null;
            }
            isHoldingItem = false;
        }
    }
}
