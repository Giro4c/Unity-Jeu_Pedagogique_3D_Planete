using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeEllipse : MonoBehaviour
{
    
    public Ellipse ellipse;
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
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.material.color = axisColor;

        // Dessiner l'axe principal de l'ellipse à la position de votre choix
        Vector3 position = transform.position;  // Utilisez la position actuelle de l'objet ou définissez une position spécifique
        DrawEllipse(position);
    }

    void DrawEllipse(Vector3 position)
    {
        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector2 pointOnEllipse = ellipse.Evaluate(t);
            Vector3 point = new Vector3(pointOnEllipse.x + position.x, position.y, pointOnEllipse.y + position.z);
            lineRenderer.SetPosition(i, point);
        }
    }
}
