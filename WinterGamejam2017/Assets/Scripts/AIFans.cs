using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class AIFans : MonoBehaviour
{

    //GameObject neuerVC;

    public float m_deathDistance;
    private Transform m_thisTransform;
    private Rigidbody m_thisRigidbody;
    public Vector3 m_fanMovement;
    public GameObject[] m_kontrollStack;

    private Transform m_target;
    private NavMeshAgent m_navComponent;
    private Vector3 m_viewDirection;
    public float m_visionConeAngle;
    public float m_maxDistanceVC;
    private bool m_bVisible;
    public float m_fanSpeed;

    public float baseSpeed = 4.0f;
    public float speedIncrease = 0.7f;
    private bool m_bIsChasingClothing;

    //private Vector3 m_recentDirection;

    public PlayerControler m_pc;

    //public GameObject VC;

    // Use this for initialization
    void Start()
    {
        //m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_thisTransform = this.GetComponent<Transform>();
        m_thisRigidbody = this.GetComponent<Rigidbody>();
        m_navComponent = this.GetComponent<NavMeshAgent>();
        m_navComponent.speed = m_fanSpeed;
        m_bVisible = false;
        m_target = m_kontrollStack[Random.Range(0, m_kontrollStack.Length)].transform;
        //m_recentDirection = m_kontrollStack[Random.Range(0, m_kontrollStack.Length)].transform.position;

        //Debug.Log("New Destination: " + m_recentDirection);

        //neuerVC = GameObject.Instantiate(VC);

    }

    // Update is called once per frame
    void Update()
    {
        if (m_target != null)
        {
            float distance = Vector3.Distance(m_target.position, m_thisTransform.position);
            m_fanMovement = m_thisTransform.forward * m_fanSpeed;
        }

        // Random Control point
        if (m_target == null || Vector3.Distance(m_target.position, m_thisTransform.position) <= 3)
        {
            int rand = Random.Range(0, m_kontrollStack.Length);
            m_target = m_kontrollStack[rand].transform;
            m_navComponent.speed = m_fanSpeed;
            m_thisRigidbody.freezeRotation = false;
        }

        // Player
        if (m_bVisible)
        {
            m_target = m_pc.transform;
            m_navComponent.speed = m_fanSpeed;
            m_thisRigidbody.freezeRotation = false;

            if (Vector3.Distance(m_thisTransform.position, m_target.position) <= m_deathDistance)
            {
                m_navComponent.speed = 0.0f;
                m_thisRigidbody.freezeRotation = true;
                SceneManager.LoadScene("Death Screen");
            }
        }

        // Clothing
        if (m_pc.m_clothingList != null && m_pc.m_clothingList.Count > 0)
        {
            for (int i = 0; i < m_pc.m_clothingList.Count; i++)
            {
                if (Vector3.Distance(m_thisTransform.position, m_pc.m_clothingList[i].transform.position) <= m_maxDistanceVC)
                {
                    m_target = m_pc.m_clothingList[i].transform;

                    if (Vector3.Distance(m_thisTransform.position, m_target.position) <= m_deathDistance)
                    {
                        m_navComponent.speed = 0.0f;
                        m_thisRigidbody.freezeRotation = true;
                    }
                }
            }
        }

        m_navComponent.SetDestination(m_target.position);
        m_thisRigidbody.velocity = m_fanMovement;


        //Vision Cone

        m_viewDirection = m_thisTransform.forward;
            Vector3 targetVector = m_target.position - m_thisTransform.position;
            targetVector.y = 0;

            if (Vector3.Angle(targetVector, m_viewDirection) <= m_visionConeAngle && Vector3.Distance(m_thisTransform.position, m_target.position) <= m_maxDistanceVC)
            {
                m_bVisible = true;
            }
            else
            {
                m_bVisible = false;
            }

            //GameObject neuerVC = GameObject.Instantiate(VC);
            //neuerVC.transform.position = m_thisTransform.position;
            //VC.GetComponent<Transform>().localScale = new Vector3(m_maxDistanceVC, m_maxDistanceVC, 1);
        
    }
}


