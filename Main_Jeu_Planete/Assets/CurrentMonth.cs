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
    public OrbitMotion sphere ; 
    public OrbitDrag planete;
    public bool isTrue;
    public string[] mois;


    void Update()
    {
            if(Input.GetKeyDown("l"))
            {
                isTrue = true;
            }
            else if (Input.GetKeyDown("k"))
            {
                isTrue = false;
            }
            if(isTrue == true)
            {
                SliderDrag();
                float orbitSpeed = 1f / valueSlider.orbitPeriod;
                valueSlider.orbitProgress -=Time.deltaTime * orbitSpeed; 
            }
            else
            {
                SliderAuto();
            }
       
       
    }

    private void SliderAuto()
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
    
    private void SliderDrag()
    {
        // Lisez la valeur actuelle du slider
        float sliderValue = textSlider.value;
        valueSlider.orbitProgress = sliderValue;
        /*if(planete.orbitActive)
        {
            planete.DragOrbit();
        }*/
        

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
