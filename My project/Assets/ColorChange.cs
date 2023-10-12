using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
   [SerializeField]
   private Material[] mycolor;
   Renderer rend ;
   public string inputPre;

   void Start()
   {
    rend = GetComponent<Renderer>();
    rend.enabled=true;
    rend.sharedMaterial = mycolor[0];
    
   }

   void Update()
   {
    if(Input.GetKey("r"))
    {
       rend.sharedMaterial = mycolor[1];
    }
    else 
    {
        rend.sharedMaterial = mycolor[0];
    }

   }
}
 