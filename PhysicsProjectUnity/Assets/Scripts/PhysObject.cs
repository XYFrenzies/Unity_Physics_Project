using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody))]
public class PhysObject : MonoBehaviour
{
    public Material awakeMat = null;
    public Material sleepMat = null;

    [SerializeField] private Rigidbody m_rb;

    private bool wasAsleep = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (m_rb.IsSleeping() && !wasAsleep && sleepMat != null)
        {
            wasAsleep = true;
            GetComponent<MeshRenderer>().material = sleepMat;
        }
        if (!m_rb.IsSleeping() && wasAsleep && awakeMat != null)
        {
            wasAsleep = false;
            GetComponent<MeshRenderer>().material = awakeMat;
        }
    }
}
