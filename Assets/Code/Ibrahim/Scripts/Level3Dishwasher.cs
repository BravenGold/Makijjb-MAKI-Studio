using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Dishwasher : SingletonDishwasher
{
    //Virtual Functions
    public override void XYcoord()
    {
        xcoord = -0.12f;
        ycoord = 0.5f;
    }

    public override void ChangeSprite()
    {
        Sprite.sprite = Level3Washer;
    }
    //End of virtual functions
}
