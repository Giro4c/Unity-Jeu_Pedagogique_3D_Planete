using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonRetour : MonoBehaviour
{
    public GameObject canvasToHide; // Référence au Canvas que vous souhaitez rendre invisible

    private bool isCanvasVisible = false; // Le Canvas est initialement visible

    // Fonction appelée lorsque le bouton est cliqué
    public void OnBoutonClique()
    {
         Debug.Log("Le bouton a été cliqué !"); // Vérifiez si ce message s'affiche dans la console
        isCanvasVisible = false; // Inverser la visibilité du Canvas
        canvasToHide.SetActive(isCanvasVisible); // Rendre le Canvas visible ou invisible
    }
}
