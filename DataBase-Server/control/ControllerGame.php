<?php

namespace control;

use service\CannotDoException;
use service\PartieChecking;

class ControllerGame
{
    /**
     * @param string $ip
     * @param string $platform
     * @return void
     */
    public function newPlayer(string $ip, string $platform, PartieChecking $partieService, $data): void {
        if($partieService->verifyJoueurExists($ip, $data)){
            $target = "DataBase User";
            $action = "Register new player";
            $explanation = "Player already exists: " . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }
        else{
            $partieService->addJoueur($ip, $platform, $data);
        }
    }

    /**
     * @param string $ip
     * @param string $dateDeb
     * @return void
     */
    public function newPartie(string $ip, string $dateDeb, PartieChecking $partieService, $data): void {
        if($partieService->verifyPartieInProgress($ip, $data)){
            $target = "DataBase Partie ";
            $action = "Register new game";
            $explanation = "There already is a game in progress: Player IP=" . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }
        else{
            $partieService->addNewPartie($ip, $dateDeb, $data);
        }
    }

    /**
     * @param string $ip
     * @return void
     */
    public function abortPartie(string $ip, PartieChecking $partieService, $data): void {
        $partieService->abortOnGoingPartie($ip, $data);
    }

    /**
     * @param string $ip
     * @param string $dateFin
     * @return void
     */
    public function endPartie(string $ip, string $dateFin, PartieChecking $partieService, $data): void {
        if(!$partieService->verifyPartieInProgress($ip, $data)){
            $target = "DataBase Partie";
            $action = "End ongoing game";
            $explanation = "There is no game in progress: Player IP=" . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }

        $partieService->endPartie($ip, $dateFin, $data);
    }
}