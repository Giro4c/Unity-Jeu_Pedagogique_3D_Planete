<?php

namespace control;

use service\PartieChecking;

class controllerGame
{
    private PartieChecking $partieService;

    public function __construct(PartieChecking $partieService) {
        $this->partieService = $partieService;
    }

    public function newPlayer(string $ip, string $platform): void {
        $this->partieService->addJoueur($ip, $platform);
    }

    public function newPartie(string $ip, string $startDate): void {
        $this->partieService->addNewPartie($ip, $startDate);
    }

    public function abortPartie(string $ip): void {
        $this->partieService->abortOnGoingPartie($ip);
    }

    public function endPartie(string $ip, string $endDate): void {
        $this->partieService->endPartie($ip, $endDate);
    }
}