using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairEditor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_renderer;
    Color newCol;


    // Start is called before the first frame update
    void Start()
    {
        m_renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, 500) == true)
        {
            newCol = hitInfo.collider.gameObject.GetComponent<Renderer>().material.GetColor("_Color");

            m_renderer.color = newCol;
        }
    }
}
