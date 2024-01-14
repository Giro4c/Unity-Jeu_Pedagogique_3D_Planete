using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestVrSlider : MonoBehaviour
{
   public Slider slider;
    public GameObject cube;

    // Update is called once per frame
    void Update()
    {
        // Créez un nouveau Vector3 avec la valeur du slider pour la coordonnée x, et utilisez la position actuelle du cube pour les coordonnées y et z.
        Vector3 newPosition = new Vector3(slider.value, cube.transform.position.y, cube.transform.position.z);

        // Appliquez la nouvelle position au cube.
        cube.transform.position = newPosition;
    }
}
