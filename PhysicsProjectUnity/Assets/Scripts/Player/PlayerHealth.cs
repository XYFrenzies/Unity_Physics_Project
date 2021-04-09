using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 5/3/2021
/// Last Modified: 9/4/2021
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private Image healthBarImg = null;
    private float damage = 25;
    [SerializeField] private float m_hitBuffer = 5.0f;
    private float deltaTimer = 0;
    private bool isHit = false;
    /// <summary>
    /// Checks if there is any health left, if not the player will be sent ot the game over screen. Otherwise the timer for the hit buffer will go up.
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("GameOverScene");
        }
        else if (isHit == true)
            deltaTimer += Time.fixedDeltaTime;

        if (deltaTimer >= m_hitBuffer)
        {
            isHit = false;
            deltaTimer = 0;
        }
    }
    /// <summary>
    /// if the trigger is with the enemy, the player will take a certain amount of health and the image (for now its an image instead of a slider) will go down.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isHit == false)
            {
                health -= damage;
                healthBarImg.rectTransform.localScale += new Vector3(0.75f, 0, 0);
                isHit = true;
            }
            Ragdoll rag = other.gameObject.GetComponentInParent<Ragdoll>();
            rag.isTouchingObj = true;
        }

    }
    /// <summary>
    /// To fix an issue that has occured with the enemies going into the player, the enemies will for now on sit outside the character controller of the player.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Ragdoll rag = other.gameObject.GetComponentInParent<Ragdoll>();
            rag.isTouchingObj = false;
        }

    }
}
