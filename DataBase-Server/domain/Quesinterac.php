<?php

namespace domain;

include_once 'domain/Question.php';

class Quesinterac extends Question
{
    protected float $BonneRepValeur_orbit;
    protected float $Marge_Orbit;
    protected float $BonneRepValeur_rotation;
    protected float $Marge_Rotation;

    /**
     * @param int $Num_Ques
     * @param string $Enonce
     * @param string $Type
     * @param float $BonneRepValeur_orbit
     * @param float $Marge_Orbit
     * @param float $BonneRepValeur_rotation
     * @param float $Marge_Rotation
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, float $BonneRepValeur_orbit, float $Marge_Orbit, float $BonneRepValeur_rotation, float $Marge_Rotation)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->BonneRepValeur_orbit = $BonneRepValeur_orbit;
        $this->BonneRepValeur_rotation = $BonneRepValeur_rotation;
        $this->Marge_Orbit = $Marge_Orbit;
        $this->Marge_Rotation = $Marge_Rotation;
    }

    /**
     * @return float
     */
    public function getBonneRepValeurOrbit(): float
    {
        return $this->BonneRepValeur_orbit;
    }

    /**
     * @return float
     */
    public function getMargeOrbit(): float
    {
        return $this->Marge_Orbit;
    }

    /**
     * @return float
     */
    public function getBonneRepValeurRotation(): float
    {
        return $this->BonneRepValeur_rotation;
    }

    /**
     * @return float
     */
    public function getMargeRotation(): float
    {
        return $this->Marge_Rotation;
    }
}
