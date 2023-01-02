using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarRotation : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 50.0f;

    float rotationClamp = 10.0f;
    

    float turnSide;

    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();   
        originalRotation = transform.rotation;
    }


    void Update()
    {
        turnSide = Input.GetAxis("Horizontal");
        originalRotation.y = transform.rotation.y;
        originalRotation.w = transform.rotation.w;
    }


    void FixedUpdate()
    {
        if (turnSide != 0)
        {

        
            RotateTheCar();
              
            
            
            

        }
        GetBackOnTrack();

    }

        public void GetBackOnTrack()
        {
            if (turnSide == 0)
            {

                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime);


            }

            

        }

    void RotateTheCar()
    {
        Vector3 rotationVector = new Vector3();

        if ((transform.rotation.eulerAngles.z < rotationClamp) || (transform.rotation.eulerAngles.z > (360f - rotationClamp)))
        {
            rotationVector += new Vector3(0f, 0f, turnSide * rotationSpeed);
        }

    

        transform.eulerAngles += rotationVector;
    }

    
}
