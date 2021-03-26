﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClipping : MonoBehaviour
{
    [HideInInspector] public List<MeshRenderer> listobj;
    [HideInInspector] public List<Material> objectMaterials;
    [SerializeField] public Material alphaMat;
    [SerializeField] private Shader m_shader;
    [SerializeField] [Range(3.0f, 7.0f)] public float rayCastRange = 5.5f;
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.gameObject.transform.position,
            Camera.main.gameObject.transform.forward, out hit, rayCastRange) &&//Needs to be adjustable not have 6 as its parameter.
            !hit.collider.gameObject.CompareTag("Player"))
        {
            //Saves memory space as there will be less variables to check through a list.
            MeshRenderer objectMesh = hit.transform.gameObject.GetComponent<MeshRenderer>();
            if (objectMesh != null)
            {
                if (alphaMat != null)
                {                        
                    if (objectMesh.gameObject.CompareTag("Barrier") && objectMesh.material.shader != m_shader)//Because this is being called in update, it is always being called.
                    {
                        AddToList(objectMesh);
                    }
                }
            }
        }
        else
            SetBack();

    }
    void SetBack()//Setting the meshRenderer back to active
    {
        for (int i = 0; i < listobj.Count; i++)
        {
            var value = listobj[i];
            value.material = objectMaterials[i];
        }
    }
    void AddToList(MeshRenderer obj)//Setting the mesh renderer back to inactive.
    {
        objectMaterials.Add(obj.material);
        obj.material = alphaMat;
        listobj.Add(obj);
    }
    void CheckInList() 
    {
        //This checks if theres any thats not being hit and converts them back.
    }
}
