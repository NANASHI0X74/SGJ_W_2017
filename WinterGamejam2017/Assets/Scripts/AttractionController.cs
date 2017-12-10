using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttractionController : MonoBehaviour {

    public PlayerControler m_pc;
    private int clouthesNumber;
    public Image filler;
    public Image Kleidung;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        clouthesNumber = m_pc.clothesCounter;
        filler.fillAmount = (float) clouthesNumber / 5.0f;
        Kleidung.fillAmount = 1.0f - (0.2f * clouthesNumber);
    }
}
