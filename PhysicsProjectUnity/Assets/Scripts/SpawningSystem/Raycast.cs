using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Image m_img = null;
    Color newCol;
    public static Raycast sharedInstance;
    [HideInInspector] public bool isObjectMoveable;
    private void Start()
    {
        sharedInstance = this;
    }
    /// <summary>
    /// A ray from the camera outwards will detect a hit. If the hit is the enemy, the crosshair will turn red, 
    /// otherwise it will turn white or green depending if its a rigidbody or not
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
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
                if (obj.GetComponentInParent<Rigidbody>() == true && obj.CompareTag("Moveable"))
                {
                    obj.GetComponentInParent<PickupAndPush>().isMoveable = true;
                }
            }
            else
            {
                newCol = Color.white;
            }

            m_img.color = newCol;
        }
    }
}
