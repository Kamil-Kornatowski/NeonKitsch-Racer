using UnityEngine;

public class Acceleration : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float accelarationRate = 1f;
    [SerializeField]
    float baseAcceleration = 2f;
    [SerializeField]
    float maximumSpeed = 1000;

    public float speed = 100;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //Applying basic movement to the car
        MoveForward();
        //Applying acceleration if needed
        Accelerate();

        //In progress code - ensuring that car won't be derailed by microchanges in velocity.y, need better solution!
        if(transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }

        
        
    }


    public void MoveForward()
    {

        
        //Transform.forward is negative because of pivot of the model
            rb.velocity = -transform.forward * speed * Time.deltaTime;
        
      
    }

    public void Accelerate()
    {
        if (speed < maximumSpeed)
        {
            speed += baseAcceleration + accelarationRate;
            
        }

     
    }
 
}

