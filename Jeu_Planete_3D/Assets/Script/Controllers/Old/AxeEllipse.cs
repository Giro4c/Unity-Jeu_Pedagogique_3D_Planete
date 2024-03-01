using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEllipse : MonoBehaviour
{
    public float semiMajorAxis;
    public float semiMinorAxis;
    public int segments = 100;
    public Color axisColor = Color.white;

    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupAxis();
    }

    void SetupAxis()
    {
        // Définir les propriétés du LineRenderer
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startWidth = 0.04f;
        lineRenderer.endWidth = 0.04f;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.material.color = axisColor;

        // Dessiner l'axe principal de l'ellipse
        for (int i = 0; i <= segments; i++)
        {
            float angle = 360f * Mathf.Deg2Rad * i ;
            float x = semiMajorAxis * Mathf.Cos(angle);
            float y = semiMinorAxis * Mathf.Sin(angle);
            Vector3 point = new Vector3(x-1, 0f, y);  // Mettez y à zéro pour maintenir l'ellipse horizontale
            lineRenderer.SetPosition(i, point);
        }
    }
}
