<?php

namespace database;

use utilities\GReturn;

class DbQuestion
{

    private string $dbName = "QUESTION";

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

    public function getCountCorrect(int $idPartie): int {
        $query = "SELECT * FROM " . $this->dbName . " WHERE Id_Partie = $idPartie AND Reussite = 1";
        $result = $this->conn->query($query)->fetch_assoc();
        return count($result);
    }

    public function addQuestionAnswer(int $numQues, int $idParty, int $duration, bool $isCorrect): void{
         if ($isCorrect){
             $correct = 1;
         }
         else {
             $correct = 0;
         }
         $query = "INSERT INTO " . $this->dbName . " VALUES ($numQues, $idParty, $duration, $correct)";
         $this->conn->query($query);
    }

}