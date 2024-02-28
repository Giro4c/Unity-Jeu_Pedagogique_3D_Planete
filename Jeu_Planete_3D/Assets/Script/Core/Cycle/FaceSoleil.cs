using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class FaceSoleil : MonoBehaviour
{
    
    [SerializeField] private Transform target; // Référence au GameObject cible que vous voulez suivre
    [SerializeField] private Transform tmp;
    [SerializeField] private Renderer render;
    private MaterialPropertyBlock mpb;
    [SerializeField] private RotationCycle rotationCycle;


    private void Start()
    {
        mpb = new MaterialPropertyBlock ();
        if (target == null)
        {
            enabled = false;
            return;
        }
    }

    void Update()
    {
        // Utiliser la fonction LookAt pour faire tourner l'objet pour qu'il regarde vers le target
        // Transform tmp = new RectTransform();
        // tmp.position = rotationCycle.GetCyclingObject().position;
        // tmp.LookAt(target);
        // float offset = rotationCycle.GetRevolutionSelf().FindProgress(tmp.rotation);
        // offset -= rotationCycle.GetProgress();
        // offset %= 1f;
        
        // Reset rotation of object
        // rotationCycle.SetOrbitingObjectInCycle();
        
        // float face = -90f;
        // Vector3 rotationOffset = new Vector3(0f, face, 0f); // Décalage de rotation
        // transform.Rotate(rotationOffset);
           
         // Ajouter un décalage de rotation supplémentaire
        render.GetPropertyBlock (mpb);
        mpb.SetFloat ("_RotationProgress", rotationCycle.GetProgress());
        // mpb.SetFloat ("_RotationProgress", offset);
        render.SetPropertyBlock (mpb);
    }

}
