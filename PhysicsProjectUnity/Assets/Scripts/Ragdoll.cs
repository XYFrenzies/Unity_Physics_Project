using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    [SerializeField] private float m_moveSpeed = 0;
    [SerializeField] private float m_ragDollSpeed = 10;
    [SerializeField] private Transform m_player = null;
    [SerializeField] private Rigidbody m_wB = null;
    private Animator animator = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    private bool isCollided = false;

    public bool RagdollOn
    {
        get { return !animator.enabled; }
        set
        {
            animator.enabled = !value;

            foreach (Rigidbody r in rigidbodies) 
            {
                r.isKinematic = !value;
                r.AddForce(m_wB.velocity * m_ragDollSpeed);

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
        if (!isCollided)
            transform.position = Vector3.MoveTowards(transform.position, m_player.position, m_moveSpeed * Time.deltaTime);
    }
}
