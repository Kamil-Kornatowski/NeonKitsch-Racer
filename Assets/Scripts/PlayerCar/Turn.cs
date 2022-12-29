using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 20.0f;
    float rotationResetSpeed = 20.0f;
    float rotationClamp = 30.0f;
    float turnSpeed = 10.0f;

    float turnSide;

    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();   
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
        if (turnSide != 0)
        {
           
            RotateTheCar();
            TurnTheCar();
            

        }

    }

        public void GetBackOnTrack()
        {
            if (turnSide == 0)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * rotationResetSpeed);


            }

        }

        void RotateTheCar()
    {
        Vector3 rotationVector = new Vector3();

        if ((transform.rotation.eulerAngles.y < rotationClamp) || (transform.rotation.eulerAngles.y > (360f - rotationClamp)))
        {
            rotationVector += new Vector3(0f, 0f, turnSide * rotationSpeed);
        }

        if ((transform.rotation.eulerAngles.x < rotationClamp) || (transform.rotation.eulerAngles.x > (360f - rotationClamp)))
        {
            rotationVector += new Vector3(0f, turnSide * rotationSpeed, 0f);
        }


        transform.eulerAngles = rotationVector;
    }

    void TurnTheCar()
    {
        rb.AddRelativeForce(turnSpeed * -turnSide, 0f, 0f);
    }
    
}
