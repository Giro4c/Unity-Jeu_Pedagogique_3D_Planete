using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DBGetVF : MonoBehaviour
{
    public ListQuestions questions;
    public DBGetRandomVF id;
    public int[] idQuestion;
    public int qid;

    void Start()
    {
        StartCoroutine(GetVF());
    }

    IEnumerator GetVF()
    {
        // Obtenez les questions aléatoires
        id.GetRandomVF();
        idQuestion = questions.questionsIDsVF;

        // Initialisez qid à la première valeur dans idQuestion
        qid = idQuestion[0];
        string[] listQues = new string[idQuestion.Length];
        for (int count = 0; count < idQuestion.Length; ++count)
        {
            // Utilisez la valeur de qid pour obtenir la question correspondante
            string strVarURLGet = "qid=" + qid;
            string url = "jeupedagogique.alwaysdata.net/views/question.php?" + strVarURLGet;
            Debug.Log(url);

            UnityWebRequest wwwInteract = UnityWebRequest.Get(url);
            yield return wwwInteract.SendWebRequest();

            if (wwwInteract.error != null)
            {
                Debug.LogError(wwwInteract.error);
            }
            else
            {
                // Utilisez wwwInteract.downloadHandler.text de la manière qui convient à votre logique
                Debug.Log(qid);
                Debug.Log(wwwInteract.downloadHandler.text);
                StringHTMLParser htmlParser = new StringHTMLParser(wwwInteract.downloadHandler.text);
                string extratedVal;
                extratedVal = htmlParser.getHTMLContainerContent("p", null, "Enoncer");
                print(extratedVal);
                listQues[count] = extratedVal;
                Debug.Log(listQues[count]); // Ajout de point-virgule
            }

            // Passez à la prochaine valeur dans idQuestion
            if (count < idQuestion.Length - 1)
            {
                qid = idQuestion[count + 1];

            }
        }
        questions.questionStringVF = listQues;
    }
}
