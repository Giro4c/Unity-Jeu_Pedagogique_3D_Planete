using TMPro;
using UnityEngine;

public class TimerDisplayer : InformationDisplayer
{

    private static float elapsedTimeStatic;
    private float elapsedTime;


    public override void Display()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        displayText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Mettre à jour la variable statique
        elapsedTimeStatic = elapsedTime;
    }
}
