<?php

namespace domain;

class VraiFaux extends Question
{
    protected $Valeur_orbit;
    protected $Valeur_rotation;
    protected $BonneRep;

    public function __construct($Num_Ques, $Enonce, $Type, $Valeur_orbit, $Valeur_rotation, $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Valeur_orbit = $Valeur_orbit;
        $this->BonneRep = $BonneRep;
        $this->Valeur_rotation = $Valeur_rotation;
    }

    public function getValeurOrbit()
    {
        return $this->Valeur_orbit;
    }

    public function getValeurRotation()
    {
        return $this->Valeur_rotation;
    }

    public function getBonneRep()
    {
        return $this->BonneRep;
    }
}