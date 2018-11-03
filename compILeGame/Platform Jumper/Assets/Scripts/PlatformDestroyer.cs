using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {
    public GameObject DestructionPoint;
	// Use this for initialization
	void Start () {
        DestructionPoint = GameObject.Find("PlatformDestroy");
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < DestructionPoint.transform.position.y)
        {
            Destroy(gameObject);
        }
	}
}
