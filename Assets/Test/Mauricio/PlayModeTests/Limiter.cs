using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Limiter{
    [UnityTest]
    public IEnumerator LimiterWithEnumeratorPasses(){
        // Create a GameObject to host the FoodSpawner script
        GameObject spawnerObject = new GameObject("FoodSpawnerObject");
        FoodSpawner foodSpawner = spawnerObject.AddComponent<FoodSpawner>();

        // Set the maximum items to spawn to 3 for testing
        foodSpawner.maxItemsToSpawn = 3;

        // Manually start the FoodSpawn coroutine
        IEnumerator coroutine = foodSpawner.FoodSpawn();
        while (coroutine.MoveNext())
        {
            yield return null; // Manually update the coroutine frame by frame.
        }

        // Perform the assertion
        Assert.AreEqual(3, foodSpawner.itemsSpawned);

        // Clean up
        Object.Destroy(spawnerObject);
    }
}
