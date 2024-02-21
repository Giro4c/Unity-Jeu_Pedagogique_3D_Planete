using System.Collections;
using UnityEngine;

namespace Visuals.Seasons
{

    [RequireComponent(typeof(Terrain), typeof(TerrainCollider))]
    public class TerrainChanger : MonoBehaviour
    {
        [SerializeField] private SeasonChanger seasonChanger;

        [SerializeField] protected TerrainData dataWinter;
        [SerializeField] protected TerrainData dataSpring;
        [SerializeField] protected TerrainData dataSummer;
        [SerializeField] protected TerrainData dataFall;

        private Season _season = Season.Winter;

        private Terrain _terrain;
        private TerrainCollider _terrainCollider;


        private void Start()
        {
            // Find private component in current gameObject
            _terrain = gameObject.GetComponent<Terrain>();
            _terrainCollider = gameObject.GetComponent<TerrainCollider>();

            if (seasonChanger == null)
            {
                enabled = false;
            }

            SetUp();
            StartCoroutine(Changement());
        }

        IEnumerator Changement()
        {
            while (enabled)
            {
                if (!_season.Equals(seasonChanger.season))
                {
                    _season = seasonChanger.season;
                    SetSeasonTerrain(seasonChanger.season);
                    //print("Changement effectué.");
                }

                yield return null;
            }
        }

        private void SetUp()
        {
            _season = seasonChanger.season;
            SetSeasonTerrain(seasonChanger.season);
        }

        /// <summary>
        /// A method that enables the gameObject with the terrain for the current season and
        /// disables the gameObjects with the terrains for the other seasons.
        /// </summary>
        /// <param name="season">The name of the season for the terrain environment</param>
        private void SetSeasonTerrain(Season season)
        {
            if (season.Equals(seasonChanger.season))
            {
                // Terrain : Change terrain data
                _terrain.terrainData = dataSpring;
                // TerrainCollider : Change terrain data
                _terrainCollider.terrainData = dataSpring;
            }
            else if (season.Equals(seasonChanger.season))
            {
                // Terrain : Change terrain data
                _terrain.terrainData = dataSummer;
                // TerrainCollider : Change terrain data
                _terrainCollider.terrainData = dataSummer;
            }
            else if (season.Equals(seasonChanger.season))
            {
                // Terrain : Change terrain data
                _terrain.terrainData = dataFall;
                // TerrainCollider : Change terrain data
                _terrainCollider.terrainData = dataFall;
            }
            else if (season.Equals(seasonChanger.season))
            {
                // Terrain : Change terrain data
                _terrain.terrainData = dataWinter;
                // TerrainCollider : Change terrain data
                _terrainCollider.terrainData = dataWinter;
            }

        }

    }

}