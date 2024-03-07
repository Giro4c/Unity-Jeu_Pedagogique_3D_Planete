using System;
using TMPro;

public class CurrentHourDisplayer : InformationCycleDisplayer
{

    private float _hourFloat = 0f;

    public override void Display()
    {
        _hourFloat = GetHourFloat();
        displayText.text = GetHourText();
    }

    private int GetHour(float hourDigit)
    {
        return (int) Math.Floor(hourDigit);
    }

    private int GetMinutes(float hourDigit)
    {
        return (int) Math.Floor((hourDigit % 1f) * 60);
    }

    private float GetHourFloat()
    {
        return valueCycle.GetProgress() * 24;
    }

    private string GetHourText()
    {
        string text = "" + GetHour(_hourFloat) + " : ";
        int min = GetMinutes(_hourFloat);
        if (min < 10)
        {
            text += "0";
        }

        text += min;
        return text;
    }
}
