using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.UI;


public class ManipulationQCM : MonoBehaviour
{
    public CurrentMonth slider;
    public QcmVraiFaux currentQuest;
    [SerializeField] public Slider evalSlider;
    public Orbit position;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void ValeurSlider(float val)
    {  
        evalSlider.value = val;
        position.orbitProgress = val;
    }
    //Permet d'activer  le script
    public void ActiveScript()
    {
        GetComponent<ManipulationQCM>().enabled = true;
    }
    //Permet de desactiver le script
    public void isNotActive()
    {
        GetComponent<ManipulationQCM>().enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(currentQuest.currentQuestion == 0)
        {
            //Valeur du slider
            float val = 1f;
            ValeurSlider(val);
            slider.UpdateTextFromSliderValue(val);
            
        }
        else if(currentQuest.currentQuestion == 1)
        {
            //Valeur du slider
            float val = 0.4f;
            ValeurSlider(val);
            slider.UpdateTextFromSliderValue(val);
            
        }
        else if(currentQuest.currentQuestion == 2)
        {
            //Valeur du slider
            float val = 0.25f;
            ValeurSlider(val);
            slider.UpdateTextFromSliderValue(val);
            
        }
        else if(currentQuest.currentQuestion == 3)
        {
            //Valeur du slider
            float val = 0.7f;
            ValeurSlider(val);
            slider.UpdateTextFromSliderValue(val);
           
        }
        else if(currentQuest.currentQuestion == 4)
        {
            //Valeur du slider
            float val = 0.0f;
            ValeurSlider(val);
            slider.UpdateTextFromSliderValue(val);
           
        }
        else
        {
            slider.SliderAuto();
        }
    }
}
