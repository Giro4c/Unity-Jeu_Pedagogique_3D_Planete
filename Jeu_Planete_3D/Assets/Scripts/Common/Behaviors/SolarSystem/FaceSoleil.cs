using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleJourNuit : MonoBehaviour
{
    
    public Transform target; // Référence au GameObject cible que vous voulez suivre
    

    void Update()
    {
        if (target != null)
        {
            // Utiliser la fonction LookAt pour faire tourner l'objet pour qu'il regarde vers le target
            transform.LookAt(target);
            float face = -90f;
            Vector3 rotationOffset = new Vector3(0f, face, 0f); // Décalage de rotation

            // Ajouter un décalage de rotation supplémentaire
            transform.Rotate(rotationOffset);
        }
    }

}
