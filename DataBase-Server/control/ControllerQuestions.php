<?php

namespace control;

use service\PartieChecking;

class ControllerQuestions
{
    /**
     * @param int $howManyQCU
     * @param int $howManyInterac
     * @param int $howManyVraiFaux
     * @return string
     */
    public function getJsonRandomQs(PartieChecking $questionService, $data, int $howManyQCU = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): string{
        $numQs = $questionService->getRandomQs($howManyQCU, $howManyInterac, $howManyVraiFaux, $data);
        return json_encode($numQs, JSON_PRETTY_PRINT);
    }

    /**
     * @param int $numQues
     * @return string
     */
    public function getJsonAttributesQ(int $numQues, PartieChecking $questionService, $data): string {
        $qAttributes = $questionService->getQAttributes($numQues, $data);
        return json_encode($qAttributes, JSON_PRETTY_PRINT);
    }


    /**
     * @param int $numQues
     * @param int $idParty
     * @param string $dateDeb
     * @param string $dateFin
     * @param bool $isCorrect
     * @return void
     */
    public function addFinishedQuestion(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect, PartieChecking $questionService, $data): void {
        $questionService->addQuestionAnswer($numQues, $idParty, $dateDeb, $dateFin, $isCorrect, $data);
    }
}