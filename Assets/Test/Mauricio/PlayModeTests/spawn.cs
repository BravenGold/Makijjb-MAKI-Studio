using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class spawn{

    [UnityTest]
    public IEnumerator spawnWithEnumeratorPasses(){

        var gameObject = new GameObject();
        var T = gameObject.AddComponent<FoodSpawner>();
        yield return null;

    }
}
