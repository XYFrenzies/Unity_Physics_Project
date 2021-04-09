using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 26/2/2021
/// Last Modified: 9/4/2021
/// </summary>
public class ElavatorScript : MonoBehaviour
{
    [SerializeField] private Text m_txt = null;
    [SerializeField] private Animation m_anim = null;
    [SerializeField] private int m_valueOfTrap = 500;
    private bool elavatorStarted = false;
    private bool isInTrigger = false;
    /// <summary>
    /// For every update it checks if the player has collected enough points, have pressed the e key and if they are within the trigger.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && RoundSystem.sharedInstance.pointTotal >= m_valueOfTrap && isInTrigger == true)
        {
            RoundSystem.sharedInstance.pointTotal -= m_valueOfTrap;
            m_anim.Play();
            m_txt.text = "";
            elavatorStarted = true;
        }
    }
    /// <summary>
    /// When the player is within the trigger, the player will be told whether they have enough points to access the elavator or not.
    /// If the animation is not playing anymore, the player is able to purchase it again.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            isInTrigger = true;
            if(elavatorStarted == false)
            {
                if (RoundSystem.sharedInstance.pointTotal < m_valueOfTrap)
                    m_txt.text = "Press the 'E' button to start Elavator. Need " + (m_valueOfTrap - RoundSystem.sharedInstance.pointTotal).ToString();
                else if(RoundSystem.sharedInstance.pointTotal >= m_valueOfTrap)
                    m_txt.text = "Press the 'E' button to start Elavator.";
            }
            if (m_anim.IsPlaying("LiftAnimMainScene") == false)
            {
                elavatorStarted = false;
            }

        }
    }
    /// <summary>
    /// When they are out of the trigger, the text is set back to nothing.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            m_txt.text = "";
            isInTrigger = false;
        }
    }
}
