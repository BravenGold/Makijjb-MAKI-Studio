  /********************************
  * Salad.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This is a subclass of food. This is attached
  * to the Salad prefab.
  * 
  ********************************/

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
    //Cookable in salad is set to false because we cannot cook a salad in this game.
    public override void Cookable(){
        isCookable = false; 
    }
}
