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
    [SerializeField] public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [HideInInspector] public bool isCollided = false;
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool isRocket = false;
    [HideInInspector] public bool hasSpawnedThisRound = false;
    [HideInInspector] public bool hasAlreadySpawned = false;
    [HideInInspector] public bool isTouchingObj = false;
    [HideInInspector] public static Ragdoll sharedInheritance;
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

    void FixedUpdate()
    {
        if (!isCollided && !isHit)
        {
            if (!isTouchingObj)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(m_player.transform.position.x, 0, m_player.transform.position.z), m_moveSpeed * Time.fixedDeltaTime);
        }

        else
        {
            m_timer += Time.fixedDeltaTime;
            if (m_timer >= 3.0f && !isRocket)
            {
                RemoveRagdollFromScene();

            }
            else if (m_timer >= 8.0f)
            {
                RemoveRagdollFromScene();
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
        
    }

    void RemoveRagdollFromScene() 
    {
        int value = Spawner.enemiesSpawning.Count;
        for (int i = 1; i < value; i++)
        {
            if (gameObject == Spawner.enemiesSpawning[i - 1])
            {
                RagdollOn = false;
                ReturnToNormal();
                m_moveSpeed += 1;
                gameObject.SetActive(false);
                Spawner.enemiesSpawning.RemoveAt(i - 1);
                isCollided = false;
                isHit = false;
                RoundSystem.sharedInstance.pointTotal += 10;
                RoundSystem.sharedInstance.enemiesRemaining -= 1;
                isRocket = false;
            }
        }
        if (value == 1)
        {
            RagdollOn = false;
            ReturnToNormal();
            m_moveSpeed += 1;
            gameObject.SetActive(false);
            Spawner.enemiesSpawning.RemoveAt(0);
            isCollided = false;
            isHit = false;
            RoundSystem.sharedInstance.pointTotal += 10;
            RoundSystem.sharedInstance.enemiesRemaining -= 1;
            isRocket = false;
        }
        m_timer = 0;
    }
}
