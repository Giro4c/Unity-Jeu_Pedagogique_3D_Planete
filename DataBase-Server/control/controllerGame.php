<?php
namespace control;

use service\PartieChecking;

class ControllerGame {
    protected $partieService;

    public function __construct($partieService) {
        $this->partieService = $partieService;
    }

    public function newPlayer($ip, $platform) {
        // Vérifier si le joueur existe déjà
        if (!$this->partieService->verifyJoueurExists($ip)) {
            $this->partieService->addJoueur($ip, $platform);
        }
    }

    public function newPartie($ip, $startDate) {
        // Vérifier si le joueur existe et s'il n'a pas de partie en cours
        if ($this->partieService->verifyJoueurExists($ip) && !$this->partieService->verifyPartieInProgress($ip)) {
            $this->partieService->addNewPartie($ip, $startDate);
        }
    }

    public function abortPartie($ip) {
        // Vérifier si le joueur a une partie en cours et l'arrêter
        if ($this->partieService->verifyPartieInProgress($ip)) {
            $this->partieService->abortOnGoingPartie($ip);
        }
    }

    public function endPartie($ip, $endDate) {
        // Vérifier si le joueur a une partie en cours et la terminer
        if ($this->partieService->verifyPartieInProgress($ip)) {
            $this->partieService->endPartie($ip, $endDate);
        }
    }
}