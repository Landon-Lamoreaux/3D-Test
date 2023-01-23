using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBallBehavior : MonoBehaviour
{
    public MeshRenderer color;
    public Rigidbody body;
    public GameEvents game;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        // If the sphere goes out of bounds, delete it
        if (transform.position.y < 0)
            Destroy(gameObject);
    }
    protected virtual void OnCollisionEnter(Collision other)
    {
        // If the other object is a peg, add to the score, and play audio
        if (other.collider.name.Contains("Peg"))
        {
            game.AddPoint(1);
            audioSource.Play();
        }
        // If the other object is the player block, push the pinball back up
        else if (other.collider.name.Contains("Player"))
        {
            body.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
        }
    }
}
