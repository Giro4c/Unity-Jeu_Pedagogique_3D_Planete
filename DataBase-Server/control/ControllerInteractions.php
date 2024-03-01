<?php

namespace control;

use service\PartieChecking;

class ControllerInteractions
{
    private PartieChecking $interactionService;

    public function __construct(PartieChecking $interactionService) {
        $this->interactionService = $interactionService;
    }

    public function getInteractionTypesAvailable(): array {
        return ['Type1', 'Type2', 'Type3']; // Exemple: types d'interactions disponibles
    }

    public function addInteration(string $ipJoueur, string $type, float $value, int $isEval): void {
        $this->interactionService->addInteraction($type, $value, $isEval, $ipJoueur);
    }
}