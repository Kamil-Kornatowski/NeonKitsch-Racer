using UnityEngine;
using UnityEngine.UIElements;

public class Counters : MonoBehaviour
{
   static int countDownValue = 3;
    int countTimer = 0;
    public RaceData raceData;
    public PlayerManager playerManager;
    Label points;
    Label speed;
    Label countDown;

    bool needCountDown = true;

    private void Start()
    {
        
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        points = root.Q<Label>("Score");
        speed = root.Q<Label>("Speed");
        countDown = root.Q<Label>("CountDown");


        countDownValue = 3;



    }

    // Update is called once per frame
    void Update()

    {

        if (RaceData.raceStarted == true)
        {
            points.text = "Score " + raceData.playerScore.ToString();
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
            RaceData.raceStarted = true;
            playerManager.EnableScripts();
        }

        if(countDownValue < 0)
        {
            needCountDown = false;
            countDown.visible= false;
           
           
        }

        countDownValue--;
        
    }



}
