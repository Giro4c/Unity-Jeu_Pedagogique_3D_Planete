using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Globalization;
using UnityEngine.UI;


public class CurrentMonth : MonoBehaviour
{
    [SerializeField] TMP_Text currentMonth;
    [SerializeField] Slider monthSlider; // Assurez-vous d'avoir un champ Slider dans votre script

    void Start()
    {
        DateTime date = DateTime.Now;
        int currentMonth = date.Month;

        // D�finissez la valeur du slider sur le mois actuel
        monthSlider.value = currentMonth;
    }
    // Update is called once per frame
    void Update()
    {
        DateTime date = DateTime.Now;
        CultureInfo culture = new CultureInfo("fr-FR"); // Culture fran�aise
        string monthName = culture.DateTimeFormat.GetMonthName(date.Month);
        monthName = culture.TextInfo.ToTitleCase(monthName);
        currentMonth.text = monthName;
    }

    public void OnSliderValueChanged()
    {
        int selectedMonth = Mathf.RoundToInt(monthSlider.value); // R�cup�rez la valeur du slider
        Debug.Log("Mois s�lectionn� : " + selectedMonth);

        // Mettez � jour le texte avec le nom du mois correspondant � la valeur du slider
        CultureInfo culture = new CultureInfo("fr-FR");
        string monthName = culture.DateTimeFormat.GetMonthName(selectedMonth);
        monthName = culture.TextInfo.ToTitleCase(monthName);
        currentMonth.text = monthName;
    }
}
