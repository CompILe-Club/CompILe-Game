using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPlatformMovement : MonoBehaviour {

    private float yLimitUp;
    private float yLimitDown;
    public float speed = 2f;
    private int direction = 1;

    private void Start()
    {
        yLimitUp = transform.position.y + 3;
        yLimitDown = transform.position.y - 3;

    }
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

