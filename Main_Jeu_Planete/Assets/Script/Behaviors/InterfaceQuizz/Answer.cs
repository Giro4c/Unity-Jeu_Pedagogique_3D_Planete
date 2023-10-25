using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QcmVraiFaux quizzManager;
    public Button myButton;

    public void Answers()
    {
        if(isCorrect)
        {
            Debug.Log("Vraie");
            Image buttonImage = myButton.GetComponent<Image>();
            buttonImage.color = new Color(0.0f, 1.0f, 0.0f, 1.0f);
        
        }
        else
        {
            Debug.Log("Faux");
            Image buttonImage = myButton.GetComponent<Image>();
            buttonImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            
        }
    }
}
