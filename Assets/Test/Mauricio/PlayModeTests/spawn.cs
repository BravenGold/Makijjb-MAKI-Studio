using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class spawn{

    [UnityTest]
    public IEnumerator spawnWithEnumeratorPasses(){

        // Create a GameObject to host the FoodSpawner script (not in the actual scene)
        GameObject spawnerObject = new GameObject("FoodSpawnerObject");
        FoodSpawner foodSpawner = spawnerObject.AddComponent<FoodSpawner>();

        // Run the FoodSpawn coroutine
        IEnumerator coroutine = foodSpawner.FoodSpawn();
        while (coroutine.MoveNext())
        {
            yield return null; // Manually update the coroutine frame by frame.
        }

        // Retrieve all spawned objects with colliders
        Collider2D[] spawnedColliders = Object.FindObjectsOfType<Collider2D>();

        // Check if any of the spawned objects overlap
        for (int i = 0; i < spawnedColliders.Length; i++)
        {
            for (int j = i + 1; j < spawnedColliders.Length; j++)
            {
                // Ensure that the colliders are not overlapping
                Assert.IsFalse(spawnedColliders[i].IsTouching(spawnedColliders[j]));
            }
        }

        // Clean up
        Object.Destroy(spawnerObject);

        yield return null;

    }
}
