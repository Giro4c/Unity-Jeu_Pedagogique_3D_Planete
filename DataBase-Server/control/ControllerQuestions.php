<?php

namespace control;

use service\PartieChecking;

class ControllerQuestions
{
    private PartieChecking $questionService;

    public function __construct(PartieChecking $questionService) {
        $this->questionService = $questionService;
    }

    public function displayRandomQuestions(): void {
        // Afficher des questions aléatoires
        $questions = $this->questionService->getRandomQs(5, 3, 2);
        // Afficher les questions dans la vue
    }

    public function getRandomQs(int $howManyQCM, int $howManyInterac, int $howManyVraiFaux): array {
        return $this->questionService->getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux);
    }

    public function getHTMLAttributesQ(int $numQues): string {
        $question = $this->questionService->getQAttributes($numQues);
        // Créer des attributs HTML à partir des données de la question
        return "<div>{$question->getEnonce()}</div>";
    }

    public function addFinishedQuestion(int $numQues, int $idParty, string $duration, bool $isCorrect): void {
        $this->questionService->addQuestionAnswer($numQues, $idParty, $duration, $isCorrect);
    }
}