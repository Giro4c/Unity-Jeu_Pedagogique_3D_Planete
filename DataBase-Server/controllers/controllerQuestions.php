<?php

namespace controllers;
use database\DbJoueur;
use database\DbPartie;
use database\DbQuestion;
use database\DbTypeques;
use utilities\CannotDoException;

class controllerQuestions
{

    private DbQuestion $dbQuestion;
    private DbTypeques $dbTypeques;

    public function __construct($conn){
        $this->dbQuestion = new DbQuestion($conn);
        $this->dbTypeques = new DbTypeques($conn);
    }

    public function getRandomQs(int $howManyQCM = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): string{
        $totalQs = $howManyQCM + $howManyInterac + $howManyVraiFaux;
        $numQs = $this->dbTypeques->getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux);
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
        $qAttributes = $this->dbTypeques->getQAttributes($numQues);
        ob_start();
        while ($attribute = current($qAttributes)) { ?>
            <p id="<?= key($qAttributes) ?>"><?= $attribute ?></p>
        <?php
            next($array);
        }
        $qHTML = ob_get_contents();
        ob_end_clean();
        return $qHTML;
    }

    public function addFinishedQuestion(int $numQues, int $idParty, int $duration, bool $isCorrect): void{

    }

}