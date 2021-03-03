using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Image m_img = null;
    [SerializeField] private float m_moveSpeed = 1;
    Color newCol;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 500) == true)
        {
            GameObject obj = hitInfo.collider.gameObject;
            if (obj.GetComponent<Rigidbody>() == true && obj.CompareTag("Enemy"))
                newCol = Color.red;
            else if (obj.GetComponent<BoxCollider>() == true)
            {
                newCol = Color.green;
                if (obj.GetComponentInParent<Rigidbody>() == true)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Rigidbody rb = obj.GetComponentInParent<Rigidbody>();
                        rb.AddForce(Camera.main.transform.forward * m_moveSpeed);
                    }
                }

            }

            else
                newCol = hitInfo.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");

            m_img.color = newCol;

            
        }
    }
}
