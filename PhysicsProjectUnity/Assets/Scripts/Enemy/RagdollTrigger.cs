using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 24/2/2021
/// Last Modified: 9/4/2021
/// </summary>
public class RagdollTrigger : MonoBehaviour
{
    [SerializeField] private float m_ragDollSpeed = 10;
    /// <summary>
    /// Once the enemy has entered a trigger, it will be recognised through its tag and the ragdoll effect will occur.
    /// It loops through all rigidbodies within the enemy to make the add force in the direction of the projectile.
    /// Once this has occured, the projectile is set back to false. However, if it isnt hitting an enemy but the ground,
    /// the rocket or the wrecking ball tags will begin a explosive force from the collision point outwards.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Ragdoll r = other.gameObject.GetComponentInParent<Ragdoll>();
        Rigidbody objRB = GetComponent<Rigidbody>();
        if (other.CompareTag("Enemy") && r != null && (this.CompareTag("Bullet") || this.CompareTag("WB")))
        {
            if (this.CompareTag("WB"))
                this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_RimColor", Color.white);
            r.RagdollOn = true;
            if (r.isCollided == true && r.isHit == false)
            {
                foreach (Rigidbody rb in r.rigidbodies)
                {
                    if (this.CompareTag("Bullet"))
                        rb.AddForce(objRB.velocity * m_ragDollSpeed);
                    r.isHit = true;

                }
                if (objRB.CompareTag("Bullet"))
                    objRB.gameObject.SetActive(false);
            }

        }
        else if (this.CompareTag("Rocket"))
        {
            Collider[] collider = Physics.OverlapSphere(gameObject.transform.position, RocketMovement.sharedInstance.explosiveRadius, ~LayerMask.GetMask("Barrier"));
            RocketMovement.sharedInstance.MultiForce(collider);
        }
        else if (this.CompareTag("WB"))
        {
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_RimColor", Color.white);
            Collider[] collider = Physics.OverlapSphere(gameObject.transform.position, WreckingBall.sharedInstance.explosiveRadius, ~LayerMask.GetMask("Barrier"));
            WreckingBall.sharedInstance.MultiForce(collider);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("WB"))
            this.gameObject.GetComponent<MeshRenderer>().material.SetColor("_RimColor", Color.black);
    }
}
