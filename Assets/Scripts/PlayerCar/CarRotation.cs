using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarRotation : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 15.0f;
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
        
        
        // Reassigning original rotation to allow effective turning 
        originalRotation.y = transform.rotation.y;
        originalRotation.w = transform.rotation.w;

       
    }


    void FixedUpdate()
    {
        RotateTheCar();

      if (turnSide == 0)
      {
          ResetRotation();
      }

    }

    public void ResetRotation()
    {
       
        transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed);

    }

    void RotateTheCar()
    {
        Vector3 rotationVector = new Vector3();
       

        if ((transform.rotation.eulerAngles.z < rotationClamp) || (transform.rotation.eulerAngles.z > (360f - rotationClamp)))
        {

            
            rotationVector += new Vector3(0f, 0f, turnSide * rotationSpeed);


            //Debug
            Debug.Log(rotationVector);
        }

        transform.eulerAngles += rotationVector;
    }

    
}
