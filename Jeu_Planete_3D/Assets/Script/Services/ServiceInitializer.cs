using System;
using Script.Core.Quizz.Questions;
using UnityEngine;

namespace Script.Services
{
    public class ServiceInitializer : MonoBehaviour
    {

        [Header("Quizz Service")]
        [SerializeField] private QuizzService _quizzService;
        [SerializeField] private QuestionType[] associatedTypes;
        [SerializeField] private ShowQuestion[] associatedShows;
        [SerializeField] private GameObject[] associatedQuestionPanels;
        
        [Header("Interaction Checker")]
        [SerializeField] private InteractionChecking _interactionChecking;
        [SerializeField] private string[] identifiers;
        [SerializeField] private bool[] restrictionsActivation;
        [SerializeField] private MonoBehaviour[] scripts;
        
        /// <summary>
        /// <para>
        /// Initialize the service class QuizzService based on the values stored in the 3 serializable arrays :<br/>
        /// - QuestionType[] associatedTypes<br/>
        /// - ShowQuestion[] associatedShows<br/>
        /// - GameObject[] associatedQuestionPanels<br/>
        /// </para>
        /// </summary>
        public void InitQuizzService()
        {
            _quizzService.Initialize(associatedTypes, associatedShows, associatedQuestionPanels);
        }
        
        /// <summary>
        /// <para>
        /// Initialize the service class InteractionChecking based on the values stored in the 3 serializable arrays :<br/>
        /// - string[] identifiers<br/>
        /// - bool[] restrictionsActivation<br/>
        /// - MonoBehavior[] scripts<br/>
        /// </para>
        /// </summary>
        public void InitInteractionChecker()
        {
            _interactionChecking.Initialize(identifiers, restrictionsActivation, scripts);
        }

        private void Start()
        {
            InitInteractionChecker();
            InitQuizzService();
        }
    }
}