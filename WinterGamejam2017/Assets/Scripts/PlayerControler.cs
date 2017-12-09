using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    private Transform m_playerTransform;

	// Use this for initialization
	void Start () {
        m_playerTransform = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("w"))
        {
            m_playerTransform.position = Vector3.up * 3f;
        }
        if (Input.GetButtonDown("a"))
        {
            m_playerTransform.position = Vector3.left * 3f;
        }
        if (Input.GetButtonDown("s"))
        {
            m_playerTransform.position = Vector3.down * 3f;
        }
        if (Input.GetButtonDown("d"))
        {
            m_playerTransform.position = Vector3.right * 3f;
        }
	}
}
