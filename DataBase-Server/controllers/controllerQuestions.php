<?php

namespace controllers;
use database\DbJoueur;
use database\DbPartie;
use database\DbReponseUser;
use database\DbQuestion;
use utilities\CannotDoException;

class controllerQuestions
{

    private DbReponseUser $dbReponseUser;
    private DbQuestion $dbQuestion;

    public function __construct($conn){
        $this->dbReponseUser = new DbReponseUser($conn);
        $this->dbQuestion = new DbQuestion($conn);
    }

    public function getRandomQs(int $howManyQCU = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): string{
        $totalQs = $howManyQCU + $howManyInterac + $howManyVraiFaux;
        $numQs = $this->dbQuestion->getRandomQs($howManyQCU, $howManyInterac, $howManyVraiFaux);
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

    public function getHTMLAttributesQ(int $numQues): string{
        $qAttributes = $this->dbQuestion->getQAttributes($numQues);
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

    public function addFinishedQuestion(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void{
        $this->dbReponseUser->addQuestionAnswer($numQues, $idParty, $dateDeb, $dateFin, $isCorrect);
    }

}