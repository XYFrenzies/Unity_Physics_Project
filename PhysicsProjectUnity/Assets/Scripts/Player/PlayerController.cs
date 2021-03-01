using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0.001f, 5f)] private float m_MovementSpeed = 2.0f;
    //[SerializeField] private float m_maxMoveSpeed = 5.0f;
    [SerializeField] private float pushPower = 2.0f;
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f;
    //private Rigidbody m_rb = null;
    private CharacterController controller = null;
    private InputManager m_controls;
    // Start is called before the first frame update
    void Start()
    {
       // m_rb = GetComponentInChildren<Rigidbody>();
        controller = GetComponentInChildren<CharacterController>();
        m_controls = new InputManager();
        m_controls.Player.Enable();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = m_controls.Player.Movement.ReadValue<Vector2>();

        if (dir.x != 0 || dir.y != 0)
        {
            Vector3 input = transform.right * dir.x + transform.forward * dir.y;  //This is for the movement of the player in the certain direction.
            controller.Move(input * Time.fixedDeltaTime * m_MovementSpeed);
            playerVelocity.y += gravityValue * Time.fixedDeltaTime;
            controller.Move(playerVelocity * Time.fixedDeltaTime);

        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;
        if (hit.moveDirection.y < -0.3f)
            return;
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDirection * pushPower;
    }
}
