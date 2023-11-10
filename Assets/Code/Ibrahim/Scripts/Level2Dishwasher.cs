using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Dishwasher : SingletonDishwasher
{
    //Virtual Functions
    public override void ChangeSprite()
    {
        Sprite.sprite = Level2Washer;
    }
    //End of virtual functions
}
