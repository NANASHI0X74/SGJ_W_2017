using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBounds : MonoBehaviour {

    public AIFans m_fanObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log(_other.name);
        if (_other.GetComponent<GameObject>() == null)
        {

        }
        else if (_other.GetComponent<GameObject>().tag == ("Wall"))
        {
            Transform fanTransform = m_fanObject.GetComponent<Transform>();
            Quaternion fanRotation = fanTransform.rotation;
            float yRotation = fanTransform.rotation.y;
            yRotation += 90;
            fanTransform.rotation = new Quaternion (fanTransform.rotation.x, yRotation, fanTransform.rotation.z, fanTransform.rotation.w);
            //m_fanObject.m_fanMovement = new Vector3(m_fanObject.m_fanMovement.x, yRotation, m_fanObject.m_fanMovement.z);
            Debug.Log("entered");
        }
    }
}
