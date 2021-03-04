using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    [SerializeField] private float m_ragDollSpeed = 10;
    private void OnTriggerEnter(Collider other)
    {
        Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
        Rigidbody objRB = GetComponent<Rigidbody>();
        if (other.CompareTag("Enemy") && r != null && this.CompareTag("Bullet"))
        {
            r.RagdollOn = true;
            if (r.isCollided == true && r.isHit == false)
            {
                RoundSystem.sharedInstance.pointTotal += 10;
                foreach (Rigidbody rb in r.rigidbodies)
                {
                    if (this.CompareTag("Bullet"))
                        rb.AddForce(objRB.velocity * m_ragDollSpeed);
                    r.isCollided = false;
                    r.isHit = true;

                }
                if (objRB.CompareTag("Bullet"))
                    objRB.gameObject.SetActive(false);
                RoundSystem.sharedInstance.enemiesRemaining -= 1;
            }

        }
        else if (this.CompareTag("Rocket"))
        {
            Collider[] collider = Physics.OverlapSphere(gameObject.transform.position, RocketMovement.sharedInstance.explosiveRadius, ~LayerMask.GetMask("Barrier"));            
            RocketMovement.sharedInstance.MultiForce(collider);
        }
    }
}
