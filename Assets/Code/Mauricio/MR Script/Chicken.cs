using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Food{
    public override void PointAllocation(){
        points = 10;
    }

    public override void Cookable(){
        isCookable=true;
    }
    public override void Timer(){
        CookingTimer = 15f;
    }
}
