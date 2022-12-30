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

    int speed = 10;

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
        //KeepStraightPath();
        MoveForward();
        Accelerate();
        if(transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        
    }


    public void MoveForward()
    {
        //transform.Translate((-transform.forward + rb.velocity) * Time.deltaTime);

        rb.AddRelativeForce(-transform.forward);
    }

    public void Accelerate()
    {
        if (rb.velocity.z > MaximumSpeed)
        {
            rb.velocity += transform.forward * (baseAcceleration + accelarationRate);
            accelarationRate += 0.1f;
        }

        else
        {
            accelarationRate = 0f;
            rb.velocity = new Vector3(rb.velocity.x, 0, -MaximumSpeed);
        }
    }
    public void KeepStraightPath()
    {
        if (Input.GetAxis("Horizontal") == 0)
            rb.velocity = new Vector3(0f, 0f, rb.velocity.z);
        {

        }
    }
}

