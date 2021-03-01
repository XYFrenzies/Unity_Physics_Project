using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    [SerializeField] private float m_ragDollSpeed = 10;
    private void OnTriggerEnter(Collider other)
    {
        Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
        if (r != null)
        {
            r.RagdollOn = true;
            if (r.isCollided == true && r.isHit == false)
            {
                Rigidbody objRB = GetComponent<Rigidbody>();
                foreach (Rigidbody rb in r.rigidbodies)
                {
                    rb.AddForce(objRB.velocity * m_ragDollSpeed);
                    r.isCollided = false;
                    r.isHit = true;
                    objRB.gameObject.SetActive(false);
                }
            }
        }
    }
}
