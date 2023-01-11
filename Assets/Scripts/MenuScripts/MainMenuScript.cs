using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    VisualElement root;
    VisualElement main;
    VisualElement gameSettings;
    VisualElement credits;

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;


        // Main Menu elements
        main = root.Q<VisualElement>("Buttons");
        Button buttonStart = root.Q<Button>("Start");
        //Button buttonSettings = root.Q<Button>("Settings");
        Button buttonCredits = root.Q<Button>("buttonCredits");
        Button buttonExit = root.Q<Button>("Exit");

        // Game Settings menu elements
        gameSettings = root.Q<VisualElement>("GameSettings");
       
        Button buttonBackFromGameSettings = root.Q<Button>("BackFromGameSettings");
        Button buttonTimeToRace = root.Q<Button>("TimeToRace");

        credits = root.Q<VisualElement>("Credits");
        Button buttonBackFromCredits = root.Q<Button>("BackFromCredits");

        buttonStart.clicked += () => ExchangeMenu(main, gameSettings);
        // buttonSettings.clicked += () => SettingsGameButton();
        buttonCredits.clicked += () => ExchangeMenu(main, credits);
        buttonBackFromCredits.clicked += () => BackToMainMenu(credits);
        buttonExit.clicked += () => ExitGameButton();

        buttonBackFromGameSettings.clicked += () => BackToMainMenu(gameSettings);
        buttonTimeToRace.clicked += () => TimeToRace();

        
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
        thisMenu.visible= false;
        main.visible= true;
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
