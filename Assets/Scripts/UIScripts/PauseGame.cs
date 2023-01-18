using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseGame : MonoBehaviour
{
    
    Button resume;
    Button backToTrackSelection;
    Button backToTrackSelection2;
    Button exit;

    Button restartGame;
    Label score;

    VisualElement pauseMenu;
    VisualElement gameOverMenu;
    public bool isPaused = false;

    void Start()
    {
       //Declaration and initialization of bigger containers
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        pauseMenu = root.Q<VisualElement>("PauseMenu");
        gameOverMenu = root.Q<VisualElement>("GameOverMenu");

        //Buttons of PauseMenu
        resume = root.Q<Button>("Button_Resume");
        //settings = root.Q<Button>("Button_Settings");
        backToTrackSelection = root.Q<Button>("Button_BackToTrackSelection");
        backToTrackSelection2 = root.Q<Button>("Button_BackToTrackSelection2");
        exit = root.Q<Button>("Button_Exit");

        //Buttons of GameOverMenu
        restartGame = root.Q<Button>("Button_Restart");

        score = root.Q<Label>("Label_FinalScore");


        //Method subscription
        resume.clicked += () => ResumeTheGame();
        //T0D0: settings
        backToTrackSelection.clicked += () => BackToTheTrackSelection();
        backToTrackSelection2.clicked += () => BackToTheTrackSelection();
        exit.clicked += () => ExitTheGame();

        restartGame.clicked += () => RestartGame();
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {

            Debug.Log("Pause Menu ON!");
            PauseTheGame();
        }

        if (RaceData.gameOver)
        {
            GameOver();
        }
    }

    //Definitions of methods used in Pasue and GameOver Menu
    public void PauseTheGame()
    {
        
        
        Time.timeScale= 0.0f;
        pauseMenu.visible = true;
        isPaused = true;

    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        score.text = "Score: " + RaceData.playerScore.ToString();
        gameOverMenu.visible = true;
        isPaused = true;
    }

    public void ResumeTheGame()
    {
        
        
        Time.timeScale= 1.0f;
        pauseMenu.visible = false;
        isPaused = false;
    
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(1);
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
