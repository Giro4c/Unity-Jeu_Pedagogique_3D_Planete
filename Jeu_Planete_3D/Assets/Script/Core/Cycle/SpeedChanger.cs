using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpeedChanger : MonoBehaviour
{
    public Cycle rotationCycle; // Référence au script RotationCycle
    public Cycle orbit;
    public Slider slider; // Référence au slider pour contrôler la vitesse

    private void Start()
    {
        // Vérifiez si la référence au script RotationCycle est attribuée
        if (rotationCycle == null)
        {
            Debug.LogError("RotationCycle script reference is not set.");
            enabled = false; // Désactivez le script s'il n'est pas correctement configuré
        }

        // Vérifiez si la référence au slider est attribuée
        if (slider == null)
        {
            Debug.LogError("Slider reference is not set.");
            enabled = false; // Désactivez le script s'il n'est pas correctement configuré
        }

        // Initialisez la valeur du slider avec la valeur par défaut
        slider.value = 1;
    }
    // Cette fonction est appelée chaque fois que la valeur du slider est modifiée
    public void ChangeSpeedValue()
    {
        // Mettez à jour la vitesse de RotationPeriod avec la valeur actuelle du slider
        rotationCycle.SetPeriod(rotationCycle.GetDefaultPeriod() / slider.value);
        orbit.SetPeriod(orbit.GetDefaultPeriod() / slider.value);
    }
}
