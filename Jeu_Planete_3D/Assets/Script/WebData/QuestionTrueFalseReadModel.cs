using System;
using System.ComponentModel;

namespace Script.WebData
{
    [Serializable]
    public class QuestionTrueFalseReadModel
    {
        public int Num_Ques;
        public string Enonce;
        public string Type;
        public float Valeur_orbit;
        public float Valeur_rotation;
        public string BonneRep;
    }
}