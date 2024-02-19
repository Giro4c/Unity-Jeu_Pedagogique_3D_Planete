<?php
namespace control;

use service\PartieChecking;

class ControllerInteractions {
    protected $interactionService;

    public function __construct($interactionService) {
        $this->interactionService = $interactionService;
    }

    public function getInteractionTypesAvailable() {
        // Retourner les types d'interactions disponibles
        return $this->interactionService->getInteractionTypesAvailable();
    }

    public function addInteration($ipJoueur, $type, $value, $isEval) {
        // Ajouter une interaction
        $this->interactionService->addInteraction($type, $value, $isEval, $ipJoueur);
    }
}