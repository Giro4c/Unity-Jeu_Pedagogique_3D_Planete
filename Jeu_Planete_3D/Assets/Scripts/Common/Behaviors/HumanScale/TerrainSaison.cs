using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TerrainSaison : MonoBehaviour
{

    public Terrain terrain; // Référence au composant Terrain
    
    public List<Texture2D> texturePrincipal = new List<Texture2D>();
    public List<Texture2D> textureSecondaire = new List<Texture2D>();
    public List<Texture2D> textureTertiaire = new List<Texture2D>();
    public List<Texture2D> normalEtMask = new List<Texture2D>();
    
    private string saisonCurrent;
    public Saisons saisons;
    
    private void SetUp()
    {
        saisonCurrent = saisons.GetSaison();
        SetGround(saisons.GetSaison());
    }
    
    IEnumerator ChangeGround()
    {
        while (true)
        {
            if (!saisonCurrent.Equals(saisons.GetSaison()))
            {
                saisonCurrent = saisons.GetSaison();
                SetGround(saisons.GetSaison());
                //print("Changement effectué.");
            }
            
            yield return null;
        }

        yield return null;
    }

    private void SetGround(string season)
    {
        TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;
        
        if (season.Equals(saisons.GetWINTER()))
        {
            terrainLayers[0].maskMapTexture = normalEtMask[3];
            terrainLayers[0].normalMapTexture = normalEtMask[2];

            terrainLayers[0].diffuseTexture = texturePrincipal[2];
            terrainLayers[1].diffuseTexture = textureSecondaire[2];
            terrainLayers[2].diffuseTexture = textureTertiaire[2];
            
        }
        else if (saisonCurrent.Equals(saisons.GetSPRING()))
        {
            terrainLayers[0].maskMapTexture = normalEtMask[1];
            terrainLayers[0].normalMapTexture = normalEtMask[0];

            terrainLayers[0].diffuseTexture = texturePrincipal[0];
            terrainLayers[1].diffuseTexture = textureSecondaire[0];
            terrainLayers[2].diffuseTexture = textureTertiaire[0];    
            
        }
        else if (saisonCurrent.Equals(saisons.GetSUMMER()))
        {
            terrainLayers[0].maskMapTexture = normalEtMask[1];
            terrainLayers[0].normalMapTexture = normalEtMask[0];

            terrainLayers[0].diffuseTexture = texturePrincipal[0];
            terrainLayers[1].diffuseTexture = textureSecondaire[0];
            terrainLayers[2].diffuseTexture = textureTertiaire[0];    
                
        }
        else if (saisonCurrent.Equals(saisons.GetFALL()))
        {
            terrainLayers[0].maskMapTexture = normalEtMask[1];
            terrainLayers[0].normalMapTexture = normalEtMask[0];
            
            terrainLayers[0].diffuseTexture = texturePrincipal[1];
            terrainLayers[1].diffuseTexture = textureSecondaire[1];
            terrainLayers[2].diffuseTexture = textureTertiaire[1];
                
        }
        
        terrain.terrainData.terrainLayers = terrainLayers;
    }

    private void Start()
    {
        if (saisons == null)
        {
            enabled = false;
        }
        SetUp();
        StartCoroutine(ChangeGround());
    }
}
