using UnityEngine;
using UnityEngine.PlayerLoop;

public class Turn : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 20.0f;
    float rotationResetSpeed = 20.0f;
    float rotationClamp = 30.0f;
    

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
    }


    void FixedUpdate()
    {
        if (turnSide != 0)
        {

            TurnTheCar();
            //RotateTheCar();
            
            
            

        }

    }
      private void LateUpdate()
    {
       

        GetBackOnTrack();
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

        if ((transform.rotation.eulerAngles.z < rotationClamp) || (transform.rotation.eulerAngles.z > (360f - rotationClamp)))
        {
            rotationVector += new Vector3(0f, 0f, turnSide * rotationSpeed);
        }

        if ((transform.rotation.eulerAngles.y < rotationClamp) || (transform.rotation.eulerAngles.y> (360f - rotationClamp)))
        {
            rotationVector += new Vector3(0f, turnSide * rotationSpeed, 0f);
            
        }


        transform.eulerAngles = rotationVector;
    }

    void TurnTheCar()
    {

        gameObject.transform.eulerAngles = new Vector3(0f, turnSide, 0f);
        //transform.RotateAround(transform.position, transform.up, turnSide);

        //transform.rotation = Quaternion.Euler(0f, turnSide, 0f);
    }
    
}
