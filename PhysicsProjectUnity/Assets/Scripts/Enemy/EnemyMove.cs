using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent nav = null;
    private GameObject player = null;
    private Ragdoll rag = null;
    // Start is called before the first frame update
    void Start()
    {
        rag = GetComponent<Ragdoll>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!TimeFrozenOverlay.sharedInstance.m_hasCompletedFreeze)
        {
            nav.enabled = false;
        }
        else if (!rag.isCollided && !rag.isHit && !rag.isTouchingObj)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
        }

        else if (rag.isCollided || rag.isHit)
        {
            //nav.acceleration = 0;
            nav.enabled = false;
        }
        
    }
}
