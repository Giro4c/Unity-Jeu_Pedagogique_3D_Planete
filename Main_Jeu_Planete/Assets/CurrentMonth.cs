using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Globalization;
using UnityEngine.UI;


public class CurrentMonth : MonoBehaviour
{

    [SerializeField] TMP_Text displayText; // Référence à l'objet TMP_Text
    [SerializeField]  Slider textSlider;
    public Orbit valueSlider;
    public string[] mois;


    void Update()
    {
        float sliderValue = valueSlider.orbitProgress;
        textSlider.value = sliderValue;

        for (int i = 0; i < mois.Length; i++)
        {
            float lowerBound = i / (float)mois.Length;
            float upperBound = (i + 1) / (float)mois.Length;

            if (sliderValue >= lowerBound && sliderValue <= upperBound)
            {
                displayText.text = mois[i];
                break; // Sort de la boucle une fois que le mois est trouvé
            }
        }
    }
}
