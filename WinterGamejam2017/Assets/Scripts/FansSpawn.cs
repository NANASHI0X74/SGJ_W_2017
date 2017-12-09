using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansSpawn : MonoBehaviour {

    public GameObject fanW;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FanSpawning", 0.5f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        //InvokeRepeating("FanSpawning()", 0.0f, 5.0f);
        //FanSpawning();
	}

    public void FanSpawning()
    {
        fanW.transform.position = this.transform.position + offset;
        GameObject neuerFan = GameObject.Instantiate(fanW);
    }
}
