using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 4/3/2021
/// Last Modified: 9/4/2021
/// </summary>
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
