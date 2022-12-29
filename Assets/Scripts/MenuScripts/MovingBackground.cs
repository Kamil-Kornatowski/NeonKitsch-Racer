using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    Vector3 moveVector = new Vector3(0, 0, 0.5f);

   // Moving track backwards in FixedUpdate to ensure even movement
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
