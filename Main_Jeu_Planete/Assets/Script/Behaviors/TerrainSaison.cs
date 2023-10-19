using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSaison : MonoBehaviour
{
    public Terrain terrain; // Référence au composant Terrain
    public int index = 0; // Index du layer à modifier
    public List<Texture2D> texturePrincipal = new List<Texture2D>();
    public List<Texture2D> textureSecondaire = new List<Texture2D>();
    public List<Texture2D> textureTertiaire = new List<Texture2D>();
    private int element ;
    public float speed; // vitesse du changement de texture
    [Range(0f, 10f)]public float texture; //changement de texture entre 0 et 1
    public NatureSaison changement;
    
    public float textureV()
    {
        texture += Time.deltaTime * speed;
        return texture;
    }

    void ChangementSol()
    {
        if (terrain != null)
        {
            TerrainLayer[] terrainLayers = terrain.terrainData.terrainLayers;
        
            if(texture >=10f){
                texture = 0; 
                element = 0;
            }

            if(texture >=0f && texture < 5f){
                element = 0;
            }
            if(texture >=5f && texture < 7.5f){
               element = 1;
            }
            if(texture >=7.5f && texture < 10f){
                element = 2;
            }
            
            if (index >= 0 && index < terrainLayers.Length )
            {
                
                // Modifiez la texture du Terrain Layer
                terrainLayers[0].diffuseTexture = texturePrincipal[element];
                terrainLayers[1].diffuseTexture = textureSecondaire[element];
                terrainLayers[2].diffuseTexture = textureTertiaire[element];
                
                // Appliquez les modifications au terrain
                terrain.terrainData.terrainLayers = terrainLayers;
                element = 0;
               
                Debug.Log("Terrain Layer modifié avec succès.");
            }

            else
            {
                Debug.LogError("Index du Terrain Layer invalide.");
            }
        }
        else
        {
            Debug.LogError("La référence au terrain n'a pas été définie.");
        }
    }
    void Update()
    {
            ChangementSol();
    }
}
