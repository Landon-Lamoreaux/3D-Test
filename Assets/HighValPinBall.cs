using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighValPinBall : PinBallBehavior
{
    private void Awake()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
    protected override void OnCollisionEnter(Collision other)
    {
        if (other.collider.name.Contains("Peg"))
        {
            game.AddPoint(10);
            audioSource.Play();
        }
        else if (other.collider.name.Contains("Player"))
        {
            body.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
}