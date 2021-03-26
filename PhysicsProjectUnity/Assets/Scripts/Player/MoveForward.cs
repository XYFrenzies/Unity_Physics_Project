using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private GameObject shotPos = null;
    [SerializeField] private float m_timer = 0;
    private float deltaTimer = 0;
    /// <summary>
    /// Sets the projectile active depending on what one is being used at the time and which input is being entered.
    /// There is a timer for the shooting so that it is semi automatic.
    /// Position and the rotation of the projectiles are set at a certain position on the player.
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        deltaTimer += Time.fixedDeltaTime;
        if (Input.GetMouseButton(0) && deltaTimer >= m_timer && PlayerController.globalPlayer.isAiming) 
        {
            GameObject obj = ObjectPooling.SharedInstance.GetPooledObject("Bullet");
            if (obj != null)
            {
                obj.transform.position = shotPos.transform.position;
                obj.transform.rotation = shotPos.transform.rotation;
                obj.gameObject.SetActive(true);
            }
            deltaTimer = 0;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerController.globalPlayer.isAiming)
        {
            GameObject obj = ObjectPooling.SharedInstance.GetPooledObject("Rocket");
            if (obj != null)
            {
                obj.transform.position = shotPos.transform.position;
                obj.transform.rotation = shotPos.transform.rotation;
                obj.gameObject.SetActive(true);
            }
        }
    }
}
