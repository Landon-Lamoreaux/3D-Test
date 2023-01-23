using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEvents : MonoBehaviour
{
    private int points;
    public TMP_Text score;

    void Awake()
    {
        points = 0;
        Debug.Log("in awake");
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + points;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject temp = Resources.Load<GameObject>("PinBall");

            int val = (int)(Random.value * 3);
            switch (val)
            {
                case 0:
                    //already done
                    break;
                case 1:
                    temp = Resources.Load<GameObject>("HighValPinBall");
                    break;
                case 2:
                    temp = Resources.Load<GameObject>("ColorPinBall");
                    break;
            }

            GameObject pinball = Instantiate(temp, new Vector3(0, 4, 0), Quaternion.identity);

            pinball.GetComponent<PinBallBehavior>().game = this;


            //apply some upwards force
            float theta = Random.value * Mathf.PI;
            float scale = 20;
            float x = Mathf.Cos(theta) * scale;
            float z = Mathf.Sin(theta) * scale;
            pinball.GetComponent<Rigidbody>().AddForce(new Vector3(x, scale, z), ForceMode.VelocityChange);
        }
    }

    public void AddPoint(int points)
    {
        this.points += points;
    }
}
