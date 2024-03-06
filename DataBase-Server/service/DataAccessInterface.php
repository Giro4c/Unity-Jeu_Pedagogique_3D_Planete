<?php

namespace service;

use domain\{Interaction, Joueur, Partie, Qcu, Quesinterac, Question, UserAnswer, VraiFaux};

interface DataAccessInterface
{
    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur, string $dateInteract): Interaction|False;

    public function addJoueur(string $ip, string $plateforme): Joueur|False;

    public function verifyJoueurExists(string $ip): bool;

    public function addNewPartie(string $ipJoueur, string $dateDeb): Partie|False;

    public function deleteOnGoingPartie(string $ipJoueur): void;

    public function abortOnGoingPartie(string $ipJoueur): void;

    public function endPartie(string $ipJoueur, string $dateFin): Partie|False;

    public function getPartieInProgress(string $ipJoueur): Partie|null;

    public function verifyPartieInProgress(string $ipJoueur): bool;

    public function getQuestionCorrect(int $numQues, int $idPartie):  UserAnswer;

    public function getPartyScore(int $idPartie): float|False;

    public function addQuestionAnswer(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void;

    public function getQBasics(int $numQues): array|False;

    public function getQAttributes(int $numQues): QCU | VraiFaux | QuesInterac| False;

    public function getRandomQs(int $howManyQCU, int $howManyInterac, int $howManyVraiFaux): array;

    public function getQQCU(int $numQues): Qcu;

    public function getRandomQQCU(int $howManyQCU): array|False;

    public function getQInteraction(int $numQues): Quesinterac;

    public function getRandomQInterac(int $howManyInterac): array|False;

    public function getQVraiFaux(int $numQues): VraiFaux;

    public function getRandomQVraiFaux(int $howManyVraiFaux): array|False;
}
