using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    public Text m_text;
    public int m_highscore;
    float counter;

	// Use this for initialization
	void Start () {
        counter = 0;
	}

    // Update is called once per frame
    void Update () {
        counter += Time.deltaTime;
        m_highscore = (int)counter;
        string score = m_highscore.ToString();
       m_text = m_text.GetComponent<Text>();
       m_text.text = "Highscore: " + score;
    }

    public int getHighscore()
    {
        return m_highscore;
    }
}