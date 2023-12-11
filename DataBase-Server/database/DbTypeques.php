<?php

namespace database;

use utilities\GReturn;

class DbTypeques
{

    private string $dbName = "TYPEQUES";
    private DbQcm $dbQcm;
    private DbQuesinterac $dbQuesinterac;
    private DbVraiFaux $dbVraiFaux;

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
        $this->dbQcm = new DbQcm($conn);
        $this->dbQuesinterac = new DbQuesinterac($conn);
        $this->dbVraiFaux = new DbVraiFaux($conn);
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function getQType(int $numQues): string{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Num_Ques = $numQues";
        $result = $this->conn->query($query)->fetch_assoc();
        return $result['Type'];
    }

    public function getQAttributes(int $numQues): array{
        $type = $this->getQType($numQues);
        if ($type == 'QCM'){
            $result = $this->dbQcm->getQQCM($numQues)->getContent();
        }
        else if ($type == 'QUESINTERAC'){
            $result = $this->dbQuesinterac->getQInteraction($numQues)->getContent();
        }
        else if ($type == 'VRAIFAUX'){
            $result = $this->dbVraiFaux->getQVraiFaux($numQues)->getContent();
        }
        $result['Type'] = $type;
        return $result;
    }

    public function getRandomQs(int $howManyQCM = 0, int $howManyInterac = 0, int $howManyVraiFaux = 0): array{
        $numQ = [];
        $numQ += $this->dbQcm->getRandomQQCM($howManyQCM);
        $numQ += $this->dbQuesinterac->getRandomQInterac($howManyInterac);
        $numQ += $this->dbVraiFaux->getRandomQVraiFaux($howManyVraiFaux);
        return $numQ;
    }

}