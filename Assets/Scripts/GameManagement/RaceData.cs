using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceData : MonoBehaviour
{
    public static bool raceStarted = false;
    public static bool gameOver = false;
    public Acceleration player;

    public int playerSpeed = 0;

    public static int playerScore = 0;

    int framesCounter = 0;

    private void Start()
    {
        //ensuring correct value of the score
        playerScore = 0;
    }


    private void Update()
    {
        GatherData();
        
    }


    private void FixedUpdate()
    {
        if(framesCounter >= 50)
        {
            AddPoints();
            framesCounter= 0;
        }
        else
        {
            framesCounter++;
        }
    }



    public void GatherData()
    {
        playerSpeed = (int)player.GetComponent<Acceleration>().speed;

        //Dividing data to be more informative to player
        playerSpeed /= 10;
    }

    public void AddPoints()
    {
        playerScore += 1 * playerSpeed;
    }

}
