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
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * x * m_rotationSpeed;

        curXRot += y * m_rotationSpeed;
        curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);


        Vector3 clampAng = m_target.eulerAngles;
        clampAng.x = curXRot;
        m_target.eulerAngles = clampAng;
    }
}
