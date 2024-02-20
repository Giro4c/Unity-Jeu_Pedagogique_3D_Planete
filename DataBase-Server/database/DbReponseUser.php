<?php

namespace database;

use utilities\CannotDoException;
use utilities\GReturn;

class DbReponseUser
{

    private string $dbName = "REPONSE_USER";

    private \mysqli $conn;

     public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function getQuestionCorrect(int $numQues, int $idPartie): GReturn{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues AND Id_Partie = $idPartie";
        $result = $this->conn->query($query)->fetch_assoc();
        return new GReturn("ok", content: $result);
    }

    /**
     * Gives the score for a party on a /10 notation.
     * @param int $idPartie the id of the party whose score is searched
     * @return float the score for the party on a /10 notation.
     * @throws CannotDoException
     */
    public function getPartyScore(int $idPartie): float {
        $query = "SELECT COUNT(*) AS Total, SUM(Reussite) AS Score FROM " . $this->dbName . " WHERE Id_Partie = $idPartie";
        $result = $this->conn->query($query)->fetch_assoc();
        $count = $result['Total'];

        if ($count == 0){
            $target = "DataBase " . $this->dbName;
            $action = "Calculate score for game party.";
            $explanation = "Game party $idPartie has no questions answered.";
            throw new CannotDoException($target, $action, $explanation);
        }

        return $result['Score'] * (10 / $count);
    }

    public function addQuestionAnswer(int $numQues, int $idParty, string $dateDeb, string $dateFin, bool $isCorrect): void{
         if ($isCorrect){
             $correct = 1;
         }
         else {
             $correct = 0;
         }
         $query = "INSERT INTO " . $this->dbName . " VALUES ($numQues, $idParty, '$dateDeb', '$dateFin', $correct)";
         $this->conn->query($query);
    }

}