using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    [SerializeField] public float m_moveSpeed = 0;
    //[SerializeField] public int startingHealth = 1;

    [SerializeField] public GameObject m_player = null;
    private Animator animator = null;
    [SerializeField]public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [HideInInspector]public bool isCollided = false;
    [HideInInspector]public bool isHit = false;
    [HideInInspector]public static Ragdoll sharedInheritance;
    private float m_timer = 0;
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
            m_timer += Time.fixedDeltaTime;
            if (m_timer >= 10.0f)
            {
                int value = Spawner.enemiesSpawning.Count;
                for (int i = 1; i < value; i++)
                {
                    if (gameObject == Spawner.enemiesSpawning[i - 1])
                    {
                        RagdollOn = false;
                        ReturnToNormal();
                        gameObject.SetActive(false);
                        Spawner.enemiesSpawning.RemoveAt(i - 1);
                        isCollided = false;                            
                        isHit = false;
                    }
                }
                m_timer = 0;
            }
        }
    }
    void ReturnToNormal() 
    {
        foreach (Rigidbody r in rigidbodies)
        {
            r.isKinematic = true;
            r.gameObject.tag = "Enemy";
        }
        m_moveSpeed += 1;
    }
}
