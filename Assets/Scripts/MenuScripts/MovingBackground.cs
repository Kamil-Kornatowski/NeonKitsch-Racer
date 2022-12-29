using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    Vector3 moveVector = new Vector3(0, 0, 0.5f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        gameObject.transform.position -= moveVector;

        TurnOver();
    }

    void TurnOver()
    {
        if(gameObject.transform.position.z < -110f)
        {
            gameObject.transform.position = new Vector3(0f, 0f, 440f);
        }
    }
}
