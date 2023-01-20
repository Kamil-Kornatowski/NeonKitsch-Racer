using System;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettings : MonoBehaviour
{
    public AudioSource source;
    public AudioClip click;

    public Track[] trackBase = new Track[2];
    int trackIndex = 0;
    int maxTrackIndex = 2;
    int minTrackIndex = 0;

  

    VisualElement root;
    VisualElement gameSettings;
    VisualElement mapImage;

    Label mapName;
    Label mapDesc;
    Label mapHighScore;

    Button mapLeft;
    Button mapRight;

  
    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        gameSettings = root.Q<VisualElement>("GameSettings");
        mapLeft = gameSettings.Q<Button>("MapSelectionLeft");
        mapRight = gameSettings.Q<Button>("MapSelectionRight");

    

        mapName = root.Q<Label>("MapName");
        mapDesc = root.Q<Label>("MapDesc");
        mapImage = root.Q<VisualElement>("MapImage");
        mapHighScore = root.Q<Label>("HighScore");


        DataPersistance.ScoreData bestScores = DataPersistance.ReadSavedData();
        

        RefreshMapInfo(trackIndex, bestScores);


        

        mapLeft.clicked += () => SubtractIndex();
        mapRight.clicked += () => AddIndex();

        mapLeft.clicked += () => PlaySound();
        mapRight.clicked += () => PlaySound();

        mapLeft.clicked += () => RefreshMapInfo(trackIndex,bestScores);
        mapRight.clicked += () => RefreshMapInfo(trackIndex,bestScores);
    }

    public void RefreshMapInfo(int mapIndex, DataPersistance.ScoreData bestScores)
    {
        mapName.text = trackBase[mapIndex].trackName;
        mapDesc.text = trackBase[mapIndex].trackDesc;
        mapImage.style.backgroundImage = (StyleBackground)trackBase[mapIndex].trackImage;
        

        if (mapIndex == 0)
        {
            mapHighScore.text = "High Score: " + bestScores.SimpleLoopScore;
           
            
        }
        else
        {
            mapHighScore.text = "High Score: To be set!";
        }
        
        

    }

    public void AddIndex()
    {
        
        trackIndex++;

        if(trackIndex > maxTrackIndex)
        {
            trackIndex = minTrackIndex;
        }
    }

    public void SubtractIndex()
    {
        
        trackIndex--;

        if (trackIndex < minTrackIndex)
        {
            trackIndex = maxTrackIndex;
        }
    }

    void PlaySound()
    {
        source.PlayOneShot(click);
    }

   

}
