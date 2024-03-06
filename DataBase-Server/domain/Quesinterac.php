<?php

namespace domain;

include_once 'domain/Question.php';

/**
 * Represents an interactive question.
 */
class Quesinterac extends Question
{
    public float|null $BonneRepValeur_orbit;
    public float|null $Marge_Orbit;
    public float|null $BonneRepValeur_rotation;
    public float|null $Marge_Rotation;

    /**
     * Constructs a new Quesinterac instance.
     *
     * @param int $Num_Ques The question number.
     * @param string $Enonce The question statement.
     * @param string $Type The type of question.
     * @param float|null $BonneRepValeur_orbit The correct value for orbit interaction.
     * @param float|null $Marge_Orbit The margin for orbit interaction.
     * @param float|null $BonneRepValeur_rotation The correct value for rotation interaction.
     * @param float|null $Marge_Rotation The margin for rotation interaction.
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, float|null $BonneRepValeur_orbit, float|null $Marge_Orbit, float|null $BonneRepValeur_rotation, float|null $Marge_Rotation)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->BonneRepValeur_orbit = $BonneRepValeur_orbit;
        $this->Marge_Orbit = $Marge_Orbit;
        $this->BonneRepValeur_rotation = $BonneRepValeur_rotation;
        $this->Marge_Rotation = $Marge_Rotation;
    }

    /**
     * Gets the correct value for orbit interaction.
     *
     * @return float|null The correct value for orbit interaction.
     */
    public function getBonneRepValeurOrbit(): float|null
    {
        return $this->BonneRepValeur_orbit;
    }

    /**
     * Gets the margin for orbit interaction.
     *
     * @return float|null The margin for orbit interaction.
     */
    public function getMargeOrbit(): float|null
    {
        return $this->Marge_Orbit;
    }

    /**
     * Gets the correct value for rotation interaction.
     *
     * @return float|null The correct value for rotation interaction.
     */
    public function getBonneRepValeurRotation(): float|null
    {
        return $this->BonneRepValeur_rotation;
    }

    /**
     * Gets the margin for rotation interaction.
     *
     * @return float|null The margin for rotation interaction.
     */
    public function getMargeRotation(): float|null
    {
        return $this->Marge_Rotation;
    }
}
