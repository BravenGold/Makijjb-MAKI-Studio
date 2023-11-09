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

    public void PlayCookingAnimation(){
        if (ChickenAnimator != null){
            ChickenAnimator.SetBool("Cooked", true); // Adjust parameter names and conditions as per your Animator setup
        }
    }

    public void StopCookingAnimation(){
        if (ChickenAnimator != null){
            ChickenAnimator.SetBool("cooked", false);
        }
    }
}
