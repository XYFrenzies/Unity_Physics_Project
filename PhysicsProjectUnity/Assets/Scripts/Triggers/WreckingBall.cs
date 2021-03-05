using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WreckingBall : MonoBehaviour
{
    [SerializeField] private Text m_txt = null;
    [SerializeField] private int m_valueOfTrap = 500;
    [SerializeField] private Rigidbody[] rigidbodies = null;
    [SerializeField] private float m_timerForTrap = 10f;
    [SerializeField] private float explosiveForce = 100;
    [SerializeField] public float explosiveRadius = 10;
    private Vector3[] obj;
    private bool wBStarted = false;
    private bool isInTrigger = false;
    private float timer = 0;
    public static WreckingBall sharedInstance;

    void Start()
    {
        sharedInstance = this;
        obj = new Vector3[rigidbodies.Length];
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            obj[i] = rigidbodies[i].gameObject.transform.position;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && RoundSystem.sharedInstance.pointTotal >= m_valueOfTrap && isInTrigger == true)
        {
            foreach(Rigidbody rb in rigidbodies)
            {
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            m_txt.text = "";
            wBStarted = true;
        }

        if (wBStarted)
        {
            timer += Time.fixedDeltaTime;
            if (m_timerForTrap <= timer)
            {
                for (int i = 0; i < rigidbodies.Length; i++)
                {
                    rigidbodies[i].gameObject.transform.position = obj[i];
                }
                foreach (Rigidbody rb in rigidbodies)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    rb.isKinematic = true;
                }
                wBStarted = false;
                timer = 0;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            isInTrigger = true;
            if (wBStarted == false)
            {
                if (RoundSystem.sharedInstance.pointTotal < m_valueOfTrap)
                    m_txt.text = "Press the 'E' button to start Wrecking Ball. Need " + (m_valueOfTrap - RoundSystem.sharedInstance.pointTotal).ToString();
                else if (RoundSystem.sharedInstance.pointTotal >= m_valueOfTrap)
                    m_txt.text = "Press the 'E' button to start Wrecking Ball.";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerController>())
        {
            m_txt.text = "";
            isInTrigger = false;
        }
    }
    public void MultiForce(Collider[] col)
    {
        for (int i = 0; i < col.Length; i++)
        {
            if (col[i].gameObject.CompareTag("Enemy"))
            {
                Ragdoll rag = col[i].GetComponentInParent<Ragdoll>();
                rag.RagdollOn = true;
                if (rag.isCollided == true && rag.isHit == false)
                {
                    foreach (Rigidbody rb in rag.rigidbodies)
                    {
                        col[i].GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, rigidbodies[8].position, explosiveRadius);
                        rag.isCollided = false;
                        rag.isRocket = true;
                        rag.isHit = true;
                    }
                }
            }
        }
    }
}
