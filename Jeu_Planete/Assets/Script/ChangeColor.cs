using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    
    private Renderer sphereRenderer;
    [SerializeField] public string toucheColeur;
    
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(toucheColeur))
       {
            sphereRenderer.material.SetColor("_Color",new Color(4,3,5));
       }
       
    }
}
