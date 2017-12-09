using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIFans : MonoBehaviour {

    public float m_deathDistance;
    public Transform m_thisObject;
    public Transform m_target;
    private NavMeshAgent m_navComponent;

    // Use this for initialization
    void Start () {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_navComponent = this.GetComponent<NavMeshAgent>();
   

	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(m_target.position, m_thisObject.position);

        if (m_target)
        {
            m_navComponent.SetDestination(m_target.position);
        }
        else
        {
            if (m_target == null)
            {
                //do nothing
            }
        }

        if (distance == m_deathDistance)
        {
            //GameOver
        }
	}
}
