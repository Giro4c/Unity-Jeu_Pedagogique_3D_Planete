using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class AxeTerre : MonoBehaviour
{
    private int numSegments = 50;
    public float radius = 1f;
    

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numSegments + 1;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        
    }

    private void Update()
    {
        DrawCircle();
    }

    private void DrawCircle()
    {
        float deltaTheta = (2f * Mathf.PI) / numSegments;
        float theta = 0f;

        for (int i = 0; i < numSegments + 1; i++)
        {
            float x = radius * Mathf.Cos(theta);
            float z = radius * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, 0f, z) + transform.position;
            lineRenderer.SetPosition(i, pos);

            theta += deltaTheta;
        }
    }
}
