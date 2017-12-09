using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesBehavior : MonoBehaviour {

        public float disappearTime = 15.0f;
        public Sprite sprite1;
        public Sprite sprite2;
        public Sprite sprite3;
        public Sprite sprite4;
        public Sprite sprite5;
        // Use this for initialization
        void Start () {
                Destroy(gameObject, disappearTime);
	    }
	
	// Update is called once per frame
	    void Update () {
		        
	    }
        public void setDisplayedItem(int i)
        {
                
                switch (i)
                {
                        case 1:
                                GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
                                break;
                        case 2:

                                GetComponentInChildren<SpriteRenderer>().sprite = sprite2;
                                break;
                        case 3:

                                GetComponentInChildren<SpriteRenderer>().sprite = sprite3;
                                break;
                        case 4:

                                GetComponentInChildren<SpriteRenderer>().sprite = sprite4;
                                break;
                        case 5:
                                GetComponentInChildren<SpriteRenderer>().sprite = sprite5;
                                break;
                        default:
                                GameObject.Instantiate(sprite5, transform);
                                break;
                }
        }
}
