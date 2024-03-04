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

    public function getJsonRandomQs(int $howManyQCU = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): string{
        $numQs = $this->dbQuestion->getRandomQs($howManyQCU, $howManyInterac, $howManyVraiFaux);
        return json_encode($numQs, JSON_PRETTY_PRINT);
    }

    public function getJsonAttributesQ(int $numQues): false|string
    {
        $qAttributes = $this->dbQuestion->getQAttributes($numQues);
        return json_encode($qAttributes, JSON_PRETTY_PRINT);
    }


    public function addFinishedQuestion(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void{
        $this->dbReponseUser->addQuestionAnswer($numQues, $idParty, $dateDeb, $dateFin, $isCorrect);
    }

}