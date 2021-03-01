using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform prefab = null;
    [SerializeField] private Transform spawnLoc = null;
    [SerializeField] private GameObject m_player = null;
    private float timer = 0;
    [SerializeField] [Range(0, 2.0f)]private float spawnTimer = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnTimer)
        {
            Transform obj = Instantiate(prefab, spawnLoc.position, Quaternion.identity);
            obj.gameObject.GetComponent<Ragdoll>().m_player = m_player;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
