////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author: JayCode
//Description: Implementation of Unity's gizmos on runtime. Includes:
//-Rotation
//-Box collider gizmo
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections.Generic;
using UnityEngine;
using JayCode.Gizmo.Internal;

[ExecuteInEditMode]
public class RuntimeGizmoDrawer : MonoBehaviour
{

    public static Material mat;


    private static List<GizmoBoxDrawRequest> boxDrawRequests = new List<GizmoBoxDrawRequest>();

    private void OnPostRender()
    {
        for (int i = 0; i < boxDrawRequests.Count; i++)
        {

            InternalGizmoGL.DrawWireBox(boxDrawRequests[i]);
        }
        boxDrawRequests.Clear();
    }

    public static void InitializeMat()
    {
        if (mat != null) return;

        /*Shader shader = Shader.Find("Hidden/Internal-Colored");
        mat = new Material(shader);
        mat.hideFlags = HideFlags.HideAndDontSave;
        // Set blend mode to invert destination colors.
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusDstColor);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        // Turn off backface culling, depth writes, depth test.
        mat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        mat.SetInt("_ZWrite", 0);
        mat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);*/

        Shader shader = Shader.Find("Custom/GLShader");
        mat = new Material(shader);
    }



    public static void DrawWireCube(Vector3 position, Quaternion rotation,float size, Color color)
    {
        GizmoBoxDrawRequest request = new GizmoBoxDrawRequest(position, rotation, new Vector3(size,size,size), color);

        boxDrawRequests.Add(request);
        //Render also in editor
        InternalGizmoGL.DrawWireBox(request);
    }
    public static void DrawWireCube(Vector3 position, float size, Color color)
    {
        DrawWireCube(position, Quaternion.identity, size, color);
    }

    public static void DrawWireBox(Vector3 position, Quaternion rotation, Vector3 scale, Color color)
    {
        GizmoBoxDrawRequest request = new GizmoBoxDrawRequest(position, rotation, scale, color);

        boxDrawRequests.Add(request);
        //Render also in editor
        InternalGizmoGL.DrawWireBox(request);
    }

    public static void DrawWireBox(BoxCollider box, Color color)
    {
        DrawWireBox(box.transform.position + box.transform.TransformVector(box.center), box.transform.rotation, Vector3.Scale(box.size, box.transform.localScale), color);
    }
}
