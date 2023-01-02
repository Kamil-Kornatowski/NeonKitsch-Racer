using UnityEngine;
using UnityEngine.UIElements;

public class PointsCounter : MonoBehaviour
{

    public Acceleration playerAcceleration;

    Label points;
    Label speed;

    //Temporary variables for testing
    int playerPoints;
    int timer = 0;

    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        points = root.Q<Label>("PointCounter");
        speed = root.Q<Label>("Speed");

        //Temporary for testing
        playerPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points.text = playerPoints.ToString();
        speed.text = "Speed " + playerAcceleration.speed.ToString();
    
    }

    private void FixedUpdate()
    {
        
        if (timer >= 100)
        {
            playerPoints += 1 * (int)playerAcceleration.speed;
            timer = 0;
        }
        else
        {
            timer++;
        }
        


    }

}
