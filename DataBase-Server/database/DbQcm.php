<?php

namespace database;

use utilities\GReturn;

class DbQcm
{

    private string $dbName = "QCM";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getQQCM(int $numQues): GReturn{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        $result = $this->conn->query($query)->fetch_assoc();
        return new GReturn("ok", content: $result);
    }

}