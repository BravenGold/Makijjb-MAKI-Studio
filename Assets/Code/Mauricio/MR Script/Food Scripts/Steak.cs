using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak : Food
{
    [SerializeField] private Animator steakAnimator;
    private void Start(){
        steakAnimator = GetComponent<Animator>();
    }
    public override void PointAllocation(){
        points = 5;
    }
    public void PlayCookingAnimation(){
        if (steakAnimator != null){
            steakAnimator.SetBool("cooked", true); // Adjust parameter names and conditions as per your Animator setup
        }
    }

    public void StopCookingAnimation(){
        if (steakAnimator != null){
            steakAnimator.SetBool("cooked", false);
        }
    }
}
