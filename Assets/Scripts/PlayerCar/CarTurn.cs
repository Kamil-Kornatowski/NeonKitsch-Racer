using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurn : MonoBehaviour
{
    public float turnSpeed = 50.0f;
    void FixedUpdate()
    {

        float inputTurn = Input.GetAxis("Horizontal");

        if(inputTurn != 0)
        {
            transform.eulerAngles += new Vector3(0f, inputTurn * turnSpeed, 0f);
        }

    }
}
