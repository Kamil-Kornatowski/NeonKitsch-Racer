using UnityEngine;
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

        //Credits menu elements
        credits = root.Q<VisualElement>("Credits");
        Button buttonBackFromCredits = root.Q<Button>("BackFromCredits");


        //On click function assignation

        //Main Menu buttons functions
        buttonStart.clicked += () => UIToolkitUtilities.ExchangeMenu(main, gameSettings);
        // buttonSettings.clicked += () => SettingsGameButton();
        buttonCredits.clicked += () => UIToolkitUtilities.ExchangeMenu(main, credits);
        buttonExit.clicked += () => UIToolkitUtilities.ExitGame();



        //Sub-menus buttons functions
        buttonBackFromGameSettings.clicked += () => BackToMainMenu(gameSettings);
        buttonTimeToRace.clicked += () => UIToolkitUtilities.PlayTheGame();

        buttonBackFromCredits.clicked += () => BackToMainMenu(credits);

    }


    public void BackToMainMenu(VisualElement thisMenu)
    {
        thisMenu.visible= false;
        main.visible= true;
    }

 

 



}
