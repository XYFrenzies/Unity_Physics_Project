using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private GameObject shotPos = null;
    [SerializeField] private float m_timer = 0;
    private float deltaTimer = 0;
    // Update is called once per frame
    void Update()
    {
        deltaTimer += Time.deltaTime;
        if (Input.GetMouseButton(0) && deltaTimer >= m_timer) 
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
        if (Input.GetKeyDown(KeyCode.Space))
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
