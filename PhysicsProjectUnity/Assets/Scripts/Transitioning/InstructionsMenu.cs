using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 5/3/2021
/// Last Modified: 9/4/2021
/// </summary>
public class InstructionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_startMenu = null;
    [SerializeField] private GameObject m_instrucMenu = null;

    public void Instructions() 
    {
        //Setting the instructions menu to active.
        m_startMenu.SetActive(false);
        //_____________________________
        m_instrucMenu.SetActive(true);

    }

    public void BackToMainMenu() 
    {
        //Setting it back to the main menu
        m_startMenu.SetActive(true);
        //_____________________________
        m_instrucMenu.SetActive(false);
    }
}
