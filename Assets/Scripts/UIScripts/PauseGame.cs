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
    DataPersistance.ScoreData bestScores;

    void Start()
    {
        bestScores = DataPersistance.ReadSavedData();


        //Declaration and initialization of bigger containers
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        pauseMenu = root.Q<VisualElement>("PauseMenu");
        gameOverMenu = root.Q<VisualElement>("GameOverMenu");

        //Buttons of PauseMenu
        resume = root.Q<Button>("Button_Resume");
        backToTrackSelection = root.Q<Button>("Button_BackToMenu");
        backToTrackSelection2 = root.Q<Button>("Button_BackToMenu2");
        exit = root.Q<Button>("Button_Exit");

        //Buttons of GameOverMenu
        restartGame = root.Q<Button>("Button_Restart");

        score = root.Q<Label>("Label_FinalScore");
       


        //Method subscription
        resume.clicked += () => ResumeTheGame();
        //T0D0: settings
        backToTrackSelection.clicked += () => BackToTheMenu();
        backToTrackSelection2.clicked += () => BackToTheMenu();
        exit.clicked += () => UIToolkitUtilities.ExitGame();

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
        
        if(RaceData.playerScore >= bestScores.SimpleLoopScore)
        {
            score.text = "High Score: " + RaceData.playerScore.ToString() + " ! " ;
            bestScores.SimpleLoopScore = RaceData.playerScore;
            DataPersistance.SaveScores(bestScores);

            
            gameOverMenu.visible = true;
            
            
          

            isPaused = true;
        }
        else
        {
            gameOverMenu.visible = true;
            score.text = "Score: " + RaceData.playerScore.ToString();
           
            isPaused = true;
        }
        
       

       
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

    public void BackToTheMenu() 
    {
        RaceData.raceStarted = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MenuScene");
    }




}
