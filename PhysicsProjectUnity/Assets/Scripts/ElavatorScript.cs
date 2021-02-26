using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ElavatorScript : MonoBehaviour
{
    [SerializeField] private Text m_txt = null;
    [SerializeField] private Animation m_anim = null;
    private bool elavatorStarted = false; 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                m_anim.Play();
                m_txt.text = "";
                elavatorStarted = true;
            }
            else if(elavatorStarted == false)
            {
                m_txt.text = "Press the 'P' button to start Elavator.";
            }
            if (m_anim.IsPlaying("LiftAnimMainScene") == false)
            {
                elavatorStarted = false;
            }

        }
    }
}
