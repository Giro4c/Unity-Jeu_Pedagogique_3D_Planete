using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoTextures : MonoBehaviour
{ public Material material1;
    public Material material2;
    public Cycle cycle;

    void Start()
    {
        SeparateAndRotateMeshes();
    }

    void SeparateAndRotateMeshes()
    {
        // Récupérer le composant MeshFilter de l'objet
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not found!");
            return;
        }

        // Récupérer le maillage
        Mesh originalMesh = meshFilter.mesh;

        // Obtenir le nombre de sous-maillons
        int submeshCount = originalMesh.subMeshCount;

        // Créer un GameObject parent
        GameObject parentObject = new GameObject("SeparatedAndRotatedMeshes");
        parentObject.transform.position = transform.position;
        parentObject.transform.rotation = transform.rotation;

        for (int submeshIndex = 0; submeshIndex < submeshCount; submeshIndex++)
        {
            // Créer un nouvel objet pour chaque sous-maillon
            GameObject subObject = new GameObject("Submesh_" + submeshIndex);
            subObject.transform.parent = parentObject.transform;

            // Ajouter un MeshFilter et un MeshRenderer à l'objet
            MeshFilter subMeshFilter = subObject.AddComponent<MeshFilter>();
            MeshRenderer subMeshRenderer = subObject.AddComponent<MeshRenderer>();

            // Créer un maillage séparé pour le sous-maillon actuel
            Mesh subMesh = ExtractSubmesh(originalMesh, submeshIndex);

            // Assigner le maillage au MeshFilter
            subMeshFilter.mesh = subMesh;

            // Copier les matériaux du sous-maillon original
            subMeshRenderer.materials = new Material[] { (submeshIndex == 0) ? material1 : material2 };

            // Réinitialiser la position et la rotation de l'objet
            subObject.transform.localPosition = Vector3.zero;
            subObject.transform.localRotation = Quaternion.identity;
        }
    }

    Mesh ExtractSubmesh(Mesh originalMesh, int submeshIndex)
    {
        // Créer un nouveau maillage
        Mesh subMesh = new Mesh();

        // Extraire les données du sous-maillon
        subMesh.vertices = originalMesh.vertices;
        subMesh.triangles = originalMesh.GetTriangles(submeshIndex);
        subMesh.normals = originalMesh.normals;
        subMesh.uv = originalMesh.uv;
        subMesh.colors = originalMesh.colors;

        return subMesh;
    }

    void Update()
    {
        RotateUV();
    }

    void RotateUV()
    {
        // Récupérer le composant Renderer
        Renderer renderer = GetComponent<Renderer>();

        if (renderer != null && cycle != null)
        {
            Material material = renderer.materials[0]; // Utilise la première texture du matériau

            // Obtient les coordonnées UV actuelles du matériau
            Vector2 uv = material.GetTextureScale("_MainTex"); // Remplacez "_MainTex" par le nom de votre propriété UV

            // Calcule le déplacement supplémentaire en fonction de la vitesse de rotation
            float rotateSpeed = 1f / cycle.GetPeriod();
            float offsetAmount = rotateSpeed * Time.deltaTime;

            // Applique le déplacement aux coordonnées UV
            uv += new Vector2(offsetAmount, 0);

            // Assure que les coordonnées UV restent dans la plage [0, 1]
            uv.x %= 1.0f;
            uv.y %= 1.0f;

            // Applique les nouvelles coordonnées UV au matériau
            material.SetTextureScale("_MainTex", uv); // Remplacez "_MainTex" par le nom de votre propriété UV
        }
    }

}
