using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private Rigidbody m_rb = null;
    [SerializeField] private float speed = 10.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            m_rb.AddForce(Vector3.forward * speed);
        }
    }
}
