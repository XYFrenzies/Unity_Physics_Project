using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 8/3/2021
/// Last Modified: 9/4/2021
/// </summary>
public class FrozenMat : MonoBehaviour
{
    [SerializeField] private Material m_mat = null;
    [SerializeField] private Material m_blueMat = null;
    [SerializeField] private Material m_darkMat = null;
    private List<GameObject> m_enemyGameObjects = null;
    private List<Material> m_meshRenderers = null;
    
    void Start()
    {
        //Gets the instance of all the enemies in the scene.
        //"Can be better optimised for having the ones only in the scene".
        m_enemyGameObjects = ObjectPooling.SharedInstance.AllObjectsOfType("Enemy");
        m_meshRenderers = new List<Material>();
        //Adds a preset material for the enemy.
        m_meshRenderers.Add(m_darkMat);
        m_meshRenderers.Add(m_blueMat);
        m_meshRenderers.Add(m_blueMat);
    }
    // Update is called once per frame
    void Update()
    {
        //Once the freeze occurs, the enemies change their materials, 
        //which include a joints mat and two other materials that are for the rest of the object.
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
        //When the frost is finished, return back to their original materials.
        if (TimeFrozenOverlay.sharedInstance.freezeMatReturn)
        {
            TimeFrozenOverlay.sharedInstance.freezeMatReturn = false;
            for (int i = 0; i <= m_enemyGameObjects.Count - 1; i++)
            {
                SkinnedMeshRenderer[] renderer = m_enemyGameObjects[i].GetComponentsInChildren<SkinnedMeshRenderer>();
                for (int j = 0; j <= renderer.Length - 1; j++)
                {
                    renderer[j].material = m_meshRenderers[j];
                }
            }
        }

    }
}
