<?php

namespace control;

use service\PartieChecking;
use service\CannotDoException;

class ControllerInteractions
{
    private PartieChecking $interactionService;

    private array $interactionTypes = ["SliderOrbit", "SliderRotation", "DragOrbit", "DragRotation"];

    /**
     * @param PartieChecking $interactionService
     */
    public function __construct(PartieChecking $interactionService) {
        $this->interactionService = $interactionService;
    }

    /**
     * @return string[]
     */
    public function getInteractionTypesAvailable(): array {
        return $this->interactionTypes;
    }

    /**
     * @param string $ipJoueur
     * @param string $type
     * @param float $value
     * @param int $isEval
     * @return void
     */
    public function addInteration(string $ipJoueur, string $type, float $value, int $is_Eval, string $dateInterac): void {
        if (in_array($type, $this->interactionTypes)){
            $this->interactionService->addInteraction($type, $value, $is_Eval, $ipJoueur, $dateInterac);
        }
        else{
            $target = "DataBase " . $this->interactionService->getDbName();
            $action = "Register Interaction";
            $explanation = "Interaction type not correct: " . $type;
            throw new CannotDoException($target, $action, $explanation);
        }
    }
}