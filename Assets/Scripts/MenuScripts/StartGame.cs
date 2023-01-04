using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    VisualElement root;
   

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonStart = root.Q<Button>("Start");
        Button buttonSettings = root.Q<Button>("Settings");
        Button buttonExit = root.Q<Button>("Exit");


        buttonStart.clicked += () => StartGameButton();
        buttonSettings.clicked += () => SettingsGameButton();
        buttonExit.clicked += () => ExitGameButton();
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("GameScene");
        
    } 
    public void SettingsGameButton()
    {

        
       //Settings menu enable
       /* T0D0:
        Player should be able to change:
       - resolution
       - audio volume ( master, effects, music )
        
        */

    } 
    public void ExitGameButton()
    {
       //Exit for build
        Application.Quit();
       //Exit for debugging
        UnityEditor.EditorApplication.isPlaying= false;
        
    }


}
