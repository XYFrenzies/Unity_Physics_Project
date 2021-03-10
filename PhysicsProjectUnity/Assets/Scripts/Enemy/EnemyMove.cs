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
        if(!rag.isCollided && !rag.isHit && !rag.isTouchingObj)
            nav.SetDestination(player.transform.position);
    }
}
