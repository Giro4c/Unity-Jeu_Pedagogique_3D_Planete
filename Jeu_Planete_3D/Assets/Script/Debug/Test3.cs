using System.Collections;
using System.Collections.Generic;
using Script.Core.Quizz.Questions;
using Script.WebData;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        string jsonContent1 = "{\"Num_Ques\":1,\"Enonce\":\"Quelle est la saison où la Terre est la plus proche du soleil ?\",\"Type\":\"QCU\",\"Rep1\":\"Été\",\"Rep2\":\"Automne\",\"Rep3\":\"Hiver\",\"Rep4\":\"Printemps\",\"BonneRep\":\"Hiver\"}";
        string jsonContent2 = "{\"Num_Ques\":10,\"Enonce\":\"Placer la Terre en printemps.\",\"Type\":\"QUESINTERAC\",\"BonneRepValeur_orbit\":0.375,\"Marge_Orbit\":0.125,\"BonneRepValeur_rotation\":-1,\"Marge_Rotation\":-1}";
        string jsonContent3 = "{\"Num_Ques\":50,\"Enonce\":\"Un équinoxe (Moment de l'année ou le jour et la nuit sont de même durée) a lieu en hiver et en été.\",\"Type\":\"VRAIFAUX\",\"Valeur_orbit\":-1,\"Valeur_rotation\":-1,\"BonneRep\":\"Faux\"}";
        
        // Test json qcu
        QuestionQCUReadModel qcuReadModel = JsonUtility.FromJson<QuestionQCUReadModel>(jsonContent1);
        Choice[] choices = new Choice[4];
        choices[0] = new Choice(qcuReadModel.Rep1, qcuReadModel.Rep1 == qcuReadModel.BonneRep) ;
        choices[1] = new Choice(qcuReadModel.Rep2, qcuReadModel.Rep2 == qcuReadModel.BonneRep) ;
        choices[2] = new Choice(qcuReadModel.Rep3, qcuReadModel.Rep3 == qcuReadModel.BonneRep) ;
        choices[3] = new Choice(qcuReadModel.Rep4, qcuReadModel.Rep4 == qcuReadModel.BonneRep) ;
        QuestionQCU q1 = new QuestionQCU(qcuReadModel.Num_Ques, QuestionType.Qcu, qcuReadModel.Enonce, choices);
        
        Debug.Log(q1);
        Debug.Log(q1.id);
        Debug.Log(q1.header);
        Debug.Log(q1.type);
        foreach (Choice choice in q1.choices)
        {
            Debug.Log(choice.value);
            Debug.Log(choice.correct);
        }
        
        // Test json manipulation
        QuestionManipulationReadModel manipulationReadModel = JsonUtility.FromJson<QuestionManipulationReadModel>(jsonContent2);
        QuestionManipulation q2 = new QuestionManipulation(manipulationReadModel.Num_Ques, QuestionType.Manipulation, manipulationReadModel.Enonce, 
            manipulationReadModel.BonneRepValeur_orbit, manipulationReadModel.BonneRepValeur_rotation, 
            manipulationReadModel.Marge_Orbit, manipulationReadModel.Marge_Rotation);
        
        Debug.Log(q2);
        Debug.Log(q2.id);
        Debug.Log(q2.header);
        Debug.Log(q2.type);
        Debug.Log(q2.correctOrbit);
        Debug.Log(q2.correctRotation);
        Debug.Log(q2.marginOrbit);
        Debug.Log(q2.marginRotation);

        
        // test json truefalse
        QuestionTrueFalseReadModel trueFalseReadModel = JsonUtility.FromJson<QuestionTrueFalseReadModel>(jsonContent3);
        Choice[] choices2 = {new Choice("Vrai", false), new Choice("Faux", false)};
        for (int i = 0; i < choices2.Length; ++i)
        {
            choices2[i].correct = choices2[i].value.Equals(trueFalseReadModel.BonneRep);
        }
        QuestionTrueFalse q3 = new QuestionTrueFalse(trueFalseReadModel.Num_Ques, QuestionType.TrueFalse, trueFalseReadModel.Enonce, 
            choices, trueFalseReadModel.Valeur_orbit, trueFalseReadModel.Valeur_rotation);
        
        Debug.Log(q3);
        Debug.Log(q3.id);
        Debug.Log(q3.header);
        Debug.Log(q3.type);
        foreach (Choice choice in q3.choices)
        {
            Debug.Log(choice.value);
            Debug.Log(choice.correct);
        }
        Debug.Log(q3.fixedOrbit);
        Debug.Log(q3.fixedRotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
