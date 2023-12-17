using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saisons : MonoBehaviour
{
    
    public Orbit orbit;
    private string _saison = "hiver";

    private const string WINTER = "hiver";
    private const string FALL = "automne";
    private const string SUMMER = "été";
    private const string SPRING = "printemps";

    public string GetWINTER()
    {
        return WINTER;
    }
    public string GetFALL()
    {
        return FALL;
    }
    public string GetSUMMER()
    {
        return SUMMER;
    }
    public string GetSPRING()
    {
        return SPRING;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpSeason();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSeason();
    }

    public string GetSaison()
    {
        return _saison;
    }
    
    private void SetUpSeason()
    {
        // Printemps
        if (0.125 <= orbit.orbitProgress && orbit.orbitProgress < 0.375)
        {
            _saison = SPRING;
        }
        // Eté
        else if (0.375 <= orbit.orbitProgress && orbit.orbitProgress < 0.625)
        {
            _saison = SUMMER;
        }
        // Automne
        else if (0.625 <= orbit.orbitProgress && orbit.orbitProgress < 0.875)
        {
            _saison = FALL;
        }
        // Hiver
        else
        {
            _saison = WINTER;
        }
    }
    
    /// <summary>
    /// Verifies if a season change is necessary / possible and changes the value of the string saison.
    /// </summary>
    /// <returns>True if the conditions for a season change are fulfilled, False otherwise.</returns>
    public bool ChangeSeason()
    {
        if (_saison.Equals(WINTER))
        {
            if (orbit.orbitProgress >= 0.125f && orbit.orbitProgress < 0.875)
            {
                _saison = SPRING;
            }
            else if (orbit.orbitProgress < 0.875 && orbit.orbitProgress > 0.125)
            {
                _saison = FALL;
            }
            else return false;
        }
        else if (_saison.Equals(SPRING))
        {
            if (orbit.orbitProgress >= 0.375f)
            {
                _saison = SUMMER;
            }
            else if (orbit.orbitProgress < 0.125)
            {
                _saison = WINTER;
            }
            else return false;
        }
        else if (_saison.Equals(SUMMER))
        {
            if (orbit.orbitProgress >= 0.625)
            {
                _saison = FALL;
            }
            else if (orbit.orbitProgress < 0.375)
            {
                _saison = SPRING;
            }
            else return false;
        }
        else if (_saison.Equals(FALL))
        {
            if (orbit.orbitProgress >= 0.875)
            {
                _saison = WINTER;
            }
            else if (orbit.orbitProgress < 0.625)
            {
                _saison = SUMMER;
            }
            else return false;
        }
        else return false;

        // If we are still in the method, it means we fulfilled the conditions to change season
        //print("Saison : " + saison);
        //print("Orbit progress : " + orbit.orbitProgress);
        return true;
    }
    
}
