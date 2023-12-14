<?php

namespace database;

use utilities\GReturn;

class DbQuesinterac
{

    private string $dbName = "QUESINTERAC";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function getQInteraction(int $numQues): GReturn{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        $result = $this->conn->query($query)->fetch_assoc();
        return new GReturn("ok", content: $result);
    }

    public function getRandomQInterac(int $howManyInterac = 0): array{
        $query = "SELECT Num_Ques FROM " . $this->dbName;
        $result = $this->conn->query($query)->fetch_all(MYSQLI_ASSOC);

        shuffle($result);
        $result = array_slice($result, 0, $howManyInterac);
        // Remove arrays of size 1
        for ($count = 0; $count < $howManyInterac; ++$count){
            $result[$count] = $result[$count]['Num_Ques'];
        }

        return $result;
    }

}