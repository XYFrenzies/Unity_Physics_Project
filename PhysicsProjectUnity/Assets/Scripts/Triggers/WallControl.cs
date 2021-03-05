using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    private Vector3 originalPos = Vector3.zero;
    private Vector3 deltaPos = Vector3.zero;
    
    private Vector3 originalRot = Vector3.zero;
    private Vector3 deltaRot = Vector3.zero;
    private bool isRewinding = false;
    public float rewindTime = 1f;
    public float elapseTime = 0f;
    //public float 

    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
        originalRot = gameObject.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    private void Update()
    {
        Rewind();
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
    }

    void Rewind()
    {
        if (!isRewinding)
        {
            return;
        }
        elapseTime += Time.deltaTime;
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position -= Time.deltaTime / rewindTime * deltaPos;
        Quaternion rot = transform.rotation;
        Vector3 eular = rot.eulerAngles;

        eular -= Time.deltaTime / rewindTime * deltaRot;

        rot.eulerAngles = eular;
        transform.rotation = rot;

        if (elapseTime >= rewindTime)
        {
            isRewinding = false;
            transform.position = originalPos;

            Quaternion rot1 = transform.rotation;
            rot1.eulerAngles = originalRot;
            transform.rotation = rot1;
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GetComponent<Rigidbody>().isKinematic = false;
        }
        
    }
    void StartRewind() 
    {
        isRewinding = true;
        elapseTime = 0f;
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        deltaPos = transform.position - originalPos;
        deltaRot = transform.rotation.eulerAngles - originalRot;
    }
}
