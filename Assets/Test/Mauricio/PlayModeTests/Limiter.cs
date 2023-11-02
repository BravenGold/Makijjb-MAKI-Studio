using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Limiter{
    [UnityTest]
    public IEnumerator LimiterWithEnumeratorPasses(){
        var gameObject = new GameObject();
        var Spawntest = gameObject.AddComponent<FoodObjectPool>();
        int spawnum = 0;
        for(spawnum=0;spawnum<30;spawnum++){
            Spawntest.GetFood();
        }
        Assert.AreEqual(spawnum,30);
        return null;
    }
}
