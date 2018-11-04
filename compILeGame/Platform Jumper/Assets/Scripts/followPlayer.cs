using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public GameObject player;

    private float offset;

    // Use this for initialization
    void Start()
    {
        offset = player.transform.position.y - transform.position.y;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0, player.transform.position.y - offset, 0);
      
    }
}
