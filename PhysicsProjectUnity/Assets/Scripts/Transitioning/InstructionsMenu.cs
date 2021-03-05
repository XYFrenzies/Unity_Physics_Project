using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject m_startMenu;
    [SerializeField] private GameObject m_instrucMenu;

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
