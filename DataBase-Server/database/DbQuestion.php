<?php

namespace database;

use utilities\GReturn;

class DbQuestion
{

    private string $dbName = "QUESTION";
    private DbQcu $dbQcu;
    private DbQuesinterac $dbQuesinterac;
    private DbVraiFaux $dbVraiFaux;

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
        $this->dbQcu = new DbQcu($conn);
        $this->dbQuesinterac = new DbQuesinterac($conn);
        $this->dbVraiFaux = new DbVraiFaux($conn);
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function getQBasics(int $numQues): array{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        return $this->conn->query($query)->fetch_assoc();
    }

    public function getQAttributes(int $numQues): array{
        $basics = $this->getQBasics($numQues);

        if ($basics['Type'] == 'QCU'){
            $result = $this->dbQcu->getQQCU($numQues)->getContent();
        }
        else if ($basics['Type'] == 'QUESINTERAC'){
            $result = $this->dbQuesinterac->getQInteraction($numQues)->getContent();
        }
        else if ($basics['Type'] == 'VRAIFAUX'){
            $result = $this->dbVraiFaux->getQVraiFaux($numQues)->getContent();
        }
        while (true) {
            $attribute = current($basics);
            if ($attribute == null && key($basics) == null) break;

            $result[key($basics)] = $attribute;

            next($basics);
        }
        return $result;
    }

    public function getRandomQs(int $howManyQCU = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): array{
        return array_merge($this->dbQcu->getRandomQQCU($howManyQCU), $this->dbQuesinterac->getRandomQInterac($howManyInterac), $this->dbVraiFaux->getRandomQVraiFaux($howManyVraiFaux));
    }

}