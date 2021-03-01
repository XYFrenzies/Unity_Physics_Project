using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private GameObject shotPos = null;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject obj = ObjectPooling.SharedInstance.GetPooledObject("Bullet");
            if (obj != null)
            {
                obj.transform.position = shotPos.transform.position;
                obj.transform.rotation = shotPos.transform.rotation;
                obj.gameObject.SetActive(true);
            }
        }
    }
}
