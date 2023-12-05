using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{

    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    void Update()
    {

        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        // Debug.Log("Update function.");

        if (grabCheck.collider != null && (grabCheck.collider.tag == "Steak" || grabCheck.collider.tag == "Salad"))
        {
            // Debug.Log("Grab checked.");
            if (Input.GetKey(KeyCode.G))
            {
                // Debug.Log("Food tried to be grabbed.");
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }
            else
            {
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }

        }

    }
}