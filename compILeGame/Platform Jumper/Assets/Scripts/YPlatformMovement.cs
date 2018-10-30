using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPlatformMovement : MonoBehaviour {

    public float yLimitUp = 34.73f;
    public float yLimitDown = 30.73f;
    public float speed = 2f;
    private int direction = 1;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yLimitUp)
        {
            direction = -1;
        }

        if (transform.position.y < yLimitDown)
        {
            direction = 1;
        }


        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);
    }
}

