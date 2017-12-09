using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class AIFans : MonoBehaviour {

    public float m_deathDistance;
    private Transform m_thisTransform;
    private Rigidbody m_thisRigidbody;
    private Vector3 m_fanMovement;

    public Transform m_target;
    private NavMeshAgent m_navComponent;
    private Vector3 m_viewDirection;
    public float m_visionConeAngle;
    public float m_maxDistanceVC;
    private bool m_bVisible;
    public float m_fanSpeed;

    // Use this for initialization
    void Start () {
        //m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_thisTransform = this.GetComponent<Transform>();
        m_thisRigidbody = this.GetComponent<Rigidbody>();
        m_navComponent = this.GetComponent<NavMeshAgent>();
        m_navComponent.speed = m_fanSpeed;
        m_bVisible = false;
   

	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(m_target.position, m_thisTransform.position);
        m_fanMovement = m_thisTransform.forward * m_fanSpeed;
        m_thisRigidbody.velocity = m_fanMovement;


        if (m_target && m_bVisible)
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

        //Vision Cone
        m_viewDirection = m_thisTransform.forward;
        Vector3 targetVector = m_target.position - m_thisTransform.position;

        if (Vector3.Angle(targetVector, m_viewDirection) <= m_visionConeAngle && distance <= m_maxDistanceVC)
        {
            m_bVisible = true;
        }
        else
        {
            m_bVisible = false;
        }
    }
}
