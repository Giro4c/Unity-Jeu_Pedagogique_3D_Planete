<?php

namespace control;

use service\PartieChecking;

class ControllerGame
{
    private PartieChecking $partieService;

    /**
     * @param PartieChecking $partieService
     */
    public function __construct(PartieChecking $partieService) {
        $this->partieService = $partieService;
    }

    /**
     * @param string $ip
     * @param string $platform
     * @return void
     */
    public function newPlayer(string $ip, string $platform): void {
        if($this->partieService->verifyJoueurExists($ip)){
            $target = "DataBase " . $this->partieService->getDbName();
            $action = "Register new player";
            $explanation = "Player already exists: " . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }
        else{
            $this->partieService->addJoueur($ip, $platform);
        }
    }

    /**
     * @param string $ip
     * @param string $dateDeb
     * @return void
     */
    public function newPartie(string $ip, string $dateDeb): void {
        if($this->partieService->verifyPartieInProgress($ip)){
            $target = "DataBase " . $this->partieService->getDbName();
            $action = "Register new game";
            $explanation = "There already is a game in progress: Player IP=" . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }
        else{
            $this->partieService->addNewPartie($ip, $dateDeb);
        }
    }

    /**
     * @param string $ip
     * @return void
     */
    public function abortPartie(string $ip): void {
        $this->partieService->abortOnGoingPartie($ip);
    }

    /**
     * @param string $ip
     * @param string $dateFin
     * @return void
     */
    public function endPartie(string $ip, string $dateFin): void {
        if(!$this->partieService->verifyPartieInProgress($ip)){
            $target = "DataBase " . $this->partieService->getDbName();
            $action = "End ongoing game";
            $explanation = "There is no game in progress: Player IP=" . $ip;
            throw new CannotDoException($target, $action, $explanation);
        }

        $this->partieService->endPartie($ip, $dateFin);
    }
}