using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{

    public Image bar;
    public float m_coolDown = 30.0f;
    public float counter = 0;


    public bool coolingDown;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter <= 1.0f && coolingDown)
        {
            bar.fillAmount = counter;
        }
        else
        {
            counter = 0;
            coolingDown = false;

        }
    }
}
