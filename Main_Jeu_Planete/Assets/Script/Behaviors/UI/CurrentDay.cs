using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class Day : MonoBehaviour
{
    [SerializeField] TMP_Text currentDay;

    // Update is called once per frame
    void Update()
    {
        currentDay.text = DateTime.Now.ToString("dd");
    }
}
