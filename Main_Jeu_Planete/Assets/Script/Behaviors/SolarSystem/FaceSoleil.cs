using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceSoleil : MonoBehaviour
{
     public Transform target; // Référence au GameObject cible que vous voulez suivre
    public float rotationSpeed = 5.0f; // Vitesse de rotation

    void Update()
    {
        if (target != null)
        {
            // Calculez la direction de la cible par rapport à la position actuelle de cet objet
            Vector3 directionToTarget = target.position - transform.position;

            // Calculez la rotation nécessaire pour faire face à la cible
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Appliquez la rotation en douceur en utilisant Slerp
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
