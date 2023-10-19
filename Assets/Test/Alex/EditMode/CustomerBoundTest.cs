using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CustomerBoundTest
{

    // A Test behaves as an ordinary method
    [Test]
    public void CustomerNotExceedMax()
    {
        var gameObject = new GameObject();
        var CustGen = gameObject.AddComponent<GenerateCustomer>();
        Assert.LessOrEqual(5, CustGen.CurrentCustomers);
    }

    public void CustomerOrderNotExceed()
    {
        var gameObject = new GameObject();
        var CustGen = gameObject.AddComponent<GenerateCustomer>();
        Assert.LessOrEqual(CustGen.CurrentCustomers, CustGen.OrdersPlaced);
    }

}
