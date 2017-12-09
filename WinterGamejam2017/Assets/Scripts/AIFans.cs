using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class AIFans : MonoBehaviour {

    public float m_deathDistance;
    private Transform m_thisTransform;
    private Rigidbody m_thisRigidbody;
    public Vector3 m_fanMovement;
    public GameObject[] m_kontrollStack;

    public Transform m_target;
    private NavMeshAgent m_navComponent;
    private Vector3 m_viewDirection;
    public float m_visionConeAngle;
    public float m_maxDistanceVC;
    private bool m_bVisible;
    public float m_fanSpeed;

    public GameObject VC;

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
        Vector3 recentDirection = Vector3.zero;
        


        if (m_bVisible)
        {
            //m_thisRigidbody.velocity = Vector3.zero;
            m_navComponent.SetDestination(m_target.transform.position);
            //Debug.Log("visible!");
            Debug.Log("distance: " + distance);

            if (distance <= m_deathDistance)
            {
                m_fanSpeed = 0.0f;
                m_navComponent.speed = 0.0f;
                //m_thisTransform.position = m_target.transform.position + new Vector3(0.5f, 0f, 0.5f);
                m_thisRigidbody.freezeRotation = true;
                //Debug.Log("stehen bleiben!");
                //m_navComponent.acceleration = 0f;
            }
        }
        else
        {
            for (int i = 0; i < m_kontrollStack.Length; i++)
            {
                if (Vector3.Distance(m_kontrollStack[i].transform.position, m_thisTransform.position) <= 15)
                {
                    m_navComponent.SetDestination(m_kontrollStack[i].transform.position);
                    //m_kontrollStack[i].transform.position = recentDirection;
                }
            }
            //m_navComponent.SetDestination(m_thisTransform.forward);
            m_thisRigidbody.velocity = m_fanMovement;
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

            VC.GetComponent<Transform>().localScale = new Vector3(m_maxDistanceVC, m_maxDistanceVC, 1);
    }
}
