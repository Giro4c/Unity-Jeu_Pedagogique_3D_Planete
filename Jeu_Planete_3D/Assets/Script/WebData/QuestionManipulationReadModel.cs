using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;


namespace Script.WebData
{
    [Serializable]
    public class QuestionManipulationReadModel
    {
        public int Num_Ques;
        public string Enonce;
        public string Type;
        public float BonneRepValeur_orbit;
        public float Marge_Orbit;
        public float BonneRepValeur_rotation;
        public float Marge_Rotation;
    }
}