using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class ShowManipulation : ShowQuestion
{
    
    [SerializeField] protected TextMeshProUGUI correctionText;
    [SerializeField] protected Cycle orbit;
    [SerializeField] protected Cycle rotation;

    public TextMeshProUGUI GetCorrectionText()
    {
        return correctionText;
    }

    public Cycle GetOrbit()
    {
        return orbit;
    }
    
    public Cycle GetRotation()
    {
        return rotation;
    }

}
