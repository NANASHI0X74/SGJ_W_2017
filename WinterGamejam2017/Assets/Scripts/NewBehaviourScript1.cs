using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {
        public bool providing = true;
        private float timerCooldown = 0;
        public float cooldown = 15.0f;
        private float timerGiveDelay = 0;
        public float giveDelay = 3.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	    void Update () {
		        if(timerCooldown > 0)
                {
                        timerCooldown -= Time.deltaTime;
                }else
                {
                        providing = true;
                }
                if (timerGiveDelay <= 0)
                {
                        timerGiveDelay = giveDelay;
                }
        }

        void startGivingClothes(PlayerControler player)
        {
                timerGiveDelay = 3.0f;
        }
}
