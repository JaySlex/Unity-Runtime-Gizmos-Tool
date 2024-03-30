////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author: JayCode
//Description: Request's arguments
////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

public struct GizmoBoxDrawRequest
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public Color color;

    public GizmoBoxDrawRequest(Vector3 position, Quaternion rotation, Vector3 scale, Color color)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
        this.color = color;
    }
}