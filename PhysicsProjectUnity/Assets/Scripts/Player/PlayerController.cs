using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject m_riflePNG = null;
    [SerializeField] private GameObject m_launcherPNG = null;
    [SerializeField] [Range(0.001f, 5f)] public float m_MovementSpeed = 2.0f;
    [SerializeField] [Range(5.0f, 20.0f)] private float m_animtionDampTime = 10.0f;//The smoothness between the transition.
    [SerializeField] [Range(5.0f, 30.0f)] private float m_animtionScaling = 10.0f;//The time between the transition.
    [SerializeField] private float m_maxRunningSpeed = 10.0f;
    [SerializeField] private float pushPower = 2.0f;
    [SerializeField] private float gravityValue = -4.81f;
    [SerializeField] private float m_jumpSpeed = 8.0f;
    [SerializeField] [Range(1.0f, 50.0f)] private float m_moveSpeedWallPowerTimer = 2.0f;
    [HideInInspector] public int switchWeapons = 1;
    [HideInInspector] public bool isAiming = false;
    [HideInInspector] public bool isWallPowerSpeedOn = false;
    public static PlayerController globalPlayer = null;
    private Vector3 playerVelocity = Vector3.zero;
    private CharacterController controller = null;
    private Animator m_animator = null;
    private InputManager m_controls;
    private ParticleSystem m_particleSys = null;
    private bool hasHitAnim = false;
    private float m_viewPointTimer = 0;
    private float m_constTime = 0.5f;
    private float m_jumpTimer = 2;
    private float m_swtichTimer = 2;
    private float m_timer = 2;
    private float m_speedTimer = 0;
    private float deltaTimer = 0;
    private float m_saveMoveSpeed = 0;

    /// <summary>
    /// Adds the components to the variables and enables the controller.
    /// </summary>
    // Start is called before the first frame update
    void Awake()
    {
        globalPlayer = this;
    }
    void Start()
    {
        m_saveMoveSpeed = m_MovementSpeed;
        m_riflePNG.SetActive(true);
        m_launcherPNG.SetActive(false);
        controller = GetComponentInChildren<CharacterController>();
        m_controls = new InputManager();
        m_controls.Player.Enable();
        m_animator = GetComponent<Animator>();
        m_particleSys = GetComponentInChildren<ParticleSystem>();
        m_particleSys.gameObject.SetActive(false);
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
        var rClickZoom = m_controls.Player.PlayerAim.ReadValue<float>();
        var changeWeapons = m_controls.Player.ChangeWeapons.ReadValue<float>();
        if (rClickZoom != 0)
        {
            if (!isAiming && m_viewPointTimer >= m_constTime)
            {
                m_animator.SetBool("isAiming", true);
                isAiming = true;
                m_viewPointTimer = 0;
            }
            else if (isAiming && m_viewPointTimer >= m_constTime)
            {
                m_animator.SetBool("isAiming", false);
                isAiming = false;
                m_viewPointTimer = 0;

            }
        }
        Movement();
        Jump();
        if (hasHitAnim)
            deltaTimer += Time.fixedDeltaTime;
        m_viewPointTimer += Time.fixedDeltaTime;
        //In order to change weapons, tab is pressed with a cooldown for how many times u can press it.
        if (changeWeapons != 0 && m_swtichTimer >= m_constTime)
        {
            switchWeapons += 1;
            switch (switchWeapons)
            {
                case 1: 
                      m_riflePNG.SetActive(true);
                    m_launcherPNG.SetActive(false);
                    break;
                case 2:
                    m_launcherPNG.SetActive(true);
                    m_riflePNG.SetActive(false);
                    break;
                case 3:
                    m_riflePNG.SetActive(true);
                    m_launcherPNG.SetActive(false);
                    switchWeapons = 1;
                    break;
            }
            m_swtichTimer = 0;
        }
        if (isWallPowerSpeedOn && m_speedTimer >= m_moveSpeedWallPowerTimer)
        {
            m_speedTimer = 0;
            isWallPowerSpeedOn = false;
            m_particleSys.gameObject.SetActive(false);
            m_MovementSpeed = m_saveMoveSpeed;
        }
        else if (isWallPowerSpeedOn)
        {
            m_particleSys.gameObject.SetActive(true);
            m_speedTimer += Time.fixedDeltaTime;
        }
        m_swtichTimer += Time.fixedDeltaTime;
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
    void AnimationSetting(string a_string, float a_value)
    {
        m_animator.SetFloat(a_string, a_value, m_animtionDampTime, Time.deltaTime * m_animtionScaling);
    }
    void Jump() 
    {
        var jump = m_controls.Player.Jump.ReadValue<float>();
        if (controller.isGrounded)
        {
            m_jumpTimer += Time.fixedDeltaTime;
            playerVelocity = Vector3.zero;
            m_animator.SetBool("isGrounded", true);
        }

        if (controller.isGrounded && jump != 0 && m_jumpTimer >= m_constTime)
        {
            m_jumpTimer = 0;
            m_animator.SetBool("isGrounded", false);
            playerVelocity.y = m_jumpSpeed;
        }


        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        controller.Move(playerVelocity * Time.fixedDeltaTime);

    }
    void Movement() 
    {
        var dir = m_controls.Player.Movement.ReadValue<Vector2>();
        var accel = m_controls.Player.Acceleration.ReadValue<float>();
        if ((dir.x != 0 || dir.y != 0))
        {
            Vector3 input = transform.right * dir.x + transform.forward * dir.y;  //This is for the movement of the player in the certain direction.
            if (accel <= 0)
            {
                controller.Move(input * Time.fixedDeltaTime * m_MovementSpeed);
                AnimationSetting("SpeedMod", 1);
            }
            else if (accel != 0)
            {
                controller.Move(input * Time.fixedDeltaTime * (m_MovementSpeed + m_maxRunningSpeed));
                AnimationSetting("SpeedMod", 2);
            }
            AnimationSetting("yPos", Mathf.Clamp(dir.y, -1.0f, 1.0f));
            AnimationSetting("xPos", Mathf.Clamp(dir.x, -1.0f, 1.0f));
        }
        else
        {
            AnimationSetting("yPos", 0);
            AnimationSetting("xPos", 0);
        }
    }
}
