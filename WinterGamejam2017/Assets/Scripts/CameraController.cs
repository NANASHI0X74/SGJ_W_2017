using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

        public float camBias = 0.1f;
        public float verticalDistance = 50.0f;
        public float smooth = 0.9f;
        public Camera followingCam;
        private Vector3 followPosition;

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
                followingCam.transform.position = Vector3.Lerp(followingCam.transform.position, followPosition, smooth);
	    }

        public void updateFollow(Vector3 mousePosition)
        {
                followPosition = Vector3.Lerp(transform.position, mousePosition, camBias) + Vector3.up * verticalDistance;
        }

}
