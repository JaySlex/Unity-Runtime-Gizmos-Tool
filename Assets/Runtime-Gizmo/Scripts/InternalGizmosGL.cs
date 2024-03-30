////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author: JayCode
//Description: API for rendering the gizmos in runtime using low level render apis
////////////////////////////////////////////////////////////////////////////////////////////////////////
using UnityEngine;

namespace JayCode.Gizmos.Internal
{
    public class InternalGizmosGL
    {
        public static void DrawWireBox(GizmosBoxDrawRequest request)
        {
            var halfDimensions = request.scale * 0.5f; // This now represents half-width, half-height, and half-depth
            var points = new Vector3[8];

            // Bottom four points
            points[0] = request.position + new Vector3(-halfDimensions.x, -halfDimensions.y, -halfDimensions.z);
            points[1] = request.position + new Vector3(halfDimensions.x, -halfDimensions.y, -halfDimensions.z);
            points[2] = request.position + new Vector3(halfDimensions.x, -halfDimensions.y, halfDimensions.z);
            points[3] = request.position + new Vector3(-halfDimensions.x, -halfDimensions.y, halfDimensions.z);

            // Top four points
            points[4] = request.position + new Vector3(-halfDimensions.x, halfDimensions.y, -halfDimensions.z);
            points[5] = request.position + new Vector3(halfDimensions.x, halfDimensions.y, -halfDimensions.z);
            points[6] = request.position + new Vector3(halfDimensions.x, halfDimensions.y, halfDimensions.z);
            points[7] = request.position + new Vector3(-halfDimensions.x, halfDimensions.y, halfDimensions.z);

            // Apply rotation here
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = request.rotation * (points[i] - request.position) + request.position;
            }

            GL.PushMatrix();

            RuntimeGizmosDrawer.InitializeMat();
            RuntimeGizmosDrawer.mat.SetPass(0);

            GL.Begin(GL.LINES);
            GL.Color(request.color);

            // Bottom square
            DrawLine(points[0], points[1], request.color);
            DrawLine(points[1], points[2], request.color);
            DrawLine(points[2], points[3], request.color);
            DrawLine(points[3], points[0], request.color);

            // Top square
            DrawLine(points[4], points[5], request.color);
            DrawLine(points[5], points[6], request.color);
            DrawLine(points[6], points[7], request.color);
            DrawLine(points[7], points[4], request.color);

            // Sides
            DrawLine(points[0], points[4], request.color);
            DrawLine(points[1], points[5], request.color);
            DrawLine(points[2], points[6], request.color);
            DrawLine(points[3], points[7], request.color);

            GL.End();
            GL.PopMatrix();
        }

        public static void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            GL.Vertex(start);
            GL.Vertex(end);

            Debug.DrawLine(start, end, color);
        }
    }
}