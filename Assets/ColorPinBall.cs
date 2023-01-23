using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPinBall : PinBallBehavior
{
    protected override void OnCollisionEnter(Collision other)
    {
        //have the parent do it's stuff
        base.OnCollisionEnter(other);
        //get a random color
        Material temp = (Material)Resources.Load("Materials/Red");
        int val = (int)(Random.value * 3);
        switch (val)
        {
            case 0:
                //already done
                break;
            case 1:
                temp = (Material)Resources.Load("Materials/Blue");
                break;
            case 2:
                temp = (Material)Resources.Load("Materials/Yellow");
                break;
        }
        //set it
        color.material = temp;
    }
}