using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenMat : MonoBehaviour
{
    [SerializeField] private Material m_mat = null;
    private Material m_savedMaterial = null;
    private Material m_currentMat = null;

    private void Start()
    {
        
        m_savedMaterial = GetComponent<Renderer>().material;
        m_currentMat = GetComponent<Renderer>().material;
    }
    // Update is called once per frame
    void Update()
    {
        if (!TimeFrozenOverlay.sharedInstance.m_hasCompletedFreeze)
        {
            m_currentMat = m_mat;
        }
        else
            m_currentMat = m_savedMaterial;
    }
}
