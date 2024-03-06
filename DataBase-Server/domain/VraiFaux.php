<?php

namespace domain;

include_once 'domain/Question.php';

/**
 * Represents a true/false type question.
 */
class VraiFaux extends Question
{
    public float|null $Valeur_orbit;
    public float|null $Valeur_rotation;
    public string $BonneRep;

    /**
     * Constructs a new VraiFaux instance.
     *
     * @param int $Num_Ques The question number.
     * @param string $Enonce The statement of the question.
     * @param string $Type The type of the question.
     * @param float|null $Valeur_orbit The orbit value.
     * @param float|null $Valeur_rotation The rotation value.
     * @param string $BonneRep The correct answer.
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, float|null $Valeur_orbit, float|null $Valeur_rotation, string $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Valeur_orbit = $Valeur_orbit;
        $this->BonneRep = $BonneRep;
        $this->Valeur_rotation = $Valeur_rotation;
    }

    /**
     * Gets the orbit value.
     *
     * @return float|null The orbit value.
     */
    public function getValeurOrbit(): float|null
    {
        return $this->Valeur_orbit;
    }

    /**
     * Gets the rotation value.
     *
     * @return float|null The rotation value.
     */
    public function getValeurRotation(): float|null
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