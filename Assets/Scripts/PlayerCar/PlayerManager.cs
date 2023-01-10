using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Acceleration accScript;
    CarTurn turScript;
    CarRotation rotScript;

    private void Start()
    {
        accScript = GetComponent<Acceleration>();
        turScript = GetComponent<CarTurn>();
        rotScript = GetComponent<CarRotation>();
    }
    public void EnableScripts()
    {
        accScript.enabled = true;
        turScript.enabled = true;
        rotScript.enabled = true;   

    }
}
