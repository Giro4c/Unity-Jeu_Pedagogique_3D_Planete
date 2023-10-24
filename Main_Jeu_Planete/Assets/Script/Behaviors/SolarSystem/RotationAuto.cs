using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotationCycle))]
public class RotationAuto : MonoBehaviour
{
    private RotationCycle rotationCycleScript;
    public bool autoRotate = true;
    public Transform target; // Référence au GameObject cible que vous voulez suivre
    public float rotationSpeed = 5.0f; // Vitesse de rotation
    IEnumerator AutoRotation()
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
        yield return null;
    }

    private void OnDisable()
    {
        autoRotate = false;
        StopCoroutine(AutoRotation());
    }

    private void OnEnable()
    {
        rotationCycleScript = gameObject.GetComponent<RotationCycle>();
        autoRotate = true;
        StartCoroutine(AutoRotation());
    }
}
