using UnityEngine;
using UnityEngine.UIElements;

public class GameMenuScript : MonoBehaviour
{
    static int countDownValue = 3;
    int countTimer = 0;
    public RaceData raceData;
    public PlayerManager playerManager;
    Label points;
    Label speed;
    Label countDown;

    static bool needCountDown = true;


    //Audio clips
    public AudioSource source;
    public AudioClip countdownTick;
    public AudioClip countdownStart;

    private void Start()
    {
        
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        points = root.Q<Label>("Score");
        speed = root.Q<Label>("Speed");
        countDown = root.Q<Label>("CountDown");
     

        //variables ensuring proper game restart
        //T0D0: Reorganization of the variables and dependencies to make it more efficent and logical

        RaceData.raceStarted = false;
        RaceData.gameOver = false;
        Time.timeScale = 1.0f;
        needCountDown = true;
        countDownValue = 3;



    }

    // Update is called once per frame
    void Update()

    {

        if (RaceData.raceStarted == true)
        {
            points.text = "Score " + RaceData.playerScore.ToString();
            speed.text = "Speed " + raceData.playerSpeed.ToString();
        }
    }

    private void FixedUpdate()
    {

       
        
        if(needCountDown && countTimer >= 50)
        {
            
            CountDown();
            countTimer = 0;
        }

        countTimer++;
    }

    public void CountDown()
    {
        
        countDown.text = countDownValue.ToString();
        
        
        if(countDownValue == 0 )
        {
            countDown.text = "START!";
            source.PlayOneShot(countdownStart);
            RaceData.raceStarted = true;
            playerManager.EnableScripts();
        }

        if(countDownValue < 0)
        {
            needCountDown = false;
            countDown.visible= false;
           
           
        }


        if (countDownValue > 0)
        {
            source.PlayOneShot(countdownTick);
        }
        countDownValue--; 
        
    }



}
