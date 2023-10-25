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

    public Orbit orbit;
    private string saison = "hiver";
    

    private void Start()
    {
        SetUp();
        StartCoroutine(Changement());
    }
    
    IEnumerator Changement()
    {
        while (true)
        {
            if (ChangeSeason())
            {
                SetTreesSeason(saison);
                print("Changement effectué.");
            }
            yield return null;
        }
        yield return null;
    }
    
    private void SetUp()
    {
        SetUpSeason();
        SetTreesSeason(saison);
    }

    private void SetUpSeason()
    {
        // Printemps
        if (0.125 <= orbit.orbitProgress && orbit.orbitProgress < 0.375)
        {
            saison = "printemps";
        }
        // Eté
        else if (0.375 <= orbit.orbitProgress && orbit.orbitProgress < 0.625)
        {
            saison = "été";
        }
        // Automne
        else if (0.625 <= orbit.orbitProgress && orbit.orbitProgress < 0.875)
        {
            saison = "automne";
        }
        // Hiver
        else
        {
            saison = "hiver";
        }
    }

    /// <summary>
    /// Verifies if a season change is necessary / possible and changes the value of the string saison.
    /// </summary>
    /// <returns>True if the conditions for a season change are fulfilled, False otherwise.</returns>
    private bool ChangeSeason()
    {
        if (saison.Equals("hiver"))
        {
            if (orbit.orbitProgress >= 0.125f && orbit.orbitProgress < 0.875)
            {
                saison = "printemps";
            }
            else if (orbit.orbitProgress < 0.875 && orbit.orbitProgress > 0.125)
            {
                saison = "automne";
            }
            else return false;
        }
        else if (saison.Equals("printemps"))
        {
            if (orbit.orbitProgress >= 0.375f)
            {
                saison = "été";
            }
            else if (orbit.orbitProgress < 0.125)
            {
                saison = "hiver";
            }
            else return false;
        }
        else if (saison.Equals("été"))
        {
            if (orbit.orbitProgress >= 0.625)
            {
                saison = "automne";
            }
            else if (orbit.orbitProgress < 0.375)
            {
                saison = "printemps";
            }
            else return false;
        }
        else if (saison.Equals("automne"))
        {
            if (orbit.orbitProgress >= 0.875)
            {
                saison = "hiver";
            }
            else if (orbit.orbitProgress < 0.625)
            {
                saison = "été";
            }
            else return false;
        }
        else return false;

        // If we are still in the method, it means we fulfilled the conditions to change season
        print("Saison : " + saison);
        print("Orbit progress : " + orbit.orbitProgress);
        return true;
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
        if (saison.Equals("printemps"))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = printemps[i];
            }
        }
        else if (saison.Equals("été"))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = ete[i];
            }
        }
        else if (saison.Equals("automne"))
        {
            for (int i = 0; i < newTreePrototypes.Count; ++i)
            {
                newTreePrototypes[i].prefab = automne[i];
            }
        }
        else if (saison.Equals("hiver"))
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
