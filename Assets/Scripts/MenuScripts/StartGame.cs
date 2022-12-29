using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
 

    public void OnButtonClick()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Button pressed");
    }
}
