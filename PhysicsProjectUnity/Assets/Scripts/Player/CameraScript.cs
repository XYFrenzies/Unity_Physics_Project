using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform m_target = null;
    [SerializeField] private float m_rotationSpeed = 1.0f;
    [SerializeField] private float minXRot = 0;
    [SerializeField] private float maxXRot = 0;

    private float curXRot = 0;
    /// <summary>
    /// Locks the camera in the middle whilst it is invisible.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    /// <summary>
    /// Finds the mouse positions in the x and y and determines the players rotation through the x axis of the mouse and the speed of the rotation.
    /// There is a specific angle at which the player can not reach and therefore we limit that rotation.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * x * m_rotationSpeed;

        curXRot -= y * m_rotationSpeed;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);


        Vector3 clampAng = m_target.eulerAngles;
        clampAng.x = curXRot;
        m_target.eulerAngles = clampAng;
    }
}
