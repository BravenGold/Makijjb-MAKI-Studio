using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salad : Food
{
    public override void PointAllocation(){
        points = 5;
    }
    public override void Timer(){
        CookingTimer = 0f;
    }
    public override void Cookable(){
        isCookable = false; 
    }
}
