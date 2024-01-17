using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleJourNuit : MonoBehaviour
{
        [SerializeField] private Renderer render;
        [SerializeField] private MaterialPropertyBlock mpb;
        public RotationCycle cycle;

        void OnEnable () {
            render = GetComponent<Renderer> ();
            mpb = new MaterialPropertyBlock ();
        }
        void Update () {
            
                //change the Material properties
                render.GetPropertyBlock (mpb);
                mpb.SetFloat ("_Rotation", cycle.rotatePeriod/10);
                GetComponent<Renderer>().SetPropertyBlock (mpb);
            
        }

}
