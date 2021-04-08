using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    [SerializeField] public float m_moveSpeed = 0;
    [SerializeField] public GameObject m_player = null;
    private Animator animator = null;
    [SerializeField] public List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [HideInInspector] public bool isCollided = false;
    [HideInInspector] public bool isHit = false;
    [HideInInspector] public bool hasSpawnedThisRound = false;
    [HideInInspector] public bool hasAlreadySpawned = false;
    [HideInInspector] public bool isTouchingObj = false;
    [HideInInspector] public static Ragdoll sharedInheritance;
    private float m_timer = 0;
    [HideInInspector] public bool isInsideObj = false;
    [HideInInspector] public GameObject objOther = null;
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
    /// <summary>
    /// Through the update, if the player is not hit or colliding with the player 
    /// (and for extra security as we are using a character controller) or if its not within the sphere radius, move towards the player.
    /// Else a tiemr continues to increase to give the ragdoll affect when the enemies get hit by a projectile.
    /// Once it is larger than the preset amount, it will go into removing the ragdoll from scene.
    /// </summary>
    void FixedUpdate()
    {
        if (isCollided && isHit)
        {
            m_timer += Time.fixedDeltaTime;
            if (m_timer >= 3.0f)
                RemoveRagdollFromScene();
        }

    }
    /// <summary>
    /// This is reseting the enemy to be kinematic.
    /// </summary>
    void ReturnToNormal()
    {
        foreach (Rigidbody r in rigidbodies)
        {
            r.isKinematic = true;
            r.gameObject.tag = "Enemy";
        }

    }
    /// <summary>
    /// In the spawner script, we have a list of all enemies in the scene. We check if there is any in the scene. 
    /// If so it will loop from all the enemies within the list to find the specific one to this script.
    /// Once found the ragdoll affect will turn off, increase movement speed, removes from the list and adds to the points and the amount of enemies remaining.
    /// We later set the timer back to zero.
    /// </summary>
    void RemoveRagdollFromScene()
    {
        RagdollOn = false;
        ReturnToNormal();
        m_moveSpeed += 1;
        isCollided = false;
        isHit = false;
        if (RoundSystem.sharedInstance.doublePoints)
            RoundSystem.sharedInstance.pointTotal += 10 * 2;
        else
            RoundSystem.sharedInstance.pointTotal += 10;
        RoundSystem.sharedInstance.enemiesRemaining -= 1;
        gameObject.SetActive(false);
        Spawner.enemiesInScene -= 1;
        m_timer = 0;
    }

}
