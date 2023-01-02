using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float accelarationRate = 1f;
    [SerializeField]
    float baseAcceleration = 2f;
    [SerializeField]
    float maximumSpeed = 300;

    public float speed = 150;




    public Vector3 currentForward;


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

        
            rb.velocity = -transform.forward * speed * Time.deltaTime;
        
      
    }

    public void Accelerate()
    {
        if (speed < maximumSpeed)
        {
            speed += baseAcceleration + accelarationRate;
            //accelarationRate += 0.1f;
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

