using System;
using UnityEngine;
using TMPro;

public class CurrentMonth : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    public Orbit valueOrbit;
    public string[] mois;
    /// <p>Offset for the start of the year. Is the difference of progress between 1st January (Year start)
    /// and 21st December (Winter solstice / Start of winter)</p>
    private const float _START_YEAR_OFFSET = (2f / 73f);
    
    void Update()
    {
        for (int i = 0; i < mois.Length; ++i)
        {
            float lowerBound = i / (float)mois.Length + _START_YEAR_OFFSET;
            float upperBound = (i + 1) / (float)mois.Length + _START_YEAR_OFFSET;

            if (upperBound > 1f && lowerBound < 1f)
            {
                if (valueOrbit.orbitProgress >= lowerBound % 1f || valueOrbit.orbitProgress <= upperBound % 1f)
                {
                    displayText.text = mois[i];
                    break;
                }
            }
            else
            {
                if (valueOrbit.orbitProgress >= lowerBound % 1f && valueOrbit.orbitProgress <= upperBound % 1f)
                {
                    displayText.text = mois[i];
                    break;
                }
            }
            
        }
    }

    

    
}
