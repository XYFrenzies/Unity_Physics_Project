using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform prefab;
    public Transform spawner;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey == true)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
           // Instantiate(spawner, transform.position - new Vector3(Random.Range(-7000, 7000), 0, Random.Range(-7000, 7000)), Quaternion.identity);
        }
        //else
        //{
        //    timer += Time.deltaTime;
        //}
    }
}
