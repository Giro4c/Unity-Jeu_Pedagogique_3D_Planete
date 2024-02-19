using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeTerre : MonoBehaviour
{ 
    // Référence au GameObject représentant la Terre
    public GameObject terre;

    // Épaisseur de la ligne
    public float lineWidth = 0.1f;

    // Longueur de la ligne
    public float lineLength = 2.0f;

    // Angle d'inclinaison en degrés
    public float inclinationAngle = 23f;

    // Couleur de la ligne
    public Color lineColor = Color.green;

    private LineRenderer lineRenderer;

    void Start()
    {
        // Vérifie si la référence à la Terre est définie
        if (terre == null)
        {
            Debug.LogError("La référence à la Terre n'est pas définie.");
            return;
        }

        // Crée un nouveau GameObject pour représenter la ligne
        GameObject verticalLine = new GameObject("VerticalLine");

        // Assigne la Terre comme parent de la ligne
        verticalLine.transform.parent = terre.transform;

        // Place la ligne au centre de la Terre
        verticalLine.transform.localPosition = Vector3.zero;

        // Ajoute le composant LineRenderer à la ligne
        lineRenderer = verticalLine.AddComponent<LineRenderer>();

        // Définit les paramètres de la ligne
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        // Incline la ligne autour de l'axe X
        verticalLine.transform.rotation = Quaternion.Euler(inclinationAngle, 0f, 0f);
    }

    void Update()
    {
        if (terre != null && lineRenderer != null)
        {
            // Met à jour la position de la ligne pour suivre la Terre
            lineRenderer.SetPosition(0, terre.transform.position + Vector3.down * lineLength / 2);
            lineRenderer.SetPosition(1, terre.transform.position + Vector3.up * lineLength / 2);
        }
    }
}
