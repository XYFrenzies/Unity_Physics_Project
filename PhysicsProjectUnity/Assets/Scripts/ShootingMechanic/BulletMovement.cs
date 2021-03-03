using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float m_movespeed = 300.0f;
    private Rigidbody m_rb = null;
    private bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
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
}
