using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeigePluie : MonoBehaviour
{
    public GameObject neige;
    public GameObject pluie;
    public AudioClip sonPluie;
   
    private AudioSource source;
    private bool temps;
    public TerrainSaison changement;
    // Start is called before the first frame update
   void Awake()
   {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
   }

    void Start()
    {
        pluie.SetActive(false);
        neige.SetActive(false);
        temps = false;
        source.clip = sonPluie;

    }

    // Update is called once per frame
    void Update()
    {
        float texture = changement.textureV();
        if (texture >=7.5f && texture < 10f)
        {
            temps = true;
            neige.SetActive(true);
            pluie.SetActive(false);
            source.Pause();
            
        }
        else if (texture >=5f && texture < 7.5f)
        {
            pluie.SetActive(true);
            if (!source.isPlaying)
            {
                source.Play();
            }
        
        }
        else
        {
            pluie.SetActive(false);
            neige.SetActive(false);
            temps = false;
        }
    }
}
