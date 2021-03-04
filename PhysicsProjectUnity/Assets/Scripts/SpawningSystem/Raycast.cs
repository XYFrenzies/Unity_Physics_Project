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
