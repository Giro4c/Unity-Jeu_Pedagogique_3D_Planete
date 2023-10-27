<?php

namespace database;

class DbInteraction
{

    private string $dbName = "INTERATION";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function addInteraction(string $nomInteract, float $valeurInteract, bool $isEval, string $ipJoueur): void{
        if ($isEval){
            $isEvalInt = 1;
        }
        else{
            $isEvalInt = 0;
        }
        $query = "INSERT INTO " . $this->dbName .
            " (Nom_Inte, Valeur_Inte, Evaluation, Ip_Joueur) VALUES ('$nomInteract', $valeurInteract,$isEvalInt, '$ipJoueur')";
        $this->conn->query($query);
    }

}