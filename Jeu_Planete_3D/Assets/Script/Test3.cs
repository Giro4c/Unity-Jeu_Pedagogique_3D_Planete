using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    private Question q;
    
    // Start is called before the first frame update
    void Start()
    {
        string jsonContent = "{\"id\":1,\"header\":\"Quelle est la saison où la Terre est la plus proche du soleil ?\",\"type\":\"QCU\",\"Rep1\":\"Été\",\"Rep2\":\"Automne\",\"Rep3\":\"Hiver\",\"Rep4\":\"Printemps\",\"BonneRep\":\"Hiver\"}";
        string jsonContent2 = "{\"id\":50,\"header\":\"Un équinoxe (Moment de l'année ou le jour et la nuit sont de même durée) a lieu en hiver et en été.\",\"type\":\"VRAIFAUX\",\"Valeur_orbit\":null,\"Valeur_rotation\":null,\"BonneRep\":\"Faux\"}";
        
        q = JsonUtility.FromJson<Question>(jsonContent);
        Debug.Log(q);
        Debug.Log(q.header);
        Debug.Log(q.type);
        
        q = JsonUtility.FromJson<Question>(jsonContent2);
        Debug.Log(q);
        Debug.Log(q.header);
        Debug.Log(q.type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
