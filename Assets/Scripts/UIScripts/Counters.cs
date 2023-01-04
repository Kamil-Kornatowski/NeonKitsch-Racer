using UnityEngine;
using UnityEngine.UIElements;

public class Counters : MonoBehaviour
{

    public RaceData raceData;

    Label points;
    Label speed;


    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        points = root.Q<Label>("Score");
        speed = root.Q<Label>("Speed");

    }

    // Update is called once per frame
    void Update()

    {
     
        points.text = "Score " + raceData.playerScore.ToString();
        speed.text = "Speed " + raceData.playerSpeed.ToString();
    
    }



}
