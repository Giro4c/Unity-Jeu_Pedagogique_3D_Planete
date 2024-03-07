using System;
using Script.Services;
using UnityEngine;

namespace Script.Controllers
{
    public class InteractionController : MonoBehaviour
    {

        [SerializeField] private InteractionChecking _interactionChecker;
        [SerializeField] private QuizzService _quizzService;
        private int inMemoryQuestionIndex = -1;
        private bool inMemoryCorrectionDone = true;

        private void Start()
        {
            _interactionChecker.Initialize();
            ActivateAll();
        }

        private void Update()
        {
            ManageInteractions();
            AddInteractionsToDatabaseAndResetFinish();
        }

        public void ManageInteractions()
        {
            if (_quizzService.IsQuizzStarted())
            {
                if (inMemoryQuestionIndex != _quizzService.indexCurrentQuestion)
                {
                    Debug.Log("New question : index = " + _quizzService.indexCurrentQuestion);
                    inMemoryQuestionIndex = _quizzService.indexCurrentQuestion;
                    inMemoryCorrectionDone = _quizzService.correctionDone;
                    _interactionChecker.NewRestrictions(_quizzService.GetRestrictableToDisableAndRestrict());
                }
                else if (inMemoryCorrectionDone != _quizzService.correctionDone)
                {
                    Debug.Log("Correction started : " + _quizzService.indexCurrentQuestion + "  " + _quizzService.correctionDone);
                    inMemoryCorrectionDone = _quizzService.correctionDone;
                    _interactionChecker.NewRestrictions(_quizzService.GetRestrictableToDisableAndRestrict());
                }
            }
            _interactionChecker.ManageControls();
        }

        public void AddInteractionsToDatabaseAndResetFinish()
        {
            _interactionChecker.ResetFinishedInteractionsAndRegisterCycleToDatabaseIfPossible(_quizzService.IsQuizzStarted());
        }


        public void ActivateAll()
        {
            _interactionChecker.NewRestrictions(new string[0]);
        }
        public void DeactivateAll()
        {
            _interactionChecker.NewRestrictions(new []{ "Detector Cycle", "SubScript AutoMotion" });
        }
        
    }
}