using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rb = null;
    [SerializeField] private float m_movespeed = 300.0f;
    private bool isFiring = false;
    //private Vector3 originalPos = Vector3.zero;
    public Transform shotPos;
    // Start is called before the first frame update
    void Start()
    {
        m_rb.GetComponent<Rigidbody>();
        m_rb.isKinematic = true;
        m_rb.transform.position = shotPos.position;
        //originalPos = new Vector3(m_rb.transform.position.x, m_rb.transform.position.y, m_rb.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) 
        {
            m_rb.velocity = Vector3.zero;
            m_rb.transform.position = shotPos.position;
            m_rb.isKinematic = false;
            m_rb.AddForce(Vector3.forward * m_movespeed);
            isFiring = true;
            
        }
        if (!isFiring)
            m_rb.transform.position = shotPos.position;        
    }
}
