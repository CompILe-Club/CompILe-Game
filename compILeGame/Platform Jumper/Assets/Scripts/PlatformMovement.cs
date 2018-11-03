using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    public GameObject platform;
    public float xLimitRight;
    public float xLimitLeft;
    public float speed = 2f;
    private int direction = 1;


    // Update is called once per frame
    void Start()
    {
        xLimitRight = transform.position.x + 5;
        xLimitLeft = transform.position.x - 5;
    }
    void Update () {

        if (transform.position.x > xLimitRight)
        {
            direction = -1;
        }

        if (transform.position.x < xLimitLeft)
        {
            direction = 1;
        }

         
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
	}
}
