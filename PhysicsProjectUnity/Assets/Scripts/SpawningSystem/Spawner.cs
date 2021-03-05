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
    [HideInInspector] public static List<GameObject> enemiesSpawning = null;
   void Start()
    {
        sharedInstance = this;
        enemiesSpawning = new List<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer >= spawnTimer)
        {
            if (RoundSystem.sharedInstance.maxSpawnInArea > enemiesSpawning.Count && RoundSystem.sharedInstance.enemiesRemaining > enemiesSpawning.Count)
            {
                GameObject obj = ObjectPooling.SharedInstance.GetPooledObject("Enemy");
                if (obj != null)
                {
                    Ragdoll rag = obj.gameObject.GetComponent<Ragdoll>();
                    obj.transform.position = spawnLoc.transform.position;
                    obj.transform.rotation = spawnLoc.transform.rotation;
                    rag.m_player = m_player;
                    obj.gameObject.SetActive(true);
                    enemiesSpawning.Add(obj);
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
