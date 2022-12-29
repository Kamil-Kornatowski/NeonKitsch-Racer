using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public GameObject turnCenter;


    public Quaternion originalRotation;
    float rotationSpeed = 10.0f;
    float rotationResetSpeed = 20.0f;
    float rotationClamp = 30.0f;

    float turnSide;

   // Rigidbody rb;

    void Start()
    {
        
        //rb = GetComponent<Rigidbody>();
        originalRotation = transform.rotation;
    }

    // Update is called once per frame

    private void Update()
    {
        turnSide = Input.GetAxis("Horizontal");

        GetBackOnTrack();
    }


    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            

            if ((transform.rotation.eulerAngles.y < rotationClamp) || (transform.rotation.eulerAngles.y > (360f - rotationClamp)))
            {
                transform.Rotate(0f, 0f, 0.1f * (turnSide * rotationSpeed));
            }

            if ((transform.rotation.eulerAngles.x < rotationClamp) || (transform.rotation.eulerAngles.x > (360f - rotationClamp)))
            {
                transform.Rotate(0f, 0.1f * (turnSide * rotationSpeed), 0f);
            }

        }

        
    }

    public void GetBackOnTrack()
    {
        if(Input.GetAxis("Horizontal") == 0) 
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation,Time.deltaTime * rotationResetSpeed);
            

        }

    }
}
