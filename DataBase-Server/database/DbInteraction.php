<?php

namespace database;

class DbInteraction
{

    private string $dbName = "INTERACTION";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function addInteraction(string $nomInteract, float $valeurInteract, int $isEval, string $ipJoueur, string $dateInteract): void{
        $query = "INSERT INTO " . $this->dbName .
            " (Nom_Inte, Valeur_Inte, Evaluation, Ip_Joueur, Date_Inte) VALUES ('$nomInteract', $valeurInteract,$isEval, '$ipJoueur', '$dateInteract')";
        $this->conn->query($query);
    }

}