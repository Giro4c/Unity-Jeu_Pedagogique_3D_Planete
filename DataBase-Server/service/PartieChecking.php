<?php

namespace service;

use domain\{Interaction, Joueur, Partie, Qcu, Quesinterac, Question, UserAnswer, VraiFaux};


class PartieChecking
{

    public function executeQuery(string $query, $data)
    {
        $data->executeQuery($query);
    }
    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur, string $dateInterac, $data): Interaction|False{
        return $data->addInteraction($nomInteract, $valeurInteract, $isEval, $ipJoueur, $dateInterac);
    }

    public function addJoueur(string $ip, string $plateforme, $data): Joueur|False{
        return $data->addJoueur($ip, $plateforme);
    }

    public function verifyJoueurExists(string $ip, $data): bool{
        return $data->verifyJoueurExists($ip);
    }

    public function addNewPartie(string $ipJoueur, string $dateDeb, $data): Partie|False{
        return $data->addNewPartie($ipJoueur, $dateDeb);
    }

    public function deleteOnGoingPartie(string $ipJoueur, $data): void{
        $data->deleteOnGoingPartie($ipJoueur);
    }

    public function abortOnGoingPartie(string $ipJoueur, $data): void{
        $data->abortOnGoingPartie($ipJoueur);
    }

    public function endPartie(string $ipJoueur, string $dateFin, $data): Partie{
        return $data->endPartie($ipJoueur, $dateFin);
    }

    public function getPartieInProgress(string $ipJoueur, $data): Partie|null{
        return $data->getPartieInProgress($ipJoueur);
    }

    public function verifyPartieInProgress(string $ipJoueur, $data): bool{
        return $data->verifyPartieInProgress($ipJoueur);
    }

    public function getQuestionCorrect(int $numQues, int $idPartie, $data):  UserAnswer{
        return $data->getQuestionCorrect($numQues, $idPartie);
    }

    public function getPartyScore(int $idPartie, $data): float{
        return $data->getPartyScore($idPartie);
    }

    public function addQuestionAnswer(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect, $data): void{
        $data->addQuestionAnswer($numQues, $idParty, $dateDeb, $dateFin, $isCorrect);
    }

    public function getQBasics(int $numQues, $data): string{
        return $data->getQBasics($numQues);
    }

    public function getQAttributes(int $numQues, $data): Question{
        return $data->getQAttributes($numQues);
    }

    public function getRandomQs(int $howManyQCM, int $howManyInterac, int $howManyVraiFaux, $data): Question{
        return $data->getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux);
    }

    public function getQQCU(int $numQues, $data): Qcu{
        return $data->getQQCU($numQues);
    }

    public function getRandomQQCU(int $howManyQCM, $data): Qcu{
        return $data->getRandomQQCU($howManyQCM);
    }

    public function getQInteraction(int $numQues, $data): Quesinterac{
        return $data->getQInteraction($numQues);
    }

    public function getRandomQInterac(int $howManyInterac, $data): Quesinterac{
        return $data->getRandomQInterac($howManyInterac);
    }

    public function getQVraiFaux(int $numQues, $data): VraiFaux{
        return $data->getQVraiFaux($numQues);
    }

    public function getRandomQVraiFaux(int $howManyVraiFaux, $data): array|False{
        return $data->getRandomQVraiFaux($howManyVraiFaux);
    }
}


