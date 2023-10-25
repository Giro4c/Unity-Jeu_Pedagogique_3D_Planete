<?php

namespace database;

class DbPartie
{

    private string $dbName = "PARTIE";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function addNewPartie(string $ipJoueur, string $dateDeb): void{
        $query = "INSERT INTO " . $this->dbName;
        $query .= " (Ip_Joueur, Date_Deb) ";
        $query .= "VALUES ('$ipJoueur', '$dateDeb')";
        $this->conn->query($query);
    }

    public function verifyPartieInProgress(string $ipJoueur){
        $query = "SELECT COUNT(*) AS Counter FROM " . $this->dbName . " WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL";
        return $this->conn->query($query)->fetch_assoc()["Counter"] > 0;
    }

}