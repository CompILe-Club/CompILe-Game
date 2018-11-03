using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatGenMover : MonoBehaviour {

    public GameObject platformGeneratorObject;
    public Transform yAxisThreshold;
    public float distanceBetween;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y< yAxisThreshold.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + distanceBetween, transform.position.z);

            Instantiate(platformGeneratorObject, transform.position, transform.rotation);
        }
	}
}
