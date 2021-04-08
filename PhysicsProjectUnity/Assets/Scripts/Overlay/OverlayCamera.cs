using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class OverlayCamera : MonoBehaviour
{
    [SerializeField] private Material m_mat = null;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_mat);
    }
}
