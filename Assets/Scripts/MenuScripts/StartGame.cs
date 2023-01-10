using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    VisualElement root;
    VisualElement main;
    VisualElement gameSettings;
    

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;


        // Main Menu elements
        main = root.Q<VisualElement>("Buttons");
        Button buttonStart = root.Q<Button>("Start");
        Button buttonSettings = root.Q<Button>("Settings");
        Button buttonExit = root.Q<Button>("Exit");

        // Game Settings menu elements
        gameSettings = root.Q<VisualElement>("GameSettings");
       
        Button buttonBackFromGameSettings = root.Q<Button>("BackFromGameSettings");
        Button buttonTimeToRace = root.Q<Button>("TimeToRace");


        buttonStart.clicked += () => StartGameSettingsButton();
        buttonSettings.clicked += () => SettingsGameButton();
        buttonExit.clicked += () => ExitGameButton();

        buttonBackFromGameSettings.clicked += () => BackToMainMenu(gameSettings);
        buttonTimeToRace.clicked += () => TimeToRace();



        
    }

    public void StartGameSettingsButton()
    {

        ExchangeMenu(main, gameSettings);
        
        
    } 
    public void SettingsGameButton()
    {
          
    

    } 
    public void ExitGameButton()
    {
       //Exit for build
        Application.Quit();
       //Exit for debugging
        //UnityEditor.EditorApplication.isPlaying= false;
        
    }


    public void BackToMainMenu(VisualElement thisMenu)
    {
        ExchangeMenu(thisMenu, main);
    }

    public void TimeToRace()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExchangeMenu(VisualElement oldMenu, VisualElement newMenu)
    {
        oldMenu.visible = false;
        newMenu.visible = true;
    }



}
