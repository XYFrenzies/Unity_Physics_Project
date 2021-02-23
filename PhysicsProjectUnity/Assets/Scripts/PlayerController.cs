using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0.001f, 5f)] private float m_MovementSpeed = 2.0f;
    [SerializeField] [Range(0.1f, 1f)] private float m_smoothTurnSpeed = 1.5f;
    [SerializeField] private float m_maxMoveSpeed = 5.0f;
    [SerializeField] private Transform m_cam;
    [SerializeField] private Rigidbody m_rb;
    private InputManager m_controls;

 
    private float m_smoothVel;

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
            //This is for the movement of the player in the certain direction.
            Vector3 input = new Vector3(dir.x, 0f, dir.y).normalized;

            if (input.magnitude >= 0.1f)
            {
                float tarAngle = (float)Math.Atan2(input.x, input.z) * Mathf.Rad2Deg + m_cam.transform.eulerAngles.y;//Finds the targtet angle thats neede for the movement in reltation to the cameras direction.
                float angle = Mathf.SmoothDampAngle(m_rb.transform.eulerAngles.y, tarAngle, ref m_smoothVel, m_smoothTurnSpeed);//Rotates at a certain rate.
                m_rb.transform.rotation = Quaternion.Euler(0f, angle, 0f);//Rotates to the directuon of the angle.

                Vector3 moveNewDir = Quaternion.Euler(0f, tarAngle, 0f) * Vector3.forward;//Moves in the direction dependant of the targent angle.
                m_rb.AddForce(moveNewDir.normalized * m_MovementSpeed * 10);//Adds velocity to the direction for the player
            }
        }
    }

}
