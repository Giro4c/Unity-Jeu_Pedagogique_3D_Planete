<?php

namespace service;

use domain\Interaction;
use domain\Joueur;
use domain\Partie;
use domain\Qcu;
use domain\Quesinterac;
use domain\Question;
use domain\UserAnswer;
use domain\VraiFaux;

interface DataAccessInterface
{
    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur, string $dateInteract): Interaction;

    public function addJoueur(string $ip, string $plateforme): Joueur;

    public function verifyJoueurExists(string $ip): bool;

    public function addNewPartie(string $ipJoueur, string $dateDeb): Partie;

    public function deleteOnGoingPartie(string $ipJoueur): void;

    public function abortOnGoingPartie(string $ipJoueur): void;

    public function endPartie(string $ipJoueur, string $dateFin): Partie;

    public function getPartieInProgress(string $ipJoueur): Partie|null;

    public function verifyPartieInProgress(string $ipJoueur): bool;

    public function getQuestionCorrect(int $numQues, int $idPartie):  UserAnswer;

    public function getPartyScore(int $idPartie): float;

    public function addQuestionAnswer(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void;

    public function getQBasics(int $numQues): string;

    public function getQAttributes(int $numQues): Question;

    public function getRandomQs(int $howManyQCM, int $howManyInterac, int $howManyVraiFaux): Question;

    public function getQQCU(int $numQues): Qcu;

    public function getRandomQQCU(int $howManyQCM): Qcu;

    public function getQInteraction(int $numQues): Quesinterac;

    public function getRandomQInterac(int $howManyInterac): Quesinterac;

    public function getQVraiFaux(int $numQues): VraiFaux;

    public function getRandomQVraiFaux(int $howManyVraiFaux): VraiFaux;
}
