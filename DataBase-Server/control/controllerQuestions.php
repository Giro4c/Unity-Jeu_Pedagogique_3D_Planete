<?php
namespace control;

use service\PartieChecking;

class ControllerQuestions {
    protected $questionService;

    public function __construct($questionService) {
        $this->questionService = $questionService;
    }

    public function displayRandomQuestions() {
        // Afficher des questions aléatoires
        $questions = $this->questionService->getRandomQs(0, 0, 0); // Modifier les paramètres selon les besoins
        // Afficher les questions dans la vue appropriée
    }

    public function getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux) {
        // Récupérer un certain nombre de questions de chaque type
        return $this->questionService->getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux);
    }

    public function getHTMLAttributesQ($numQues) {
        // Récupérer les attributs HTML d'une question spécifique
        $questionData = $this->questionService->getQAttributes($numQues);
        // Convertir les données en HTML et les renvoyer
    }

    public function addFinishedQuestion($numQues, $idParty, $duration, $isCorrect) {
        // Ajouter une question terminée à la base de données
        $this->questionService->addQuestionAnswer($numQues, $idParty, $duration, $isCorrect);
    }
}