using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float accelarationRate = 0.1f;
    [SerializeField]
    float baseAcceleration = 2f;
    [SerializeField]
    int maximumSpeed = 30;

    public int MaximumSpeed
    {
        get { return maximumSpeed; }
        set { maximumSpeed = value;}
    }
   


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        KeepStraightPath();
        Accelerate();
        MoveForward();
        
    }


    public void MoveForward()
    {
        rb.AddRelativeForce(-transform.forward);
    }

    public void Accelerate()
    {
        if (rb.velocity.z < maximumSpeed)
        {
            rb.velocity += -gameObject.transform.forward * (baseAcceleration + accelarationRate);
            accelarationRate += 0.1f;
        }

        else
        {
            accelarationRate = 0f;
            rb.velocity = new Vector3(rb.velocity.x, 0, maximumSpeed);
        }
    }
    public void KeepStraightPath()
    {
        if (Input.GetAxis("Horizontal") == 0)
            rb.velocity = new Vector3(0, 0, rb.velocity.z);
        {

        }
    }
}
