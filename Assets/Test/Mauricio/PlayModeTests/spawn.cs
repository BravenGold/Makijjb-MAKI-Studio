using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class spawn{

    private GameObject gameObject;
    private SteakPool Spawntest;

    private GameObject SaladObject;
    private SaladPool Saladtest;

    [SetUp]
    public void Setup()
    {
        Spawntest = SteakPool.GetInstance();
        // Create a new GameObject and add the SteakPool component to it.
        if(Spawntest==null){
            gameObject = new GameObject();
            Spawntest = gameObject.AddComponent<SteakPool>();
            Spawntest.Steakprefab = Resources.Load<GameObject>("Prefab/rawmeat");
        }
        Saladtest = SaladPool.GetInstance();
        //This is the set up for the saladpool and a game object
        if(Saladtest==null){
            SaladObject = new GameObject();
            Saladtest = SaladObject.AddComponent<SaladPool>();
            Saladtest.Saladprefab = Resources.Load<GameObject>("Prefab/salad");
        }
    }
    [UnityTest]
    public IEnumerator LimiterWithEnumeratorPasses(){
        //This checks to see that only 10 steak items are created. 
        int spawnum = 0;
        for(spawnum=0;spawnum<50;spawnum++){
            Spawntest.GetSteak();
        }
        Assert.AreEqual(10,Spawntest.Foodcount());
        //This checks that only 10 salad food items are made. 
        spawnum = 0;
        for(spawnum=0;spawnum<50;spawnum++){
            Saladtest.GetSalad();
        }
        Assert.AreEqual(10,Saladtest.Foodcount());

        return null;
    }
}
/*
This test helped when for some reason nothing was moving in our game. Some one pushed a version of the game that would pause everything in a level. 
It wasn't until a player paused and unpaused the game then would the game resume as normal. I had no idea how that was happening. I though it was a singular 
scene issue. But trying the test and seeing it was not running made me check other scenes. It turns out all scenes were being paused by something this person 
pushed. I then had to go through their files and find what is causing this exact issue. 
*/