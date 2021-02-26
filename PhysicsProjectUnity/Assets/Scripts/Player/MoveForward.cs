using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float m_movespeed = 300.0f;
    [SerializeField] private Rigidbody m_rb = null;
    private bool isFiring = false;
    [SerializeField] private Transform shotPos = null;
    // Start is called before the first frame update
    void Start()
    {
        m_rb.isKinematic = true;
        m_rb.transform.position = shotPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            m_rb.gameObject.SetActive(true);
            m_rb.velocity = Vector3.zero;
            m_rb.transform.position = shotPos.position;
            m_rb.transform.rotation = shotPos.transform.rotation;
            m_rb.isKinematic = false;
            m_rb.AddForce(Camera.main.transform.forward * m_movespeed);
            isFiring = true;
            
        }
        if (!isFiring)
        {
            m_rb.transform.position = shotPos.position;
            m_rb.transform.rotation = shotPos.transform.rotation;
        }
   
    }
}
