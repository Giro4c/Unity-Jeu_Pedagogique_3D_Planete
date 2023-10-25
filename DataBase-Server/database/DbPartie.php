<?php

namespace database;

class DbPartie
{

    private string $dbName = "PARTIE";

    private \mysqli $conn;

    public function __construct($conn){
        $this->conn = $conn;
    }

    public function addPartie(string $ipJoueur, string $dateDeb, string $dateFin, int $dureePar, int $MoyQuestions): void{
        $query = "INSERT INTO " . $this->dbName;
        $query .= " (Ip_Joueur, Date_Deb, Date_Fin, Duree_Par, Moy_Questions) ";
        $query .= "VALUES ('$ipJoueur', '$dateDeb', '$dateFin', $dureePar, $MoyQuestions)";
        $this->conn->query($query);
    }

}