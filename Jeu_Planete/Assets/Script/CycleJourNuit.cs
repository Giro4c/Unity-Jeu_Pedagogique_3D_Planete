using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleJourNuit : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
        [SerializeField] private MaterialPropertyBlock mpb;

        [Range (0f, 1f)]
        [SerializeField] float transitionCoeff;

        [SerializeField] float effectDuration = 10f;
        [SerializeField] bool effectOn;
        [SerializeField] float deltaInc = 0.1F;

        //public for debug
        public float startTime;
        private float Timer;

        void OnEnable () {
            renderer = GetComponent<Renderer> ();
            mpb = new MaterialPropertyBlock ();
        }
        void Update () {
            Timer = (int)Time.time;
            if ((Timer%20) == 0.0f) {
                Debug.Log ("space (increment): " + transitionCoeff);
                //launch Effect
                StartCoroutine (launchTransition ());
            }
            
        }

        IEnumerator launchTransition () {
            startTime = Time.time;
            effectOn = true;
            Debug.Log ("Start coroutine ");
            while (effectOn) {
                //increment transitionCoeff
                transitionCoeff += deltaInc;

                //clamp final value
                transitionCoeff = Mathf.Clamp (transitionCoeff, 0f, 1f);

                //change the Material properties
                renderer.GetPropertyBlock (mpb);
                mpb.SetFloat ("_TransCoeff", transitionCoeff);
                renderer.SetPropertyBlock (mpb);
                //need to stop effect ?
                if ((Time.time - startTime) > effectDuration) {
                    effectOn = false;
                    //décrement transitionCoeff
                    transitionCoeff = 0.0F;
                    mpb.SetFloat ("_TransCoeff", transitionCoeff);
                    renderer.SetPropertyBlock (mpb);
                }

                yield return new WaitForSeconds (0.1f);
                
            }
            Debug.Log ("End coroutine ");
        }
}
