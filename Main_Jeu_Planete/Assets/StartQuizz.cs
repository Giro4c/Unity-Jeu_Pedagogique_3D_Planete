using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQuizz : MonoBehaviour
{
    [SerializeField] GameObject canvasToHide;

    public void Start()
    {
        canvasToHide.SetActive(true);
    }

    public void Quit()
    {
        canvasToHide.SetActive(false);
    }
}
