
  /********************************
  * Food.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This is the super class of the dynamic 
  * binding. It has basic values that are held
  * by this super class and can be modified by
  * the subclasses. 
  ********************************/

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Food : MonoBehaviour{
    //This bool determines if this food item is cookable
    public bool isCookable;
    //This is a place holder for a timer 
    public float CookingTimer;
    //These are the points placed in the score board after they are "eaten"
    public int points;  
    //This bool tells us if the food is cooked or not. 
    public bool cooked = false; 

    public virtual void Cookable(){
        isCookable = true; 
    }

    public virtual void Timer(){
        CookingTimer = 5f;
    }

    public virtual void PointAllocation(){
        points = 1;
    }

    public void ChangeCook(bool Input){
        cooked = Input;
    }
}


