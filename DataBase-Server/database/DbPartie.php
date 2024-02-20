<?php

namespace database;

use utilities\CannotDoException;

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

    public function deleteOnGoingPartie(string $ipJoueur): void{
        $query = "DELETE FROM " . $this->dbName . " WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL";
        $this->conn->query($query);
    }

    public function abortOnGoingPartie(string $ipJoueur): void{
        $query = "UPDATE " . $this->dbName . " SET Abandon = 1 WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL AND Abandon = 0";
        $this->conn->query($query);
    }

    public function endPartie(string $ipJoueur, string $dateFin): void{
        $dbQs = new DbReponseUser($this->conn);
        $idGame = $this->getPartieInProgress($ipJoueur)['Id_Partie'];
        try {
            $score = $dbQs->getPartyScore($idGame);
        } catch (CannotDoException $e) {
            $score = 0;
        }
        $score = round($score, 2);
        $query = "UPDATE " . $this->dbName . " SET Date_Fin = '$dateFin', Moy_Questions = $score "
            . "WHERE Id_Partie = $idGame";
        $this->conn->query($query);
//        $query = "UPDATE " . $this->dbName . " SET Date_Fin = '$dateFin', Duree_Par = (Date_Fin - Date_Deb), Moy_Questions = $score "
//            . "WHERE Id_Partie = $idGame";
//        $this->conn->query($query);
    }

    public function getPartieInProgress(string $ipJoueur): array|null{
        $query = "SELECT * FROM " . $this->dbName . " WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL AND Abandon = 0";
        $result = $this->conn->query($query);
        if ($result->num_rows == 0){
            return null;
        }
        else {
            return $result->fetch_assoc();
        }
    }

    public function verifyPartieInProgress(string $ipJoueur): bool{
        $query = "SELECT COUNT(*) AS Counter FROM " . $this->dbName . " WHERE Ip_Joueur = '$ipJoueur' AND Date_Fin IS NULL AND Abandon = 0";
        return $this->conn->query($query)->fetch_assoc()["Counter"] > 0;
    }

}