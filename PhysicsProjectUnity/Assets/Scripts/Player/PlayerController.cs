using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0.001f, 5f)] private float m_MovementSpeed = 2.0f;
    [SerializeField] private float m_maxMoveSpeed = 5.0f;
    private Rigidbody m_rb = null;
    private InputManager m_controls;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponentInChildren<Rigidbody>();
        m_controls = new InputManager();
        m_controls.Player.Enable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = m_controls.Player.Movement.ReadValue<Vector2>();

        if (dir.x != 0 || dir.y != 0)
        {
            if (m_rb.velocity.magnitude > m_maxMoveSpeed)
            {
                m_rb.velocity = Vector3.ClampMagnitude(m_rb.velocity, m_maxMoveSpeed);
            }
            Vector3 input = transform.right * dir.x + transform.forward * dir.y;  //This is for the movement of the player in the certain direction.
            input *= m_MovementSpeed;
            input.y = m_rb.velocity.y;
            m_rb.velocity = input;

        }
    }
}
