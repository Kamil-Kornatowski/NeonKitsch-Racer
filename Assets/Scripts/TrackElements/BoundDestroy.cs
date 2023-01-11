using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        RaceData.gameOver = true;
    }
}
