using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    [SerializeField] private float m_ragDollSpeed = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
            RoundSystem.sharedInstance.pointTotal += 50;
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

                    }
                    if (objRB.CompareTag("Bullet"))
                        objRB.gameObject.SetActive(false);
                    RoundSystem.sharedInstance.enemiesRemaining -= 1;
                }
            }
        }
    }
}
