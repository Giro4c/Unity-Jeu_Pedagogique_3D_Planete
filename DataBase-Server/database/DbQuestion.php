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

}