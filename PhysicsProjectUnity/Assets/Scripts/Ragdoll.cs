using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 0;

    [SerializeField] public GameObject m_player = null;
    private Animator animator = null;
    [SerializeField]public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [HideInInspector]public bool isCollided = false;
    [HideInInspector]public bool isHit = false;
    [HideInInspector]public static Ragdoll sharedInheritance;

    public bool RagdollOn
    {
        get { return !animator.enabled; }
        set
        {
            animator.enabled = !value;

            foreach (Rigidbody r in rigidbodies) 
            {
                r.isKinematic = !value;
            }
            isCollided = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
        foreach (Rigidbody r in rigidbodies)
        {
            r.isKinematic = true;
            r.gameObject.tag = "Enemy";
        }
    }

    void Update()
    {
        if (!isCollided && !isHit)
            transform.position = Vector3.MoveTowards(transform.position, m_player.transform.position, m_moveSpeed * Time.deltaTime);
        else
        {

        }
    }
}
