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
  
    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        gameSettings = root.Q<VisualElement>();
        Button left = gameSettings.Q<Button>("MapSelectionLeft");
        Button right = gameSettings.Q<Button>("MapSelectionRight");

    

        mapName = root.Q<Label>("MapName");
        mapDesc = root.Q<Label>("MapDesc");
        mapImage = root.Q<VisualElement>("MapImage");
       
        

        RefreshMapInfo(trackIndex);

        left.clicked += () => SubtractIndex();
        right.clicked += () => AddIndex();

        left.clicked += () => PlaySound();
        right.clicked += () => PlaySound();

        left.clicked += () => RefreshMapInfo(trackIndex);
        right.clicked += () => RefreshMapInfo(trackIndex);
    }

    public void RefreshMapInfo(int mapIndex)
    {
        mapName.text = trackBase[mapIndex].trackName;
        mapDesc.text = trackBase[mapIndex].trackDesc;
        StyleBackground tempImg = (StyleBackground)trackBase[trackIndex].trackImage;
        mapImage.style.backgroundImage = tempImg;
        
        

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
            trackIndex = minTrackIndex;
        }
    }

    void PlaySound()
    {
        source.PlayOneShot(click);
    }

}
