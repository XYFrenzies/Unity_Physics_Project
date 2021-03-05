using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElavatorScript : MonoBehaviour
{
    [SerializeField] private Text m_txt = null;
    [SerializeField] private Animation m_anim = null;
    [SerializeField] private int m_valueOfTrap = 500;
    private bool elavatorStarted = false;
    private bool isInTrigger = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && RoundSystem.sharedInstance.pointTotal >= m_valueOfTrap && isInTrigger == true)
        {
            m_anim.Play();
            m_txt.text = "";
            elavatorStarted = true;
        }
    }
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
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            m_txt.text = "";
            isInTrigger = false;
        }
    }
}
