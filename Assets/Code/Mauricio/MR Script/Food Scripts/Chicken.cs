  /********************************
  * Chicken.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This is a subclass of food. This is attached
  * to the chicken prefab.
  * 
  ********************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : Food{
    [SerializeField] private Animator ChickenAnimator;

    public override void PointAllocation(){
        points = 10;
    }

    public override void Cookable(){
        isCookable=true;
    }
    public override void Timer(){
        CookingTimer = 15f;
    }
    //This tells the animator to play the cooked animation.
    public void PlayCookingAnimation(){
        if (ChickenAnimator != null){
            ChickenAnimator.SetBool("Cooked", true); 
        }
    }
    //This tells the animator to show that the meat is raw again. 
    public void StopCookingAnimation(){
        if (ChickenAnimator != null){
            ChickenAnimator.SetBool("cooked", false);
        }
    }
}
