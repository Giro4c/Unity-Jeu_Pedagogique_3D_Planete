using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSoleil : MonoBehaviour
{
    
    public Transform target; // Référence au GameObject cible que vous voulez suivre
    [SerializeField] private Renderer render;
    [SerializeField] private MaterialPropertyBlock mpb;
    public RotationCycle rotationCycleScript;
    
        private void OnEnable()
    {
        
        mpb = new MaterialPropertyBlock ();
    }

    void Update()
    {
        if (target != null)
        {
            // Utiliser la fonction LookAt pour faire tourner l'objet pour qu'il regarde vers le target
            transform.LookAt(target);
            float face = -90f;
            Vector3 rotationOffset = new Vector3(0f, face, 0f); // Décalage de rotation
            transform.Rotate(rotationOffset);
           
        }
         // Ajouter un décalage de rotation supplémentaire
            

            render.GetPropertyBlock (mpb);
            mpb.SetFloat("_RotationPeriod", rotationCycleScript.rotatePeriod);
            mpb.SetFloat ("_RotationProgress", rotationCycleScript.rotateProgress);
            GetComponent<Renderer>().SetPropertyBlock (mpb);
    }

}
