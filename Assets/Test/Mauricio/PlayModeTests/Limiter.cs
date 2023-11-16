  /********************************
  * Limiter.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This test detects whether or not a
  * steak prefab can be detected by the 
  * interact function. 
  * 
  ********************************/
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Limiter{
    private OvenStarter ovenStarter;

    private GameObject gameObject;
    private SteakPool Spawntest;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the SteakPool component to it.
        gameObject = new GameObject();
        Spawntest = gameObject.AddComponent<SteakPool>();
        Spawntest.Steakprefab = Resources.Load<GameObject>("Prefab/rawmeat");
        
        GameObject ovenObject = new GameObject();
        ovenStarter = ovenObject.AddComponent<OvenStarter>();
        CircleCollider2D circleCollider = ovenObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = 5.0f; 
        circleCollider.isTrigger = true;
        ovenStarter.Cooking = false; 
        ovenStarter.isInRange = false; 
        ovenStarter.interactKey = KeyCode.F;

        GameObject movePosition = new GameObject();
        movePosition.transform.position = new Vector3(5.0f, 0.0f, 0.0f); 
        BoxCollider2D boxCollider = movePosition.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(2.0f, 2.0f);

        ovenStarter.MovePoint = movePosition;
    }
    [UnityTest]
    public IEnumerator LimiterWithEnumeratorPasses(){

        // Obtain a steak GameObject from the Spawntest.
        GameObject steak1 = Spawntest.GetSteak();
    
        // Get the position of the ovenObject's 2D Box Collider.
        Vector3 targetPosition = ovenStarter.GetComponent<Collider2D>().bounds.center;
        
        // Move the steak object to the target position.
        steak1.transform.position = targetPosition;

        // Assert that the steak is within the oven's 2D Box Collider.
        Assert.IsTrue(ovenStarter.GetComponent<Collider2D>().bounds.Contains(steak1.transform.position));

        return null;
    }
}
