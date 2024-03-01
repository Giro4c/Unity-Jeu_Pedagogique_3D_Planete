/*
using System;
using UnityEngine;
using TMPro;

public class CurrentHour : MonoBehaviour
{
    [SerializeField] private TMP_Text displayText;
    //public Orbit valueOrbit;
    public RotationCycle valueRotationDay;
    private float _hourFloat = 0f;
    
    private void Start()
    {
        UpdateHourAndText();
    }

    void Update()
    {
        UpdateHourAndText();
    }

    private void UpdateHourAndText()
    {
        _hourFloat = GetHourFloat();
        displayText.text = GetHourText();
    }

    private int getHour(float hourDigit)
    {
        return (int) Math.Floor(hourDigit);
    }

    private int getMinutes(float hourDigit)
    {
        return (int) Math.Floor((hourDigit % 1f) * 60);
    }

    private float GetHourFloat()
    {
        return valueRotationDay.rotateProgress * 24;
    }

    private string GetHourText()
    {
        string text = "" + getHour(_hourFloat) + " : ";
        int min = getMinutes(_hourFloat);
        if (min < 10)
        {
            text += "0";
        }

        text += min;
        return text;
    }
}
*/
