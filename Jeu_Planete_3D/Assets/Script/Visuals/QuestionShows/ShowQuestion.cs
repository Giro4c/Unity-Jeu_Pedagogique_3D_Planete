using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class ShowQuestion : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI header;

    public virtual void ShowTheQuestion(Question question)
    {
        // Get question text
        header.text = question.header;
        
    }
    
}
