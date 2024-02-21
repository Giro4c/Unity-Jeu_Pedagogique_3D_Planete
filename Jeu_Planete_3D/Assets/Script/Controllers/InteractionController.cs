using System;
using Script.Services;
using UnityEngine;

namespace Script.Controllers
{
    public class InteractionController : MonoBehaviour
    {

        private InteractionChecking _interactionChecker;
        private QuizzService _quizzService;
        private int inMemoryQuestionIndex = -1;

        private void Start()
        {
            ActivateAll();
        }

        private void Update()
        {
            ManageInteractions();
            AddInteractionsToDatabaseAndResetFinish();
        }

        public void ManageInteractions()
        {
            if (_quizzService.IsQuizzStarted() && inMemoryQuestionIndex != _quizzService.indexCurrentQuestion)
            {
                inMemoryQuestionIndex = _quizzService.indexCurrentQuestion;
                _interactionChecker.NewRestrictions(_quizzService.GetRestrictableToEnable(), _quizzService.GetRestrictableToDisableAndRestrict());
            }
            _interactionChecker.ManageControls();
        }

        public void AddInteractionsToDatabaseAndResetFinish()
        {
            _interactionChecker.ResetFinishedInteractionsAndRegisterCycleToDatabaseIfPossible(_quizzService.IsQuizzStarted());
        }


        public void ActivateAll()
        {
            _interactionChecker.NewRestrictions(new []{ "Detector ", "SubScript " }, new string[0]);
        }
        public void DeactivateAll()
        {
            _interactionChecker.NewRestrictions(new string[0], new []{ "Detector Cycle", "SubScript AutoMotion" });
        }
        
        public void ActivateDetector()
        {
            _interactionChecker.NewRestrictions(new []{ "Detector Cycle" }, new string[0]);
        }
        public void DeactivateDetector()
        {
            _interactionChecker.NewRestrictions(new string[0], new []{ "Detector Cycle" });
        }
        
        public void ActivateAutoMotion()
        {
            _interactionChecker.NewRestrictions(new []{ "SubScript AutoMotion" }, new string[0]);
        }
        public void DeactivateAutoMotion()
        {
            _interactionChecker.NewRestrictions(new string[0], new []{ "SubScript AutoMotion" });
        }

        public void DeactivateAllOrbitRelated()
        {
            _interactionChecker.NewRestrictions(new string[0], new []{ "Cycle Orbit" });
        }
        public void DeactivateAllRotationCycleRelated()
        {
            _interactionChecker.NewRestrictions(new string[0], new []{ "Cycle Rotation" });
        }
        
    }
}