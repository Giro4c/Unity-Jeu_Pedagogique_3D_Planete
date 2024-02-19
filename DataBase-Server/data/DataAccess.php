<?php

namespace data;

use mysqli;
use domain\Interaction;
use domain\Joueur;
use domain\Partie;
use domain\UserAnswer;
use domain\Question;
use domain\Qcm;
use domain\Quesinterac;
use domain\VraiFaux;
use service\DataAccessInterface;

class DataAccess implements DataAccessInterface
{
    protected $conn;

    public function __construct(mysqli $conn) {
        $this->conn = $conn;
    }

    /*

    public function executeQuery(string $query) {
        // Implémentation de l'exécution d'une requête SQL
    }

    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur): Interaction {
        // Implémentation pour ajouter une interaction
    }

    public function addJoueur(string $ip, string $plateforme): Joueur {
        // Implémentation pour ajouter un joueur
    }

    public function verifyJoueurExists(string $ip): bool {
        // Implémentation pour vérifier si un joueur existe
    }

    public function addNewPartie(string $ipJoueur, string $dateDeb): Partie {
        // Implémentation pour ajouter une nouvelle partie
    }

    public function deleteOnGoingPartie(string $ipJoueur): void {
        // Implémentation pour supprimer une partie en cours
    }

    public function abortOnGoingPartie(string $ipJoueur): void {
        // Implémentation pour abandonner une partie en cours
    }

    public function endPartie(string $ipJoueur, string $dateFin): Partie {
        // Implémentation pour terminer une partie
    }

    public function getPartieInProgress(string $ipJoueur): ?Partie {
        // Implémentation pour récupérer la partie en cours d'un joueur
    }

    public function verifyPartieInProgress(string $ipJoueur): bool {
        // Implémentation pour vérifier si une partie est en cours pour un joueur
    }

    public function getQuestionCorrect(int $numQues, int $idPartie): UserAnswer {
        // Implémentation pour récupérer la réponse correcte d'une question
    }

    public function getPartyScore(int $idPartie): float {
        // Implémentation pour récupérer le score d'une partie
    }

    public function addQuestionAnswer(int $numQues, int $idParty, int $duration, bool $isCorrect): void {
        // Implémentation pour ajouter la réponse d'une question à la base de données
    }

    public function getQType(int $numQues): string {
        // Implémentation pour récupérer le type d'une question
    }

    public function getQAttributes(int $numQues): Question {
        // Implémentation pour récupérer les attributs d'une question
    }

    public function getRandomQs(int $howManyQCM, int $howManyInterac, int $howManyVraiFaux): Question {
        // Implémentation pour récupérer un nombre spécifié de questions de chaque type
    }

    public function getQQCM(int $numQues): Qcm {
        // Implémentation pour récupérer un QCM spécifique
    }

    public function getRandomQQCM(int $howManyQCM): Qcm {
        // Implémentation pour récupérer un nombre spécifié de QCM aléatoires
    }

    public function getQInteraction(int $numQues): Quesinterac {
        // Implémentation pour récupérer une interaction spécifique
    }

    public function getRandomQInterac(int $howManyInterac): Quesinterac {
        // Implémentation pour récupérer un nombre spécifié d'interactions aléatoires
    }

    public function getQVraiFaux(int $numQues): VraiFaux {
        // Implémentation pour récupérer une question Vrai/Faux spécifique
    }

    public function getRandomQVraiFaux(int $howManyVraiFaux): VraiFaux {
        // Implémentation pour récupérer un nombre spécifié de questions Vrai/Faux aléatoires
    }
    */
}