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
        
    }
    void Update()
    {
        
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
        // Position choisie dans l'espace
        Vector3 chosenPosition = new Vector3(104f, 6f, 108f);

        // Dessiner l'axe principal de l'ellipse à la position choisie
        for (int i = 0; i <= segments; i++)
        {
            float angle = 2f * Mathf.PI * i / segments;
            float x = semiMajorAxis * Mathf.Cos(angle);
            float y = semiMinorAxis * Mathf.Sin(angle);
            
            // Ajouter la position choisie à chaque point
            Vector3 point = new Vector3(x-1, 0f, y+1) + chosenPosition;

            lineRenderer.SetPosition(i, point);
        }
    }
}
