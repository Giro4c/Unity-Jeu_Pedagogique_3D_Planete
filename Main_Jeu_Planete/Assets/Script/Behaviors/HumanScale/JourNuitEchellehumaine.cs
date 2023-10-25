using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JourNuitEchellehumaine : MonoBehaviour
{
    public RotationCycle rotationCycleSun; // Référence au script RotationCycle de Directionnal Light
    public RotationCycle rotationCyclePlanet; // Référence au script RotationCycle de la planète vue à l'echelle humaine
    public Orbit orbitPlanet; // Référence au script Orbit de la planète vue à l'echelle humaine
    
    //public float rotationSpeed = 10f; // Vitesse de rotation
    //private float rotatorSpeed ;

    private void Start()
    {
        if (rotationCycleSun == null)
        {
            Debug.LogError("Référence à RotationCycle Sun manquante.");
            enabled = false;
            return;
        }
        if (orbitPlanet == null)
        {
            Debug.LogError("Référence à Orbit Planet manquante.");
            enabled = false;
            return;
        }
        if (rotationCyclePlanet == null)
        {
            Debug.LogError("Référence à RotationCycle Planet manquante.");
            enabled = false;
            return;
        }

        rotationCycleSun.rotatePeriod = rotationCyclePlanet.rotatePeriod;
    }

    private void Update()
    {
        float newProgress = rotationCyclePlanet.rotateProgress - orbitPlanet.orbitProgress;
        if (newProgress < 0)
        {
            newProgress += 1;
        }
        newProgress %= 1f;
        rotationCycleSun.rotateProgress = newProgress;
        rotationCycleSun.SetRotation();

    }
}
