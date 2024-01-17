using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Terrain), typeof(TerrainCollider))]
public class SeasonChanger : MonoBehaviour
{
    [SerializeField] private Saisons saisons;
    
    public TerrainData dataWinter;
    public TerrainData dataSpring;
    public TerrainData dataSummer;
    public TerrainData dataFall;
    
    private string _currentSeason = "hiver";

    private Terrain _terrain;
    private TerrainCollider _terrainCollider;


    private void Start()
    {
        // Find private component in current gameObject
        _terrain = gameObject.GetComponent<Terrain>();
        _terrainCollider = gameObject.GetComponent<TerrainCollider>();
        
        if (saisons == null)
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
            if (!_currentSeason.Equals(saisons.GetSaison()))
            {
                _currentSeason = saisons.GetSaison();
                SetSeasonTerrain(saisons.GetSaison());
                //print("Changement effectué.");
            }
            yield return null;
        }
    }
    
    private void SetUp()
    {
        _currentSeason = saisons.GetSaison();
        SetSeasonTerrain(saisons.GetSaison());
    }

    /// <summary>
    /// A method that enables the gameObject with the terrain for the current season and
    /// disables the gameObjects with the terrains for the other seasons.
    /// </summary>
    /// <param name="season">The name of the season for the terrain environment</param>
    private void SetSeasonTerrain(string season)
    {
        if (season.Equals(saisons.GetSPRING()))
        {
            // Terrain : Change terrain data
            _terrain.terrainData = dataSpring;
            // TerrainCollider : Change terrain data
            _terrainCollider.terrainData = dataSpring;
        }
        else if (season.Equals(saisons.GetSUMMER()))
        {
            // Terrain : Change terrain data
            _terrain.terrainData = dataSummer;
            // TerrainCollider : Change terrain data
            _terrainCollider.terrainData = dataSummer;
        }
        else if (season.Equals(saisons.GetFALL()))
        {
            // Terrain : Change terrain data
            _terrain.terrainData = dataFall;
            // TerrainCollider : Change terrain data
            _terrainCollider.terrainData = dataFall;
        }
        else if (season.Equals(saisons.GetWINTER()))
        {
            // Terrain : Change terrain data
            _terrain.terrainData = dataWinter;
            // TerrainCollider : Change terrain data
            _terrainCollider.terrainData = dataWinter;
        }
        
    }

    
}
