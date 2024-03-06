<?php

namespace service;

use domain\{Interaction, Joueur, Partie, Qcu, Quesinterac, Question, UserAnswer, VraiFaux};


class PartieChecking
{

    /**
     * @param string $query
     * @param $data
     * @return void
     */
    public function executeQuery(string $query, $data)
    {
        $data->executeQuery($query);
    }

    /**
     * @param string $nomInteract
     * @param float $valeurInteract
     * @param int $isEval
     * @param string $ipJoueur
     * @param string $dateInterac
     * @param $data
     * @return Interaction|False
     */
    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur, string $dateInterac, $data): Interaction|False{
        return $data->addInteraction($nomInteract, $valeurInteract, $isEval, $ipJoueur, $dateInterac);
    }

    /**
     * @param string $ip
     * @param string $plateforme
     * @param $data
     * @return Joueur|False
     */
    public function addJoueur(string $ip, string $plateforme, $data): Joueur|False{
        return $data->addJoueur($ip, $plateforme);
    }

    /**
     * @param string $ip
     * @param $data
     * @return bool
     */
    public function verifyJoueurExists(string $ip, $data): bool{
        return $data->verifyJoueurExists($ip);
    }

    /**
     * @param string $ipJoueur
     * @param string $dateDeb
     * @param $data
     * @return Partie|False
     */
    public function addNewPartie(string $ipJoueur, string $dateDeb, $data): Partie|False{
        return $data->addNewPartie($ipJoueur, $dateDeb);
    }

    /**
     * @param string $ipJoueur
     * @param $data
     * @return void
     */
    public function deleteOnGoingPartie(string $ipJoueur, $data): void{
        $data->deleteOnGoingPartie($ipJoueur);
    }

    /**
     * @param string $ipJoueur
     * @param $data
     * @return void
     */
    public function abortOnGoingPartie(string $ipJoueur, $data): void{
        $data->abortOnGoingPartie($ipJoueur);
    }

    /**
     * @param string $ipJoueur
     * @param string $dateFin
     * @param $data
     * @return Partie
     */
    public function endPartie(string $ipJoueur, string $dateFin, $data): Partie{
        return $data->endPartie($ipJoueur, $dateFin);
    }

    /**
     * @param string $ipJoueur
     * @param $data
     * @return Partie|null
     */
    public function getPartieInProgress(string $ipJoueur, $data): Partie|null{
        return $data->getPartieInProgress($ipJoueur);
    }

    /**
     * @param string $ipJoueur
     * @param $data
     * @return bool
     */
    public function verifyPartieInProgress(string $ipJoueur, $data): bool{
        return $data->verifyPartieInProgress($ipJoueur);
    }

    /**
     * @param int $numQues
     * @param int $idPartie
     * @param $data
     * @return UserAnswer
     */
    public function getQuestionCorrect(int $numQues, int $idPartie, $data):  UserAnswer{
        return $data->getQuestionCorrect($numQues, $idPartie);
    }

    /**
     * @param int $idPartie
     * @param $data
     * @return float|False
     */
    public function getPartyScore(int $idPartie, $data): float|False{
        return $data->getPartyScore($idPartie);
    }

    /**
     * @param int $numQues
     * @param int $idParty
     * @param string $dateDeb
     * @param string $dateFin
     * @param bool $isCorrect
     * @param $data
     * @return void
     */
    public function addQuestionAnswer(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect, $data): void{
        $data->addQuestionAnswer($numQues, $idParty, $dateDeb, $dateFin, $isCorrect);
    }

    /**
     * @param int $numQues
     * @param $data
     * @return array|False
     */
    public function getQBasics(int $numQues, $data): array|False{
        return $data->getQBasics($numQues);
    }

    /**
     * @param int $numQues
     * @param $data
     * @return Question
     */
    public function getQAttributes(int $numQues, $data): Question{
        return $data->getQAttributes($numQues);
    }

    /**
     * @param int $howManyQCM
     * @param int $howManyInterac
     * @param int $howManyVraiFaux
     * @param $data
     * @return array
     */
    public function getRandomQs(int $howManyQCM, int $howManyInterac, int $howManyVraiFaux, $data): array{
        return $data->getRandomQs($howManyQCM, $howManyInterac, $howManyVraiFaux);
    }

    /**
     * @param int $numQues
     * @param $data
     * @return Qcu
     */
    public function getQQCU(int $numQues, $data): Qcu{
        return $data->getQQCU($numQues);
    }

    /**
     * @param int $howManyQCM
     * @param $data
     * @return array|False
     */
    public function getRandomQQCU(int $howManyQCM, $data): array|False{
        return $data->getRandomQQCU($howManyQCM);
    }

    /**
     * @param int $numQues
     * @param $data
     * @return Quesinterac
     */
    public function getQInteraction(int $numQues, $data): Quesinterac{
        return $data->getQInteraction($numQues);
    }

    /**
     * @param int $howManyInterac
     * @param $data
     * @return array|False
     */
    public function getRandomQInterac(int $howManyInterac, $data): array|False{
        return $data->getRandomQInterac($howManyInterac);
    }

    /**
     * @param int $numQues
     * @param $data
     * @return VraiFaux
     */
    public function getQVraiFaux(int $numQues, $data): VraiFaux{
        return $data->getQVraiFaux($numQues);
    }

    /**
     * @param int $howManyVraiFaux
     * @param $data
     * @return array|False
     */
    public function getRandomQVraiFaux(int $howManyVraiFaux, $data): array|False{
        return $data->getRandomQVraiFaux($howManyVraiFaux);
    }
}


