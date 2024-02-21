using System;
using Script.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Controllers
{
    public class QuizzController : MonoBehaviour
    {

        private QuizzService _quizzService;
        // private Button _quizzStarter;
        private int questionsQCU = 0;
        private int questionsTrueFalse = 0;
        private int questionsManipulation = 0;

        private void Start()
        {
            InitQuizz();
        }

        private void InitQuizz()
        {
            StartCoroutine(_quizzService.InitQuizz(questionsQCU, questionsTrueFalse, questionsManipulation));
        }

        public void StarQuizz()
        {
            _quizzService.StartQuizz();
        }

        public void Next()
        {
            if (!_quizzService.NextQuestion())
            {
                End();
            }
        }

        public void CorrectionAction()
        {
            _quizzService.StartCorrection();
            _quizzService.RegisterUserCurrentAnswerInDatabase();
        }

        private void End()
        {
            _quizzService.EndOfQuizz();
        }
        
        
    }
}