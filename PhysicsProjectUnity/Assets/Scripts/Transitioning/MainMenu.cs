using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Simple menu design to start the scene and quit the application.
    /// </summary>
    /// <param name="level"></param>
    public void MainMenuGame(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void ExitGame() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
