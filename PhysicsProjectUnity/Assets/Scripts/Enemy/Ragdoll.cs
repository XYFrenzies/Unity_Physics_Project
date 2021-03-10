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
    [HideInInspector] public bool isRocket = false;
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
        if (!isCollided && isHit)
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
    bool isARigidBodyComponent(GameObject obj)
    {
        foreach (Rigidbody r in rigidbodies)
        {
            if (r.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// In the spawner script, we have a list of all enemies in the scene. We check if there is any in the scene. 
    /// If so it will loop from all the enemies within the list to find the specific one to this script.
    /// Once found the ragdoll affect will turn off, increase movement speed, removes from the list and adds to the points and the amount of enemies remaining.
    /// We later set the timer back to zero.
    /// </summary>
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isARigidBodyComponent(other.gameObject))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(other.transform.position.x, 0, other.transform.position.z) * -1 * m_moveSpeed);
            isInsideObj = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isARigidBodyComponent(other.gameObject))
        {
            isInsideObj = false;
        }
    }

}
