using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Dishwasher : SingletonDishwasher
{
    //Virtual Functions
    public override void ChangeSprite()
    {
        Sprite.sprite = Level1Washer;
    }
    //End of virtual functions
}
