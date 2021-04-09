using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 8/4/2021
/// Last Modified: 9/4/2021
/// </summary>
/// Able to be seen in edit mode.
[ExecuteInEditMode]
public class OverlayCamera : MonoBehaviour
{
    //Setting the camera so that it can see the frost effect through post processing.
    [SerializeField] private Material m_mat = null;
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_mat);
    }
}
