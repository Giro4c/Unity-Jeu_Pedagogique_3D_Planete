using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RotationCycle))]
public class JourNuitEchellehumaine : MonoBehaviour
{
    public RotationCycle rotationCycleScript; // Référence au script RotationCycle
    //public float rotationSpeed = 10f; // Vitesse de rotation
    private float rotatorSpeed ;

    private void Start()
    {
        if (rotationCycleScript == null)
        {
            Debug.LogError("Référence à RotationCycle manquante.");
            enabled = false;
            return;
        }
        rotatorSpeed = 1f / rotationCycleScript.rotatePeriod;
    }

    private void Update()
    {
        if (rotationCycleScript != null)
        {
            // Calculez la rotation souhaitée en fonction de la progression de RotationCycle
            float rotationAmount = rotatorSpeed * Time.deltaTime;
            rotationCycleScript.rotateProgress += rotationAmount;
            rotationCycleScript.rotateProgress %= 1f;
            rotationCycleScript.SetRotation();
        }
    }
}
