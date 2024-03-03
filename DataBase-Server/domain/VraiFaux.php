<?php

namespace domain;

class VraiFaux extends Question
{
    protected float $Valeur_orbit;
    protected float $Valeur_rotation;
    protected string $BonneRep;

    /**
     * @param int $Num_Ques
     * @param string $Enonce
     * @param string $Type
     * @param float $Valeur_orbit
     * @param float $Valeur_rotation
     * @param string $BonneRep
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, float $Valeur_orbit, float $Valeur_rotation, string $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Valeur_orbit = $Valeur_orbit;
        $this->BonneRep = $BonneRep;
        $this->Valeur_rotation = $Valeur_rotation;
    }

    /**
     * @return float
     */
    public function getValeurOrbit(): float
    {
        return $this->Valeur_orbit;
    }

    /**
     * @return float
     */
    public function getValeurRotation(): float
    {
        return $this->Valeur_rotation;
    }

    /**
     * @return string
     */
    public function getBonneRep(): string
    {
        return $this->BonneRep;
    }
}
