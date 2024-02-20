<?php

namespace database;

use utilities\GReturn;

class DbQcu
{

    private string $dbName = "QCU";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function getQQCU(int $numQues): GReturn{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        $result = $this->conn->query($query)->fetch_assoc();
        return new GReturn("ok", content: $result);
    }

    public function getRandomQQCU(int $howManyQCU = 0): array{
        $query = "SELECT Num_Ques FROM " . $this->dbName;
        $result = $this->conn->query($query)->fetch_all(MYSQLI_ASSOC);

        shuffle($result);
        $result = array_slice($result, 0, $howManyQCU);
        // Remove arrays of size 1
        for ($count = 0; $count < $howManyQCU; ++$count){
            $result[$count] = $result[$count]['Num_Ques'];
        }

        return $result;
    }

}