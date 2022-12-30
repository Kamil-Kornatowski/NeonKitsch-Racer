using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
   

    Transform cam;
    public Transform player;
    Vector3 offset = new Vector3(0f, 2f, 10f);


    private void Start()
    {
        cam = gameObject.transform;
        offset += new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
       
    }

    void Update()
    {
       
        //cam.transform.position = player.position + offset;

        Vector3 relativePos = player.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(-player.transform.forward, Vector3.up);
        cam.transform.rotation = rotation;


    }
}
