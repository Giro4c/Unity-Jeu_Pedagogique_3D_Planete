<?php

namespace database;

class DbInteraction
{

    private string $dbName = "INTERATION";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function addInteraction(string $nomInteract, int $valeurInteract, bool $isEval, string $ipJoueur): void{
        $query = "INSERT INTO " . $this->dbName .
            " (Nom_Inte, Valeur_Inte, Evaluation, Ip_Joueur) VALUES ('$nomInteract', $valeurInteract, $isEval, '$ipJoueur')";
        $this->conn->query($query);
    }

}