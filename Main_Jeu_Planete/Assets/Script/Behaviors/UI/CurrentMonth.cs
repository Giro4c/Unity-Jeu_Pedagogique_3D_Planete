using System;
using UnityEngine;
using TMPro;

public class CurrentMonth : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    public Orbit valueOrbit;
    public string[] mois;

    private void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < mois.Length; i++)
        {
            float lowerBound = i / (float)mois.Length;
            float upperBound = (i + 1) / (float)mois.Length;

            if (valueOrbit.orbitProgress >= lowerBound && valueOrbit.orbitProgress <= upperBound)
            {
                displayText.text = mois[i];
                break;
            }
        }
    }

    

    
}
