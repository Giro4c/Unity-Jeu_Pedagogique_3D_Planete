<?php

namespace controllers;

use database\DbInteraction;
//use utilities\GReturn;
use utilities\CannotDoException;

class controllerInteractions
{

    private DbInteraction $dbInteraction;
    private array $interactionTypes = ["SliderOrbit", "SliderRotation", "DragOrbit", "DragRotation"];

    public function __construct($conn){
        $this->dbInteraction = new DbInteraction($conn);
    }

    public function getInteractionTypesAvailable(): array{
        return $this->interactionTypes;
    }

    /**
     * @throws CannotDoException
     */
    public function addInteration(string $ipJoueur, string $type, float $value, int $is_Eval, string $dateInterac): void{
        if (in_array($type, $this->interactionTypes)){
            $this->dbInteraction->addInteraction($type, $value, $is_Eval, $ipJoueur, $dateInterac);
        }
        else{
            $target = "DataBase " . $this->dbInteraction->getDbName();
            $action = "Register Interaction";
            $explanation = "Interaction type not correct: " . $type;
            throw new CannotDoException($target, $action, $explanation);
        }
    }

}