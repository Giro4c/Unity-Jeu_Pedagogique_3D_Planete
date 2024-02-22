using System;
using Script.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Controllers
{
    public class QuizzController : MonoBehaviour
    {

        [SerializeField] private QuizzService _quizzService;
        // private Button _quizzStarter;
        [SerializeField] private int questionsQCU = 0;
        [SerializeField] private int questionsTrueFalse = 0;
        [SerializeField] private int questionsManipulation = 0;

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