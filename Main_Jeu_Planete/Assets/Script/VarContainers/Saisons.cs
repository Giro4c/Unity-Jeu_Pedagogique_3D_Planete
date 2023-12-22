using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saisons : MonoBehaviour
{
    
    public Orbit orbit;

    // Constants for seasons names
    private const string WINTER = "hiver";
    private const string FALL = "automne";
    private const string SUMMER = "été";
    private const string SPRING = "printemps";
    
    // Constants for seasons start and end
    
    /// <p>Offset for the start of the year. Is the difference of progress between 1st January (Year start)
    /// and 21st December (Winter solstice / Start of winter)</p>
    private const float _START_YEAR_OFFSET = (2f / 73f);
    private const float _WINTER_START = 0f /*- _START_YEAR_OFFSET*/;
    private const float _SPRING_START = 0.25f /*- _START_YEAR_OFFSET*/;
    private const float _SUMMER_START = 0.5f /*- _START_YEAR_OFFSET*/;
    private const float _FALL_START = 0.75f /*- _START_YEAR_OFFSET*/;
    
    // Current season
    private string _saison = WINTER;

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
        if (_SPRING_START <= orbit.orbitProgress && orbit.orbitProgress < _SUMMER_START)
        {
            _saison = SPRING;
        }
        // Eté
        else if (_SUMMER_START <= orbit.orbitProgress && orbit.orbitProgress < _FALL_START)
        {
            _saison = SUMMER;
        }
        // Automne
        else if (_FALL_START <= orbit.orbitProgress && orbit.orbitProgress < _WINTER_START)
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
            if (orbit.orbitProgress >= _FALL_START)
            {
                _saison = FALL;
            }
            else if (orbit.orbitProgress >= _SPRING_START)
            {
                _saison = SPRING;
            }
            else return false;
        }
        else if (_saison.Equals(SPRING))
        {
            if (orbit.orbitProgress >= _SUMMER_START)
            {
                _saison = SUMMER;
            }
            else if (orbit.orbitProgress < _SPRING_START)
            {
                _saison = WINTER;
            }
            else return false;
        }
        else if (_saison.Equals(SUMMER))
        {
            if (orbit.orbitProgress >= _FALL_START)
            {
                _saison = FALL;
            }
            else if (orbit.orbitProgress < _SUMMER_START)
            {
                _saison = SPRING;
            }
            else return false;
        }
        else if (_saison.Equals(FALL))
        {
            if (orbit.orbitProgress < _FALL_START && orbit.orbitProgress >= _SUMMER_START)
            {
                _saison = SUMMER;
            }
            else if (orbit.orbitProgress >= _WINTER_START && orbit.orbitProgress < _FALL_START)
            {
                _saison = WINTER;
            }
            else return false;
        }
        else return false;

        // If we are still in the method, it means we fulfilled the conditions to change season
        return true;
    }
    
}
