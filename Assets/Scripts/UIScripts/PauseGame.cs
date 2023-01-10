using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseGame : MonoBehaviour
{
    
    
    Button resume;
    Button settings;
    Button backToTrackSelection;
    Button exit;
    VisualElement pauseMenu;


    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        pauseMenu = root.Q<VisualElement>("PauseMenu");

        resume = root.Q<Button>("Button_Resume");
        settings = root.Q<Button>("Button_Settings");
        backToTrackSelection = root.Q<Button>("Button_BackToTrackSelection");
        exit = root.Q<Button>("Button_Exit");

        resume.clicked += () => ResumeTheGame();
        //settings.clicked+= () => ResumeTheGame();
        backToTrackSelection.clicked += () => BackToTheTrackSelection();
        exit.clicked += () => ExitTheGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {

            Debug.Log("Pause Menu ON!");
            PauseTheGame();
        }

       

    }

    public void PauseTheGame()
    {
        //RaceData.raceStarted = false;
        Time.timeScale= 0.0f;
        pauseMenu.visible = true;
        isPaused = true;

    }

    public void ResumeTheGame()
    {
        //RaceData.raceStarted = true;
        Time.timeScale= 1.0f;
        pauseMenu.visible = false;
        isPaused = false;
    
    }

    public void BackToTheTrackSelection() 
    {
        RaceData.raceStarted = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }

    public void ExitTheGame() 
    {
        Application.Quit();
    }


}
