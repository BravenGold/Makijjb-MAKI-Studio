using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Limiter{
    [UnityTest]
    public IEnumerator LimiterWithEnumeratorPasses(){
        var gameObject = new GameObject();
        var F = gameObject.AddComponent<FoodSpawner>();
        //F.FoodPrefabPath = "Assets/Code/Mauricio/Prefab/Food";
        //yield return F.StartCoroutine(F.FoodSpawn());
        yield return new WaitForSeconds(10f);
        //Assert.AreEqual(3,F.valuereturn());
    }
}
