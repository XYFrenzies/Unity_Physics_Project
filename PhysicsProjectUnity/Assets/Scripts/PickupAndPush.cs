using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAndPush : MonoBehaviour
{
    private GameObject obj = null;
    [SerializeField] private GameObject newPos = null;
    [SerializeField] private float m_movementSpeed = 100.0f;
    [SerializeField] private float travelTime = 1.0f;
    [SerializeField] private float timeBeforeGravity = 10.0f;
    private Vector3 originalRot = Vector3.zero;
    private bool isInHand = false;
    private bool isTravelling = false;
    [HideInInspector] public bool isMoveable = false;
    private float elapseTime = 0;
    private Vector3 deltaPos = Vector3.zero;
    private Vector3 deltaRot = Vector3.zero;
    private float m_timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
        originalRot = obj.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        TravelWith();
        if (Input.GetMouseButtonDown(1) && (isMoveable || isInHand))
        {
            if (!isInHand)
                TravelTo();
            else
                PushBack();
        }
        else
            isMoveable = false;
        if (isInHand)
        {
            obj.transform.position = newPos.transform.position;
        }
        if (m_timer >= timeBeforeGravity)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
            m_timer = 0;
        }
        m_timer += Time.deltaTime;

    }
    void TravelTo() 
    {
        isTravelling = true;
        elapseTime = 0f;
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().isKinematic = true;
        deltaPos = obj.transform.position - newPos.transform.position;
        deltaRot = obj.transform.rotation.eulerAngles - originalRot;
    }
    void PushBack() 
    {
        Rigidbody rb = obj.GetComponentInParent<Rigidbody>();
        rb.AddForce(Camera.main.transform.forward * m_movementSpeed);
        isInHand = false;
    }
    void TravelWith() 
    {
        if (!isTravelling)
            return;
        elapseTime += Time.deltaTime;
        obj.GetComponent<Rigidbody>().Sleep();
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        obj.transform.position -= Time.deltaTime / travelTime * deltaPos;
        Quaternion rot = transform.rotation;
        Vector3 eular = rot.eulerAngles;

        eular -= Time.deltaTime / travelTime * deltaRot;

        rot.eulerAngles = eular;
        transform.rotation = rot;

        if (elapseTime >= travelTime)
        {
            isTravelling = false;
            isInHand = true;
            obj.transform.position = newPos.transform.position;

            Quaternion rot1 = obj.transform.rotation;
            rot1.eulerAngles = originalRot;
            obj.transform.rotation = rot1;
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            obj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            obj.GetComponent<Rigidbody>().isKinematic = false;
        }

    }
}
