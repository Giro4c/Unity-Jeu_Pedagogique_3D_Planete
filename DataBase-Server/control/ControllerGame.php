<?php

namespace control;

use service\CannotDoException;
use service\PartieChecking;

/**
 * Class ControllerGame
 * @package control
 */
class ControllerGame
{
    /**
     * Registers a new player.
     *
     * @param string $ip The IP address of the player.
     * @param string $platform The platform of the player.
     * @param PartieChecking $partieService An instance of PartieChecking service.
     * @param mixed $data Additional data.
     * @throws CannotDoException If the player already exists.
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
     * Registers a new game.
     *
     * @param string $ip The IP address of the player.
     * @param string $dateDeb The start date of the game.
     * @param PartieChecking $partieService An instance of PartieChecking service.
     * @param mixed $data Additional data.
     * @throws CannotDoException If there is already a game in progress.
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
     * Aborts an ongoing game.
     *
     * @param string $ip The IP address of the player.
     * @param PartieChecking $partieService An instance of PartieChecking service.
     * @param mixed $data Additional data.
     * @return void
     */
    public function abortPartie(string $ip, PartieChecking $partieService, $data): void {
        $partieService->abortOnGoingPartie($ip, $data);
    }

    /**
     * Ends an ongoing game.
     *
     * @param string $ip The IP address of the player.
     * @param string $dateFin The end date of the game.
     * @param PartieChecking $partieService An instance of PartieChecking service.
     * @param mixed $data Additional data.
     * @throws CannotDoException If there is no game in progress.
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
