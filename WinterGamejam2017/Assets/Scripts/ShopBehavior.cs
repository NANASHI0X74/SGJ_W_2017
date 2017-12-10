using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehavior : MonoBehaviour {
        public bool providing = true;
        private float timerCooldown = 0;
        public float TimerCooldown
        {
                get { return timerCooldown; }
        }
        public float cooldown = 120.0f;
        private float timerActive = 0;
        public float active = 15.0f;
        private float timerGiveDelay = 0;
        public float giveDelay = 3.0f;
        public PlayerControler player;
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

        void OnTriggerEnter(Collider Other)
        {
                if (Other.gameObject.tag == "Player" && providing) {
                        player = Other.GetComponent<PlayerControler>();
                        player.giveClothes();
                        StartCoroutine(giveClothes());
                }
        }

        void OnTriggerExit(Collider Other)
        {
                if (Other.gameObject.tag == "Player")
                {
                        stopGivingClothes();
                }
        }

        void stopGivingClothes()
        {
                providing = false;
                timerCooldown = cooldown;
                StopCoroutine(giveClothes());
        }

        IEnumerator giveClothes()
        {
                yield return new WaitForSeconds(3.0f);
                player.giveClothes();
                StartCoroutine(giveClothes());
        }
}
