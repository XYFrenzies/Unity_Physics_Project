using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float m_movespeed = 300.0f;
    [SerializeField] private float explosiveForce = 100f;
    [SerializeField] public float explosiveRadius = 10f;
    private Rigidbody m_rb = null;
    private bool isShooting = false;
    public static RocketMovement sharedInstance;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        sharedInstance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShooting == false)
        {
            m_rb.AddForce(Camera.main.transform.forward * m_movespeed);
            isShooting = true;
        }
        else if (isShooting)
            m_rb.AddForce(transform.forward * m_movespeed);

    }
    private void OnTriggerEnter(Collider other)
    {
        m_rb.velocity = Vector3.zero;
        isShooting = false;
        m_rb.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_rb.velocity = Vector3.zero;
        m_rb.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
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
                        col[i].GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, m_rb.position, explosiveRadius);
                        rag.isCollided = false;
                        rag.isRocket = true;
                        rag.isHit = true;
                    }
                }
            }
        }
    }
}
