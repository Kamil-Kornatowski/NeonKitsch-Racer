using UnityEngine;
using UnityEngine.PlayerLoop;

public class CarRotation : MonoBehaviour
{
    public Quaternion originalRotation;
    float rotationSpeed = 30.0f;
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
        else
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

        //Function contains commented alternative way of applying rotation to the model, using smoother methods, but for now it has unsatisfactory results

        Vector3 rotationVector = new Vector3();
        //Quaternion rotationQuaternion = new Quaternion();

        if ((transform.rotation.eulerAngles.z < rotationClamp) || (transform.rotation.eulerAngles.z > (360f - rotationClamp)))
        {
            rotationVector += new Vector3(0f, 0f, turnSide * rotationSpeed);
            //rotationQuaternion = new Quaternion(0f, 0f, turnSide * rotationSpeed, 0f);

        }

        //transform.rotation = Quaternion.Slerp(transform.rotation, rotationQuaternion, Time.deltaTime);
        transform.eulerAngles += rotationVector;
    }

    
}
