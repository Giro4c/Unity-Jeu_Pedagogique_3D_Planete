using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleJourNuit : MonoBehaviour
{
        [SerializeField] private Renderer render;
        [SerializeField] private MaterialPropertyBlock mpb;

        [Range (-1f, 1f)]
        [SerializeField] float cycle = 0.1f;

        void OnEnable () {
            render = GetComponent<Renderer> ();
            mpb = new MaterialPropertyBlock ();
        }
        void Update () {
            
                //change the Material properties
                render.GetPropertyBlock (mpb);
                mpb.SetFloat ("_Rotation", cycle);
                GetComponent<Renderer>().SetPropertyBlock (mpb);
            
        }

}
