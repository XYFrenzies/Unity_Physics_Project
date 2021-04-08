using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (m_hasCompletedFreeze)
            return;
        else
        {
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
