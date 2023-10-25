<?php

namespace database;

use utilities\GReturn;

class DbVraiFaux
{

    private string $dbName = "VRAIFAUX";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getQVraiFaux(int $numQues): GReturn{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        $result = $this->conn->query($query)->fetch_assoc();
        return new GReturn("ok", content: $result);
    }

}