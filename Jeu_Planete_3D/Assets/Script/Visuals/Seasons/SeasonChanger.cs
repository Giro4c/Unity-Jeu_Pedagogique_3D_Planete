using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Visuals.Seasons
{
    public class SeasonChanger : MonoBehaviour
    {

        [SerializeField] private Cycle cycleYear;

        // Constants for seasons start and end
        private const float _WINTER_START = 0f;
        private const float _SPRING_START = 0.25f;
        private const float _SUMMER_START = 0.5f;
        private const float _FALL_START = 0.75f;

        // Current season
        public Season season { get; private set; } = Season.Winter;

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

        private void SetUpSeason()
        {
            // Printemps
            if (_SPRING_START <= cycleYear.GetProgress() && cycleYear.GetProgress() < _SUMMER_START)
            {
                season = Season.Spring;
            }
            // Eté
            else if (_SUMMER_START <= cycleYear.GetProgress() && cycleYear.GetProgress() < _FALL_START)
            {
                season = Season.Summer;
            }
            // Automne
            else if (_FALL_START <= cycleYear.GetProgress() && cycleYear.GetProgress() < _WINTER_START)
            {
                season = Season.Fall;
            }
            // Hiver
            else
            {
                season = Season.Winter;
            }
        }

        /// <summary>
        /// Verifies if a season change is necessary / possible and changes the value of the string saison.
        /// </summary>
        /// <returns>True if the conditions for a season change are fulfilled, False otherwise.</returns>
        public bool ChangeSeason()
        {
            if (season.Equals(Season.Winter))
            {
                if (cycleYear.GetProgress() >= _FALL_START)
                {
                    season = Season.Fall;
                }
                else if (cycleYear.GetProgress() >= _SPRING_START)
                {
                    season = Season.Spring;
                }
                else return false;
            }
            else if (season.Equals(Season.Spring))
            {
                if (cycleYear.GetProgress() >= _SUMMER_START)
                {
                    season = Season.Summer;
                }
                else if (cycleYear.GetProgress() < _SPRING_START)
                {
                    season = Season.Winter;
                }
                else return false;
            }
            else if (season.Equals(Season.Summer))
            {
                if (cycleYear.GetProgress() >= _FALL_START)
                {
                    season = Season.Fall;
                }
                else if (cycleYear.GetProgress() < _SUMMER_START)
                {
                    season = Season.Spring;
                }
                else return false;
            }
            else if (season.Equals(Season.Fall))
            {
                if (cycleYear.GetProgress() < _FALL_START && cycleYear.GetProgress() >= _SUMMER_START)
                {
                    season = Season.Summer;
                }
                else if (cycleYear.GetProgress() >= _WINTER_START && cycleYear.GetProgress() < _FALL_START)
                {
                    season = Season.Winter;
                }
                else return false;
            }
            else return false;

            // If we are still in the method, it means we fulfilled the conditions to change season
            return true;
        }

    }
}