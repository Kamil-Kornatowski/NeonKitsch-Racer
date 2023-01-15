using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public static class UIToolkitUtilities
{

    public static void PlayTheGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public static void ExitGame()
    {
        //Exit for build
        Application.Quit();
        //Exit for debugging
        //UnityEditor.EditorApplication.isPlaying= false;

    }

    public static void ExchangeMenu(VisualElement oldMenu, VisualElement newMenu)
    {
        oldMenu.visible = false;
        newMenu.visible = true;
    }
}
