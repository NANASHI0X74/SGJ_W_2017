using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansSpawn : MonoBehaviour {

    public GameObject fanW;
    public GameObject player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        InvokeRepeating("FanSpawning", 0.5f, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        //InvokeRepeating("FanSpawning()", 0.0f, 5.0f);
        //FanSpawning();
	}

    public void FanSpawning()
    {
        fanW.transform.position = this.transform.position + offset;
        fanW.GetComponent<AIFans>().m_target = player.transform;
        fanW.GetComponent<AIFans>().m_pc = player.GetComponent<PlayerControler>();
        GameObject neuerFan = GameObject.Instantiate(fanW);
        neuerFan.transform.position = fanW.transform.position;
    }
}
