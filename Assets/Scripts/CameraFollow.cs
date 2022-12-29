using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   

    Transform cam;
    public Transform player;
    Vector3 offset = new Vector3(0f, 2f, 10f);


    private void Start()
    {
        cam = gameObject.transform;
       
    }

    void Update()
    {
        cam.transform.position = player.position + offset;
        
    }
}
