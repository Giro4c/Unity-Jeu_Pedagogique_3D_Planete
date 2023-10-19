using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureSaison : MonoBehaviour
{
    public TerrainSaison terrain; // Référence au composant Terrain
    public List<GameObject> printemps = new List<GameObject>();
    public List<GameObject> ete = new List<GameObject>();
    public List<GameObject> automne = new List<GameObject>();
    public List<GameObject> hiver = new List<GameObject>();
    public int index = 0;
    [Range(0f, 4f)]public float slider;
    private int element = 0;
    
    public float sliderV()
    {
         slider += Time.deltaTime*7;
         return slider;
    }

    void Changement()
    {
        if (terrain.terrain != null)
        {
            TerrainData terrainData = terrain.terrain.terrainData;

            // Incrémente la valeur de texture en fonction du temps
            float texture = terrain.textureV();
            slider += Time.deltaTime*7;

            if (texture >= 10f)
            {
                texture = 0;
                slider = 0;
               
            }

            // Copiez les TreePrototypes actuels du terrain dans une liste modifiable
            List<TreePrototype> newTreePrototypes = new List<TreePrototype>(terrainData.treePrototypes);

            if (index >= 0 && index < newTreePrototypes.Count)
            {
                GameObject saison;

                // Sélectionnez le préfab d'arbre en fonction de la saison (printemps, été, automne, hiver)
                if (texture >= 0f && texture < 2.5f)
                {
                    saison = printemps[element];
                }
                else if (texture >= 2.5f && texture < 5f)
                {
                    saison = ete[element];
                }
                else if (texture >= 5f && texture < 7.5f)
                {
                    saison = automne[element];
                }
                else
                {
                    saison = hiver[element];
                }

                // Modifiez le préfab d'arbre à l'index spécifié
                newTreePrototypes[index].prefab = saison;
            }
            else
            {
                Debug.LogError("Index du préfab d'arbre à modifier invalide.");
            }

            // Appliquez les modifications aux TreePrototypes du terrain
            terrainData.treePrototypes = newTreePrototypes.ToArray();
            index = 0;
            element = 0;

            Debug.Log("Préfabs d'arbres du terrain modifiés avec succès.");
        }
        else
        {
            Debug.LogError("La référence au terrain n'a pas été définie.");
        }
    }
    public void incrementation()
    {
        // Incrémente l'index et l'élément en fonction de la valeur de slider
        if (slider >= 0f && slider < 1f)
        {
            index++;
            element++;
        }
        else if (slider >= 1f && slider < 2f)
        {
            index += 2; // Incrémente de 2
            element += 2; // Incrémente de 2
        }
        else if (slider >= 2f && slider < 3f)
        {
            index += 3; // Incrémente de 3
            element += 3; // Incrémente de 3
        }

        // Assurez-vous que slider reste dans la plage [0, 4] en réinitialisant à 0 si supérieur à 4
        if (slider > 4f)
        {
            slider = 0f;
        }
    }
    void Update()
    {
        Changement();
        incrementation();
    }
}
