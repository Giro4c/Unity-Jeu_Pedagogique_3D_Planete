<?php

namespace control;

use service\PartieChecking;

class ControllerQuestions
{
    private PartieChecking $questionService;

    /**
     * @param PartieChecking $questionService
     */
    public function __construct(PartieChecking $questionService) {
        $this->questionService = $questionService;
    }

    /**
     * @return void
     */
    public function displayRandomQuestions(): void {
        // Afficher des questions aléatoires
        $questions = $this->questionService->getRandomQs(5, 3, 2);
        // Afficher les questions dans la vue
    }

    /**
     * @param int $howManyQCM
     * @param int $howManyInterac
     * @param int $howManyVraiFaux
     * @return array
     */
    public function getRandomQs(int $howManyQCM, int $howManyInterac, int $howManyVraiFaux): array {
        return $this->questionService->getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux);
    }

    /**
     * @param int $numQues
     * @return string
     */
    public function getHTMLAttributesQ(int $numQues): string {
        $question = $this->questionService->getQAttributes($numQues);
        // Créer des attributs HTML à partir des données de la question
        return "<div>{$question->getEnonce()}</div>";
    }


    /**
     * @param int $numQues
     * @param int $idParty
     * @param string $dateDeb
     * @param string $dateFin
     * @param bool $isCorrect
     * @return void
     */
    public function addFinishedQuestion(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void {
        $this->questionService->addQuestionAnswer($numQues, $idParty, $dateDeb, $dateFin, $isCorrect);
    }
}