<?php

namespace domain;

include_once 'domain/Question.php';

/**
 * Represents a true/false type question.
 */
class VraiFaux extends Question
{
    protected float $Valeur_orbit;
    protected float $Valeur_rotation;
    protected string $BonneRep;

    /**
     * Constructs a new VraiFaux instance.
     *
     * @param int $Num_Ques The question number.
     * @param string $Enonce The statement of the question.
     * @param string $Type The type of the question.
     * @param float $Valeur_orbit The orbit value.
     * @param float $Valeur_rotation The rotation value.
     * @param string $BonneRep The correct answer.
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, float $Valeur_orbit, float $Valeur_rotation, string $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Valeur_orbit = $Valeur_orbit;
        $this->BonneRep = $BonneRep;
        $this->Valeur_rotation = $Valeur_rotation;
    }

    /**
     * Gets the orbit value.
     *
     * @return float The orbit value.
     */
    public function getValeurOrbit(): float
    {
        return $this->Valeur_orbit;
    }

    /**
     * Gets the rotation value.
     *
     * @return float The rotation value.
     */
    public function getValeurRotation(): float
    {
        return $this->Valeur_rotation;
    }

    /**
     * Gets the correct answer.
     *
     * @return string The correct answer.
     */
    public function getBonneRep(): string
    {
        return $this->BonneRep;
    }
}