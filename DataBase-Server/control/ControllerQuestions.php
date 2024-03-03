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
     * @param int $howManyQCU
     * @param int $howManyInterac
     * @param int $howManyVraiFaux
     * @return string
     */
    public function getRandomQs(int $howManyQCU = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): string{
        $totalQs = $howManyQCU + $howManyInterac + $howManyVraiFaux;
        $numQs = $this->questionService->getRandomQs($howManyQCU, $howManyInterac, $howManyVraiFaux);
        ob_start(); ?>
        <ul>
            <?php for ($count = 0; $count < $totalQs; ++$count){?>
                <li id="<?= $count ?>"><?= $numQs[$count] ?></li>
            <?php }?>
        </ul>
        <?php
        $contentHTML = ob_get_contents();
        ob_end_clean();
        return $contentHTML;
    }

    /**
     * @param int $numQues
     * @return string
     */
    public function getHTMLAttributesQ(int $numQues): string {
        $qAttributes = $this->questionService->getQAttributes($numQues);
        ob_start();
        while (true) {
            $attribute = current($qAttributes);
            if ($attribute == null && key($qAttributes) == null) break;
            ?>
            <p id="<?= key($qAttributes) ?>"><?= $attribute ?></p>
            <?php
            next($qAttributes);
        }
        $qHTML = ob_get_contents();
        ob_end_clean();
        return $qHTML;
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