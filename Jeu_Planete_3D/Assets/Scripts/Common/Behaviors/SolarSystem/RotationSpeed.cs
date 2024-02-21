using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSpeed : MonoBehaviour
{
    public RotationCycle rotationCycleScript; // Référence au script RotationCycle
    public Slider slider; // Référence au slider pour contrôler la vitesse

    private void Start()
    {
        // Vérifiez si la référence au script RotationCycle est attribuée
        if (rotationCycleScript == null)
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

        // Initialisez la valeur du slider avec la valeur actuelle de RotationPeriod
        slider.value = rotationCycleScript.rotatePeriod;
    }
    // Cette fonction est appelée chaque fois que la valeur du slider est modifiée
    public void OnSliderValueChanged()
    {
        // Mettez à jour la vitesse de RotationPeriod avec la valeur actuelle du slider
        rotationCycleScript.rotatePeriod = slider.value;
    }
}
