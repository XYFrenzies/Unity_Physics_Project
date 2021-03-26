using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(0.001f, 5f)] private float m_MovementSpeed = 2.0f;
    [SerializeField] private float m_maxRunningSpeed = 10.0f;
    [SerializeField] private float pushPower = 2.0f;
    private Vector3 playerVelocity;
    [SerializeField] private float gravityValue = -4.81f;
    private CharacterController controller = null;
    private PlayerMovement m_controls;
    private float m_timer = 2;
    private float deltaTimer = 0;
    private bool hasHitAnim = false;
    /// <summary>
    /// Adds the components to the variables and enables the controller.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
        m_controls = new PlayerMovement();
        m_controls.Player.Enable();
    }
    /// <summary>
    /// In order for the direction to be calculated, wihtin the new input system it is checked if the player is moving with the two vector2 axis.
    /// If they are moving, it is calculated the correct direction that they are moving, if they are running (through shift), they will move at a faster speed than walking.
    /// If the player is grounded its y velocity will be equal to zero, otherwise it will continuously fall until it hits the ground.
    /// Within the animation, in order for a timer to occur, the player needs to stand onto of the platform so that it will move. 
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        var dir = m_controls.Player.Movement.ReadValue<Vector2>();

        if ((dir.x != 0 || dir.y != 0))
        {
            Vector3 input = transform.right * dir.x + transform.forward * dir.y;  //This is for the movement of the player in the certain direction.
            if (!Input.GetKey(KeyCode.LeftShift))
                controller.Move(input * Time.fixedDeltaTime * m_MovementSpeed);
            else if (Input.GetKey(KeyCode.LeftShift))
                controller.Move(input * Time.fixedDeltaTime * (m_MovementSpeed + m_maxRunningSpeed));
        }
        if (controller.isGrounded == true)
            playerVelocity = Vector3.zero;
        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        controller.Move(playerVelocity * Time.fixedDeltaTime);
        if (hasHitAnim)
            deltaTimer += Time.fixedDeltaTime;
    }
    /// <summary>
    /// Using a character controller, it checks first if the player is hitting the elavator. If it is we determin if its in the middle of its playthrough or if it is active or not.
    /// When the player is colliding with a rigidbody, a force will be put against the object.
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<Animation>() &&
            !hit.gameObject.GetComponent<ConfigurableJoint>())
        {
            if (!hit.gameObject.GetComponent<Animation>().IsPlaying("Moving 2nd Level"))
                hasHitAnim = false;
            if (!hasHitAnim)
                hasHitAnim = true;
            if (m_timer <= deltaTimer)
            {
                hit.gameObject.GetComponent<Animation>().Play();
                deltaTimer = 0;
            }
        }
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;
        if (hit.moveDirection.y < -0.3f)
            return;
        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDirection * pushPower;


    }
}
