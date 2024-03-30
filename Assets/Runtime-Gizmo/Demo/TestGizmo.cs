////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author: JayCode
//Description: Test the implementation
////////////////////////////////////////////////////////////////////////////////////////////////////////
using JayCode.Gizmo.Internal;
using UnityEngine;

[ExecuteInEditMode]
public class TestGizmo : MonoBehaviour
{
    public Color color = Color.green;
    public type Type;
    public bool rotation = true;
    public Vector3 size;
    public BoxCollider box;

    
    void Update()
    {
        switch (Type)
        {
            case type.Cube:
                RuntimeGizmoDrawer.DrawWireCube(transform.position,rotation? transform.rotation:Quaternion.identity, size.x, color);
                break;
            case type.Box:
                RuntimeGizmoDrawer.DrawWireBox(transform.position, rotation ? transform.rotation : Quaternion.identity, size, color);
                break;
            case type.BoxCollider:
                RuntimeGizmoDrawer.DrawWireBox(box, color);
                break;
  
        }
    }

    public enum type
    {
        Cube,
        Box,
        BoxCollider,
    }
}
