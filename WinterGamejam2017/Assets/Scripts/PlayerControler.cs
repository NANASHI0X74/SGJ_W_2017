using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CameraController))]
public class PlayerControler : MonoBehaviour {
        
        private int clothes = 5;
        public int clothesCounter
        {
                get
                {
                        return clothes;
                }
        }
        public Transform activePlayer;
        public float upwardThrowStrength = 10.0f;
        public float horizontalThrowStrength = 10.0f;
        public float kickback = 2.0f;
        public GameObject Clothes;
        private int floorMask;
        public float camRayLength = 500.0f;
        public float maxMoveSpeed = 100.0f;
        Vector3 movement;
        private Rigidbody mRigidbody;
        private Animator mAnimator;
        private CameraController camController;
        public bool m_bHasFired;
        public GameObject m_latestClothes;
	    // Use this for initialization
	    void Start () {
                camController = GetComponent<CameraController>();
                floorMask = LayerMask.GetMask("Floor");
                mRigidbody = this.GetComponent<Rigidbody>();
                mAnimator = GetComponentInChildren<Animator>();
                m_bHasFired = false;
                m_latestClothes = null;
	    }

        public void giveClothes()
        {
                if (clothes < 5)
                {
                        clothes++;
                        switchRightModelIn();
                }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
                float h = Input.GetAxisRaw("Horizontal");
                float v = Input.GetAxisRaw("Vertical");

                // Move the player around the scene.
                move(h, v);
                turn();
                shoot();

        }

        void shoot()
        {
                if (Input.GetButtonDown("Fire1") && clothesCounter > 0){
                        clothes--;
                        GameObject fired = Instantiate(Clothes, transform.position + transform.forward, transform.rotation);
                        fired.GetComponent<Rigidbody>().velocity = transform.forward * horizontalThrowStrength+ Vector3.up * upwardThrowStrength;
                        fired.GetComponent<ClothesBehavior>().setDisplayedItem(5 - clothes);
                        m_latestClothes = fired;
                        m_bHasFired = true;

                        mRigidbody.MovePosition(transform.position -transform.forward * kickback) ;
                        switchRightModelIn();
                }
        }

        private void switchRightModelIn()
        {
                activePlayer.gameObject.SetActive(false);

                activePlayer = transform.GetChild(clothes == 0 ? 4 : 5 - clothes);

                activePlayer.gameObject.SetActive(true);
        }

        void move(float h, float v)
        {
                movement.Set(h, 0f, v);

                // Normalise the movement vector and make it proportional to the speed per second.
                movement = movement.normalized * maxMoveSpeed * Time.fixedDeltaTime;

                // Move the player to it's current position plus the movement.
                mRigidbody.MovePosition(transform.position + movement);
                activePlayer.GetComponentInChildren<Animator>().SetFloat("Speed", movement.magnitude);
        }

        void turn()
        {
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Create a RaycastHit variable to store information about what was hit by the ray.
                RaycastHit floorHit;

                // Perform the raycast and if it hits something on the floor layer...
                if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
                {
                        // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                        Vector3 playerToMouse = floorHit.point - transform.position;

                        // Ensure the vector is entirely along the floor plane.
                        playerToMouse.y = 0f;

                        // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

                        // Set the player's rotation to this new rotation.
                        mRigidbody.MoveRotation(newRotation);
                        camController.updateFollow(floorHit.point);
                }else
                {
                        camController.updateFollow(transform.position);
                }
        }
}

