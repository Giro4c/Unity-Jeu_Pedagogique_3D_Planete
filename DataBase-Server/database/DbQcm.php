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

    public function getDbName(): string{
        return $this->dbName;
    }

    public function getQQCM(int $numQues): GReturn{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        $result = $this->conn->query($query)->fetch_assoc();
        return new GReturn("ok", content: $result);
    }

    public function getRandomQQCM(int $howManyQCM = 0): array{
        $query = "SELECT Num_Ques FROM " . $this->dbName;
        $result = $this->conn->query($query)->fetch_all();
        shuffle($result);
        $qNums = [];
        for ($count = 0; $count < $howManyQCM; ++$count){
            $qNums[] = $result[$count];
        }
        return $qNums;
    }

}