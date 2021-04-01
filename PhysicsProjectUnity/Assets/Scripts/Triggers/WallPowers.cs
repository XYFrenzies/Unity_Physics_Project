using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class WallPowers : MonoBehaviour
{
    [SerializeField] private int m_wallPowerSpeed = 500;
    [SerializeField] private float m_movementSpeed = 2;
    [SerializeField] private int m_doublePointsPower = 600;
    [SerializeField] private int m_largerRadiusCost = 800;
    [SerializeField] private int m_largerRadius = 1;
    [SerializeField] private int m_nukeCost = 9000;
    [SerializeField] private float m_distFromBoard = 10;
    private GraphicRaycaster m_Raycaster;
    private PointerEventData m_PointerEventData;
    private EventSystem m_EventSystem;
    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }
    public void IncreasedSpeed() 
    {
        if (RoundSystem.sharedInstance.pointTotal >= m_wallPowerSpeed)
        {
            PlayerController.globalPlayer.m_MovementSpeed += m_movementSpeed;
            RoundSystem.sharedInstance.pointTotal -= m_wallPowerSpeed;
        }
    }

    public void DoublePoints() 
    {
        if (!RoundSystem.sharedInstance.doublePoints && 
            RoundSystem.sharedInstance.pointTotal >= m_doublePointsPower)
        {
            RoundSystem.sharedInstance.doublePoints = true;
            RoundSystem.sharedInstance.pointTotal -= m_doublePointsPower;
        }
    }

    public void LargerRadius() 
    {
        if (RoundSystem.sharedInstance.pointTotal >= m_largerRadiusCost)
        {
            RocketMovement.sharedInstance.explosiveRadius += m_largerRadius;
            RoundSystem.sharedInstance.pointTotal -= m_largerRadiusCost;
        }
    }

    public void Nuke() 
    {
        if (RoundSystem.sharedInstance.pointTotal >= m_nukeCost)
        {
            RoundSystem.sharedInstance.pointTotal -= m_nukeCost;
        }
    }
    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<Button>() != null && 
                    result.distance <= m_distFromBoard &&
                        result.gameObject.GetComponent<Button>().interactable)
                {
                        result.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
