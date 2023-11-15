/***using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTest
{

    [Test]
    public void PlayerMovementTestSimplePasses()
    {
       
    }
    [UnityTest]

    public IEnumerator MouseClickMovementMovesTowardsClickedPosition()
    {
        // Create or instantiate a GameObject with the MouseClickMovement script attached
        GameObject player = new GameObject("Player");
        MouseClickMovement mouseClickMovement = player.AddComponent<MouseClickMovement>();
        mouseClickMovement.speed = 10f;


      

        // Wait for one frame to update the movement
        yield return null;

        // Ensure the player is moving
        Assert.IsTrue(mouseClickMovement.moving);

        // Wait for a few frames to complete the movement (adjust the time as needed)
        yield return new WaitForSeconds(2.0f);

        // Check if the player has reached the target position
        // (You may need to adjust the assertion depending on the specific logic in your script)
        Assert.AreEqual(mouseClickMovement.lastClickedPos, new Vector2(player.transform.position.x, player.transform.position.y));

        // Ensure the player is no longer moving
        Assert.IsFalse(mouseClickMovement.moving);

        // Clean up
        GameObject.Destroy(player);
    }

}

8**/
