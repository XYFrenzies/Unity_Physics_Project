using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 8/4/2021
/// Last Modified: 9/4/2021
/// </summary>
/// This class determines the amount of time that the frost overlay occurs.
public class TimeFrozenOverlay : MonoBehaviour
{
    
    [SerializeField] [Range(0.01f, 1.0f)] private float m_frozenEffectPower = 0.5f;
    [SerializeField] private float m_freezingLengthTimer = 2.0f; 
    [SerializeField] private Material m_mat = null;
    private float m_freezeTimer = 0;
    public static TimeFrozenOverlay sharedInstance = null;
    [HideInInspector] public bool m_hasCompletedFreeze = true;
    [HideInInspector] public bool freezeMatReturn = false;

    void Start()
    {
        sharedInstance = this;
    }

    private void Update()
    {
        //Early exit if the freeze effect isnt occuring.
        if (m_hasCompletedFreeze)
            return;
        else
        {
            //If it is, the frost effect is set to a preset amount and a timer goes depending on deltaTime.
            //Once the timer is finished, the frost will disappear.
            m_mat.SetFloat("_Amount", m_frozenEffectPower);
            m_freezeTimer += Time.deltaTime;
            if (m_freezeTimer > m_freezingLengthTimer)
            {
                m_mat.SetFloat("_Amount", 0);
                m_hasCompletedFreeze = true;
                m_freezeTimer = 0;
                freezeMatReturn = true;
            }
        }
    }
}
