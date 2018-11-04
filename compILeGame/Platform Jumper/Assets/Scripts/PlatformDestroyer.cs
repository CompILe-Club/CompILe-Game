using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

    private GameObject boundary;

    void Start()
    {
        boundary = GameObject.Find("Boundary");
    }

    void Update()
    {
        if (transform.position.y < boundary.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

}
