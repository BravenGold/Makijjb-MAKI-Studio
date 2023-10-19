using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CustomerBoundTest
{

    // A Test behaves as an ordinary method
    [Test]
    public void CustomerNotExceedMax()
    {
        float compare = 5f;
        var gameObject = new GameObject();
        var CustGen = gameObject.AddComponent<GenerateCustomer>();
        Assert.LessOrEqual(CustGen.CurrentCustomers, compare);
    }

    public void CustomerOrderNotExceed()
    {
        var gameObject = new GameObject();
        var CustGen = gameObject.AddComponent<GenerateCustomer>();
        Assert.LessOrEqual(CustGen.CurrentCustomers, CustGen.OrdersPlaced);
    }

}
