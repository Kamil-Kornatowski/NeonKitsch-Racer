using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : MonoBehaviour
{

    [SerializeField]
    int speedBoostValue = 200;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Acceleration>().maximumSpeed += speedBoostValue;
        }
    }
}
