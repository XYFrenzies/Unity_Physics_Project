using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private Image healthBarImg = null;
    private float damage = 25;
    [SerializeField] private float m_hitBuffer = 5.0f;
    private float deltaTimer = 0;
    private bool isHit = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (isHit == false)
            {
                health -= damage;
                healthBarImg.rectTransform.localScale += new Vector3(1.5f, 0, 0);
                isHit = true;
            }
            Ragdoll rag = other.gameObject.GetComponentInParent<Ragdoll>();
            rag.isTouchingObj = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Ragdoll rag = other.gameObject.GetComponentInParent<Ragdoll>();
            rag.isTouchingObj = false;
        }

    }
}
