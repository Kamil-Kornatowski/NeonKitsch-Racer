using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{

    public int points = 0;

    TMP_Text pointsCounter;
    
    void Start()
    {
        pointsCounter = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        points++;
        pointsCounter.text = points.ToString();

        
    }
}
