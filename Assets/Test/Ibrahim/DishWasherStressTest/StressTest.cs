using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StressTest
{
    [UnityTest]
    public IEnumerator StressTestWithEnumeratorPasses()
    {

        var gameObject = new GameObject();
        var Dishwa = gameObject.AddComponent<DishwasherFunctionality>();

        //max amount of clicks
        for(int i = 0; i < 1000000; i++)
        {
            Dishwa.OnMouseDown();
        }

        yield return null;

    }
}
