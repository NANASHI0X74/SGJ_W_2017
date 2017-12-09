using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansSpawn : MonoBehaviour {

    public GameObject fanW;
    public Vector3 offset;

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        fanW.transform.position = this.transform.position + offset;
        GameObject neuerFan = GameObject.Instantiate(fanW);
	}
}
