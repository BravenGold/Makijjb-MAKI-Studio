using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using NUnit.Framework.Internal;
using UnityEngine.UIElements;

public class MouseClickMovementTests
{


    [UnityTest]
    public IEnumerator PickUpItemAndRelease()
    {
        GameObject player = new GameObject("Player");
        PickUp pickUpScript = player.AddComponent<PickUp>();

        // Create an item that can be picked up (you might need to create a prefab for this)
        GameObject item = new GameObject("Item");
        item.transform.position = new Vector3(1f, 1f, 0f); // Position the item

        // Set up the LayerMask so that the item can be picked up
        pickUpScript.pickUpMask = LayerMask.GetMask("YourPickUpLayerName");

        // Simulate pressing 'E' to pick up the item
        pickUpScript.Direction = Vector3.up; // Set the direction for picking up
        yield return new WaitForSeconds(0.1f); // Wait for a short time to allow picking up

        // Ensure the item is picked up and in the player's hold spot
        Assert.IsNotNull(pickUpScript.itemHolding);
        Assert.AreEqual(item.transform.position, pickUpScript.holdSpot.position);

        // Simulate pressing 'R' to release the item
        yield return new WaitForSeconds(0.1f); // Wait for a short time to allow releasing

        // Ensure the item is released and no longer in the player's hold spot
        Assert.IsNull(pickUpScript.itemHolding);
        Assert.AreEqual(item.transform.parent, null);
        Assert.AreNotEqual(item.transform.position, pickUpScript.holdSpot.position);

        // Clean up
        GameObject.Destroy(player);
        GameObject.Destroy(item);
    }
}




