using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 1/3/2021
/// Last Modified: 9/4/2021
/// </summary>
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float m_movespeed = 300.0f;
    private Rigidbody m_rb = null;
    private bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }
    /// <summary>
    /// Shoots in the direction of the player's camera, the bullet then follows the direction without any determination of the camera.
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShooting == false)
        {
            m_rb.AddForce(Camera.main.transform.forward * m_movespeed);
            isShooting = true;
    }
        else if (isShooting)
            m_rb.AddForce(transform.forward * m_movespeed);

}
    private void OnTriggerEnter(Collider other)
    {
        isShooting = false;
        m_rb.velocity = Vector3.zero;
        m_rb.gameObject.SetActive(false);
    }
}
