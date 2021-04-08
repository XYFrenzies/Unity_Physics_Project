using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenMat : MonoBehaviour
{
    [SerializeField] private Material m_mat = null;
    [SerializeField] private Material m_oriMat = null;
    private List<GameObject> m_enemyGameObjects = null;
    
    private void Start()
    {
        m_enemyGameObjects = ObjectPooling.SharedInstance.AllObjectsOfType("Enemy");

    }
    // Update is called once per frame
    void Update()
    {
        if (!TimeFrozenOverlay.sharedInstance.m_hasCompletedFreeze)
        {
            for (int i = 0; i <= m_enemyGameObjects.Count - 1; i++)
            {
                SkinnedMeshRenderer[] renderer = m_enemyGameObjects[i].GetComponentsInChildren<SkinnedMeshRenderer>();
                for (int j = 0; j <= renderer.Length - 1; j++)
                {
                    renderer[j].material = m_mat;
                }
            }
        }
        if (TimeFrozenOverlay.sharedInstance.freezeMatReturn)
        {
            TimeFrozenOverlay.sharedInstance.freezeMatReturn = false;
            for (int i = 0; i <= m_enemyGameObjects.Count - 1; i++)
            {
                SkinnedMeshRenderer[] renderer = m_enemyGameObjects[i].GetComponentsInChildren<SkinnedMeshRenderer>();
                for (int j = 0; j <= renderer.Length - 1; j++)
                {
                    renderer[j].material = m_oriMat;
                }
            }
        }

    }
}
