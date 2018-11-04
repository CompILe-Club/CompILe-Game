using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlatformGenerator : MonoBehaviour {

    public GameObject[] objects;
    



    void Start()
    {
        int rand = 0;
        if (this.transform.position.y < 20)
        {
            rand = Random.Range(0, objects.Length);
        }
        else
        {
            rand = Random.Range(2, objects.Length);
        }
        

        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }

}
