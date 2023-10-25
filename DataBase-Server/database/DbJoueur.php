<?php

namespace database;

class DbJoueur
{

    private string $dbName = "JOUEUR";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    public function addJoueur(string $ip, string $plateforme): void{
        $query = "INSERT INTO " . $this->dbName .
            " (Ip, Plateforme) VALUES ('$ip', '$plateforme')";
        $this->conn->query($query);
    }

    public function verifyJoueurExists(string $ip): bool{
        $query = "SELECT COUNT(*) AS Counter FROM " . $this->dbName . " WHERE Ip = '$ip'";
        return $this->conn->query($query)->fetch_assoc()["Counter"] > 0;
    }

}