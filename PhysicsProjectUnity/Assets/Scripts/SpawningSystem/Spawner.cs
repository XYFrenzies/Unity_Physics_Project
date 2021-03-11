using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnLoc = null;
    [SerializeField] private GameObject m_player = null;
    private float timer = 0;
    [SerializeField] [Range(0, 2.0f)]private float spawnTimer = 0.0f;
    public static Spawner sharedInstance;
    [HideInInspector] public static float enemiesInScene = 0;
    /// <summary>
    /// Creates a list of enemies.
    /// </summary>
   void Start()
    {
        sharedInstance = this;
    }
    /// <summary>
    /// This is a spawn timer to check how many enemies are spawning in the world. It also has a capacity of how many will spawn at a time.
    /// The enemies will spawn at a certain location, set to active and be added to the list of enemies.
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer >= spawnTimer)
        {
            if (RoundSystem.sharedInstance.maxSpawnInArea > enemiesInScene && RoundSystem.sharedInstance.enemiesRemaining > enemiesInScene)
            {
                GameObject obj = ObjectPooling.SharedInstance.GetPooledObject("Enemy");
                if (obj != null)
                {
                    Ragdoll rag = obj.gameObject.GetComponent<Ragdoll>();
                    obj.transform.position = spawnLoc.transform.position;
                    obj.transform.rotation = spawnLoc.transform.rotation;
                    rag.m_player = m_player;
                    obj.gameObject.SetActive(true);
                    enemiesInScene += 1;
                }
            }
            timer = 0;
        }
        else
        {
            timer += Time.fixedDeltaTime;
        }
    }
}
