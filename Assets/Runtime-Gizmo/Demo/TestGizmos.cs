////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author: JayCode
//Description: Test the implementation
////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

[ExecuteInEditMode]
public class TestGizmos : MonoBehaviour
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
                RuntimeGizmosDrawer.DrawWireCube(transform.position,rotation? transform.rotation:Quaternion.identity, size.x, color);
                break;
            case type.Box:
                RuntimeGizmosDrawer.DrawWireBox(transform.position, rotation ? transform.rotation : Quaternion.identity, size, color);
                break;
            case type.BoxCollider:
                RuntimeGizmosDrawer.DrawWireBox(box, color);
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
