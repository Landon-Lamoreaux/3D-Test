using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject other;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera for efficency.
        cam = Camera.main;
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        // Gets the mouse location on the screen.
        Vector3 curMouse = Input.mousePosition;

        // Find how far away on the z-axis the object is from the camera.
        float distanceToCam = transform.position.z - cam.transform.position.z;

        // Convert that screen poin to a location in the world.
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(curMouse.x, curMouse.y, distanceToCam));

        transform.position = new Vector3(point.x, transform.position.y, transform.position.z);

        // Move the player bar to that location, unless outside of bounds.
        if (this.transform.position.x > 3.5)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }
        else if (this.transform.position.x < -3.5)
        {
            transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
    }
}
