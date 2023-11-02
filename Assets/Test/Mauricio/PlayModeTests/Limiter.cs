using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Limiter{

    private GameObject gameObject;
    private FoodObjectPool Spawntest;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the FoodObjectPool component to it.
        gameObject = new GameObject();
        Spawntest = gameObject.AddComponent<FoodObjectPool>();
        Spawntest.Foodprefab = Resources.Load<GameObject>("Prefab/Food");
    }
    [UnityTest]
    public IEnumerator LimiterWithEnumeratorPasses(){
        int spawnum = 0;
        for(spawnum=0;spawnum<50;spawnum++){
            Spawntest.GetFood();
        }
        Assert.AreEqual(30,Spawntest.Foodcount());
        return null;
    }
}
