using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DishWasher
{
    [UnityTest]
    public IEnumerator DishWasherWithEnumeratorPasses()
    {

        var gameObject = new GameObject();
        var Dishwa = gameObject.AddComponent<SingletonDishwasher>();

        //max amount of dishes
        for (int i = 0; i < 5; i++)
        {
            Dishwa.OnMouseDown();
        }

        //min amount of dishes
        Dishwa.OnMouseDown();
        Dishwa.OnMouseDown();

        yield return null;
    }
}