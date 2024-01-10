using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSaison : MonoBehaviour
{
    public Terrain terrain; // Référence au composant Terrain
    public List<GameObject> printemps = new List<GameObject>();
    public List<GameObject> ete = new List<GameObject>();
    public List<GameObject> automne = new List<GameObject>();
    public List<GameObject> hiver = new List<GameObject>();
    
    public Saisons saisons;
    private string saisonCurrent = "hiver";

    private void Start()
    {
        if (saisons == null)
        {
            enabled = false;
        }
        SetUp();
        StartCoroutine(Changement());
    }
    
    IEnumerator Changement()
    {
        while (true)
        {
            if (!saisonCurrent.Equals(saisons.GetSaison()))
            {
                saisonCurrent = saisons.GetSaison();
                SetTreesSeason(saisons.GetSaison());
                //print("Changement effectué.");
            }
            yield return null;
        }
        yield return null;
    }
    
    private void SetUp()
    {
        saisonCurrent = saisons.GetSaison();
        SetTreesSeason(saisons.GetSaison());
    }

    /// <summary>
    /// A method that changes all the TreePrototypes in a terrain to their counterpart in the given season.
    /// </summary>
    /// <param name="season">The name of the season for the terrain environment</param>
    private void SetTreesSeason(string season)
    {
        // Copiez les TreePrototypes actuels du terrain dans une liste modifiable
        List<TreePrototype> newTreePrototypes = new List<TreePrototype>(terrain.terrainData.treePrototypes);
        // Verify which array of TreePrototypes to use depending on the season
        if (season.Equals(saisons.GetSPRING()))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = printemps[i];
            }
        }
        else if (season.Equals(saisons.GetSUMMER()))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = ete[i];
            }
        }
        else if (season.Equals(saisons.GetFALL()))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = automne[i];
            }
        }
        else if (season.Equals(saisons.GetWINTER()))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = hiver[i];
            }
        }
        // Appliquez les modifications aux TreePrototypes du terrain
        terrain.terrainData.treePrototypes = newTreePrototypes.ToArray();
    }

    
}
