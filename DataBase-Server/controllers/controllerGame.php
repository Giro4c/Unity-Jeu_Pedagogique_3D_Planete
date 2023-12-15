<?php

namespace controllers;
use database\DbJoueur;
use database\DbPartie;
use database\DbQuestion;
use utilities\CannotDoException;

class controllerGame
{

    private DbJoueur $dbJoueur;
    private DbPartie $dbPartie;

    public function __construct($conn){
        $this->dbJoueur = new DbJoueur($conn);
        $this->dbPartie = new DbPartie($conn);
    }

    /**
     * @throws CannotDoException
     */
    public function newPlayer(string $ip, string $plateforme): void{
        if($this->dbJoueur->verifyJoueurExists($ip)){
            $target = "DataBase " . $this->dbJoueur->getDbName();
            $action = "Register new player";
            $explanation = "Player already exists: " . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }
        else{
            $this->dbJoueur->addJoueur($ip, $plateforme);
        }
    }

    /**
     * @throws CannotDoException
     */
    public function newPartie(string $ip, string $dateDeb): void{
        if($this->dbPartie->verifyPartieInProgress($ip)){
            $target = "DataBase " . $this->dbPartie->getDbName();
            $action = "Register new game";
            $explanation = "There already is a game in progress: Player IP=" . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }
        else{
            $this->dbPartie->addNewPartie($ip, $dateDeb);
        }
    }

    public function abortPartie(string $ip): void{
        $this->dbPartie->abortOnGoingPartie($ip);
    }

    /**
     * @throws CannotDoException
     */
    public function endPartie(string $ip, string $dateFin): void{
        if(!$this->dbPartie->verifyPartieInProgress($ip)){
            $target = "DataBase " . $this->dbPartie->getDbName();
            $action = "End ongoing game";
            $explanation = "There is no game in progress: Player IP=" . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }

        $this->dbPartie->endPartie($ip, $dateFin);
    }

}