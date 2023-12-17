using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeigePluie : MonoBehaviour
{
    public GameObject neige;
    public GameObject pluie;
    public AudioClip sonPluie;
   
    private AudioSource source;
    
    public Saisons saisons;
    private string saisonCurrent = "hiver";
    
    // Start is called before the first frame update
   void Awake()
   {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();
   }

    void Start()
    {
        SetUp();
        StartCoroutine(ChangeWeather());
    }
    
    private void SetUp()
    {
        saisonCurrent = saisons.GetSaison();
        source.clip = sonPluie;
        SetWeather(saisons.GetSaison());
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void SetAll()
    {
        saisonCurrent = saisons.GetSaison();
        SetWeather(saisons.GetSaison());
    }
    
    IEnumerator ChangeWeather()
    {
        while (true)
        {
            if (!saisonCurrent.Equals(saisons.GetSaison()))
            {
                SetAll();
                //print("Changement effectué.");
            }
            
            yield return null;
        }

        yield return null;
    }

    private void SetWeather(string season)
    {
        if (season.Equals(saisons.GetWINTER()))
        {
            neige.SetActive(true);
            pluie.SetActive(false);
            source.Pause();
        }
        else if (saisonCurrent.Equals(saisons.GetFALL()))
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
            source.Pause();
        }
    }
    
}
