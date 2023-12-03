  /********************************
  * Chicken.cs
  * Mauricio Rodriguez, Maki Studios
  *
  * This is a subclass of food. This is attached
  * to the steak prefab.
  * 
  ********************************/


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
    //This makes the steak prefab look cooked .
    public void PlayCookingAnimation(){
        if (steakAnimator != null){
            steakAnimator.SetBool("cooked", true); 
        }
    }
    //This makes the steak prefab become raw again. 
    public void StopCookingAnimation(){
        if (steakAnimator != null){
            steakAnimator.SetBool("cooked", false);
        }
    }
}
