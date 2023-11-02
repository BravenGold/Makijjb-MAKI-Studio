using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class StressTest
{
    public int avgFrameRate;


    [UnityTest]
    public IEnumerator StressTestWithEnumeratorPasses()
    {
        var gameObject = new GameObject();
        var Dishwa = gameObject.AddComponent<DishwasherFunctionality>();
        int i = 0;
        float FRT = 50.0f;

        //max amount of clicks
        do
        {
            float FR = 1.0f / Time.deltaTime;

            Dishwa.OnMouseDown();
            i++;

            if(FRT > FR)
            {
                Debug.Log(i);
            }

            Assert.GreaterOrEqual(FR, FRT, "Frame rate below threshold");
            yield return null;

        } while (true);
    }
}
