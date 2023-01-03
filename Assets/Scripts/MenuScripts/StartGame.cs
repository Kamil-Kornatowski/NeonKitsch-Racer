using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    VisualElement root;
    Button start;

    private void Start()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Button buttonStart = root.Q<Button>("Start");
        Button buttonSettings = root.Q<Button>("Settings");
        Button buttonExit = root.Q<Button>("Exit");


        buttonStart.clicked += () => StartGameButton();
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("GameScene");
        
    } 
    public void SettingsGameButton()
    {
       //Settings menu enable
    } 
    public void ExitGameButton()
    {
       Application.Quit();
        
    }


}
