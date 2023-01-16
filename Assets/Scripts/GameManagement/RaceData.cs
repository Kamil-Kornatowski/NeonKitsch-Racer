using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceData : MonoBehaviour
{
    public static bool raceStarted = false;
    public static bool gameOver = false;
    public Acceleration player;

    public int playerSpeed = 0;


    //T0D0: Encapsulation keep failing, giving value of 0 despite raceData gathering proper values
    //public int PlayerSpeed { get;}
    //public int PlayerScore { get;}



    public static int playerScore = 0;

 

    int raceTime;
    int playerFullLaps;

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
        

        
    }

    public void AddPoints()
    {
        playerScore += 1 * playerSpeed;
    }

}
