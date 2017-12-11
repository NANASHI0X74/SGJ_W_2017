using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{

    public Image bar;
    public float m_coolDown = 120.0f;
    public float counter = 0;


    public bool coolingDown;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime / 120.0f;
        if (counter <= 1.0f && coolingDown)
        {
            Debug.Log(counter);
            bar.fillAmount = counter;
        }
        else
        {
            counter = 0;
            coolingDown = false;
            bar.fillAmount = 0f;

        }
    }
}
