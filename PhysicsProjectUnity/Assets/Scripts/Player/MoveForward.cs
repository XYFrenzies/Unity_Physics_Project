using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private GameObject shotPos = null;
    [SerializeField] private float m_timer = 0;
    private float deltaTimer = 0;
    private PlayerController m_player;
    private void Start()
    {
        m_player = PlayerController.globalPlayer;
    }
    /// <summary>
    /// Sets the projectile active depending on what one is being used at the time and which input is being entered.
    /// There is a timer for the shooting so that it is semi automatic.
    /// Position and the rotation of the projectiles are set at a certain position on the player.
    /// </summary>
    // Update is called once per frame
    void FixedUpdate()
    {
        deltaTimer += Time.fixedDeltaTime;
        if (Input.GetMouseButton(0) && deltaTimer >= m_timer && m_player.isAiming && m_player.switchWeapons == 1) 
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
        if (Input.GetMouseButton(0) && PlayerController.globalPlayer.isAiming && m_player.switchWeapons == 2)
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
