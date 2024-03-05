<?php

namespace data;

use domain\{Interaction, Joueur, Partie, Qcu, Quesinterac, Question, UserAnswer, VraiFaux};
use service\{DataAccessInterface, CannotDoException, PartieChecking};
use PDO;

include_once 'domain/Interaction.php';
include_once 'domain/Joueur.php';
include_once 'domain/Partie.php';
include_once 'domain/Qcu.php';
include_once 'domain/Quesinterac.php';
include_once 'domain/Question.php';
include_once 'domain/UserAnswer.php';
include_once 'domain/VraiFaux.php';

include_once 'service/DataAccessInterface.php';
include_once 'service/CannotDoException.php';

class DataAccess implements DataAccessInterface
{
    protected PDO|null $dataAccess = null;

    public function __construct(PDO $dataAccess)
    {
        $this->dataAccess = $dataAccess;
        // Debug de dataAccess
        var_dump($dataAccess);
    }

    public function __destruct()
    {
        $this->dataAccess = null;
    }

    public function executeQuery(string $query)
    {
        return $this->dataAccess->query($query);
    }

    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur, string $dateInteract): Interaction|False{
        $query = "INSERT INTO INTERACTION (Nom_Inte, Valeur_Inte, Evaluation, Ip_Joueur, Date_Inte) VALUES ('$nomInteract', $valeurInteract,$isEval, '$ipJoueur', '$dateInteract')";
        if ($this->dataAccess->query($query)){
            return new Interaction($nomInteract, $valeurInteract,  $isEval, $ipJoueur, $dateInteract);
        }
        else return false;
    }

    public function addJoueur(string $ip, string $plateforme): Joueur|False{
        $query = "INSERT INTO JOUEUR (Ip, Plateforme) VALUES ('$ip', '$plateforme')";
        if($this->dataAccess->query($query)){
            return new Joueur($ip, $plateforme);
        }
        else return false;
    }

    public function verifyJoueurExists(string $ip): bool{
        $query = "SELECT COUNT(*) AS Counter FROM JOUEUR WHERE Ip = '$ip'";
        return $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC)["Counter"] > 0;
    }

    public function addNewPartie(string $ipJoueur, string $dateDeb): Partie|False{
        $query = "INSERT INTO PARTIE (Ip_Joueur, Date_Deb) VALUES ('$ipJoueur', '$dateDeb')";
        if($this->dataAccess->query($query)){
            return new Partie($dateDeb, $ipJoueur, 0);
        }
        else return false;
    }

    public function deleteOnGoingPartie(string $ipJoueur): void{
        $query = "DELETE FROM PARTIE WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL";
        $this->dataAccess->query($query);
    }

    public function abortOnGoingPartie(string $ipJoueur): void{
        $query = "UPDATE PARTIE SET Abandon = 1 WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL AND Abandon = 0";
        $this->dataAccess->query($query);
    }

    public function endPartie(string $ipJoueur, string $dateFin): Partie|False{
        $idGame = $this->getPartieInProgress($ipJoueur)['Id_Partie'];
        try {
            $score = $this->getPartyScore($idGame);
        } catch (CannotDoException) {
            $score = 0;
        }
        $score = round($score, 2);
        $query = "UPDATE PARTIE SET Date_Fin = '$dateFin', Moy_Questions = $score "
            . "WHERE Id_Partie = $idGame";
        if($this->dataAccess->query($query)){
            return new Partie($dateDeb, 0, $dateFin, $score);
        }
        else return false;
    }

    public function getPartieInProgress(string $ipJoueur): Partie|null{
        $query = "SELECT * FROM PARTIE WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL AND Abandon = 0";
        $result = $this->dataAccess->query($query);
        if ($result->rowCount() == 0){
            return null;
        }
        else {
            return $result->fetch(PDO::FETCH_ASSOC);
        }
    }

    public function verifyPartieInProgress(string $ipJoueur): bool{
        $query = "SELECT COUNT(*) AS Counter FROM PARTIE WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL AND Abandon = 0";
        return $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC)["Counter"] > 0;
    }

    public function getQuestionCorrect(int $numQues, int $idPartie):  UserAnswer{
        $query = "SELECT * FROM REPONSE_USER WHERE Num_Ques = $numQues AND Id_Partie = $idPartie";
        $result = $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC);
        $Date_Fin = date('Y-m-d H:i:s');
        return new UserAnswer($numQues, $idPartie, $Date_Deb, $Date_Fin, $Reussite);
    }

    public function getPartyScore(int $idPartie): float|False {
        $query = "SELECT COUNT(*) AS Total, SUM(Reussite) AS Score FROM REPONSE_USER WHERE Id_Partie = $idPartie";
        $result = $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC);
        if ($result){
            $count = $result['Total'];

            if ($count == 0){
                $target = "DataBase REPONSE_USER";
                $action = "Calculate score for game party.";
                $explanation = "Game party $idPartie has no questions answered.";
                throw new CannotDoException($target, $action, $explanation);
            }

            return $result['Score'] * (10 / $count);
        }
        else return False;
    }

    public function addQuestionAnswer(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void{
        if ($isCorrect){
            $correct = 1;
        }
        else {
            $correct = 0;
        }
        $query = "INSERT INTO REPONSE_USER VALUES ($numQues, $idParty, '$dateDeb', '$dateFin', $correct)";
        $this->dataAccess->query($query);
    }

    public function getQBasics(int $numQues): array|False{
        $query = "SELECT * FROM QUESTION WHERE Num_Ques = $numQues";
        $result = $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC);
        if ($result){
            return $result;
        }
        else return false;
    }

    public function getQAttributes(int $numQues): Question{
        $basics = $this->getQBasics($numQues);

        if ($basics['Type'] == 'QCU'){
            $result = $this->dataAccess->getQQCU($numQues)->getContent();
        }
        else if ($basics['Type'] == 'QUESINTERAC'){
            $result = $this->dataAccess->getQInteraction($numQues)->getContent();
        }
        else if ($basics['Type'] == 'VRAIFAUX'){
            $result = $this->dataAccess->getQVraiFaux($numQues)->getContent();
        }
        while (true) {
            $attribute = current($basics);
            if ($attribute == null && key($basics) == null) break;

            $result[key($basics)] = $attribute;

            next($basics);
        }
        return new Question($numQues, $basics['Enonce'], $basics['Type']);
    }

    public function getRandomQs(int $howManyQCU = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): array{
        return array_merge($this->getRandomQQCU($howManyQCU), $this->getRandomQInterac($howManyInterac), $this->getRandomQVraiFaux($howManyVraiFaux));
    }

    public function getQQCU(int $numQues): Qcu{
        $query = "SELECT * FROM QCU WHERE Num_Ques = $numQues";
        $result = $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC);
        return new Qcu(
            $numQues,
            $result['Enonce'],
            $result['Type'],
            $result['Rep1'],
            $result['Rep2'],
            $result['Rep3'],
            $result['Rep4'],
            $result['BonneRep']
        );
    }

    public function getRandomQQCU(int $howManyQCU = 0): array|False{
        $query = "SELECT Num_Ques FROM QCU";
        $result = $this->dataAccess->query($query)->fetchAll(MYSQLI_ASSOC);
        if($result){
            shuffle($result);
            $result = array_slice($result, 0, $howManyQCU);
            // Remove arrays of size 1
            for ($count = 0; $count < $howManyQCU; ++$count){
                $result[$count] = $result[$count]['Num_Ques'];
            }

            return $result;
        }
        else return false;

    }

    public function getQInteraction(int $numQues): Quesinterac{
        $query = "SELECT * FROM QUESINTERAC WHERE Num_Ques = $numQues";
        $result = $this->dataAccess->query($query)->fetch(PDO::FETCH_ASSOC);
        return new Quesinterac($numQues);
    }

    public function getRandomQInterac(int $howManyInterac = 0): array|False{
        $query = "SELECT Num_Ques FROM QUESINTERAC";
        $result = $this->dataAccess->query($query)->fetchAll(MYSQLI_ASSOC);
        if($result){
            shuffle($result);
            $result = array_slice($result, 0, $howManyInterac);
            // Remove arrays of size 1
            for ($count = 0; $count < $howManyInterac; ++$count){
                $result[$count] = $result[$count]['Num_Ques'];
            }

            return $result;
        }
        else return false;

    }

    public function getQVraiFaux(int $numQues): VraiFaux{
        $query = "SELECT * FROM  VRAIFAUX WHERE Num_Ques = $numQues";
        $result = $this->dataAccess->query($query)->fetchAll();
        return new VraiFaux();
    }

    public function getRandomQVraiFaux(int $howManyVraiFaux = 0): array|False{
        $query = "SELECT Num_Ques FROM VRAIFAUX";
        $result = $this->dataAccess->query($query)->fetchAll(MYSQLI_ASSOC);
        if ($result){
            shuffle($result);
            $result = array_slice($result, 0, $howManyVraiFaux);
            // Remove arrays of size 1
            for ($count = 0; $count < $howManyVraiFaux; ++$count){
                $result[$count] = $result[$count]['Num_Ques'];
            }
            return $result;
        }
        else return false;
    }
}
