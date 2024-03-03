<?php

namespace control;

use service\PartieChecking;

class controllerGame
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
        $this->partieService->addJoueur($ip, $platform);
    }

    /**
     * @param string $ip
     * @param string $dateDeb
     * @return void
     */
    public function newPartie(string $ip, string $dateDeb): void {
        $this->partieService->addNewPartie($ip, $dateDeb);
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
        $this->partieService->endPartie($ip, $dateFin);
    }
}