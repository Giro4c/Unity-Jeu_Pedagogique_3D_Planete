<?php

namespace domain;

class Quesinterac extends Question
{
    protected $BonneRepValeur_orbit;
    protected $Marge_Orbit;
    protected $BonneRepValeur_rotation;
    protected $Marge_Rotation;

    public function __construct($Num_Ques, $Enonce, $Type, $BonneRepValeur_orbit, $Marge_Orbit, $BonneRepValeur_rotation, $Marge_Rotation)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->BonneRepValeur_orbit = $BonneRepValeur_orbit;
        $this->BonneRepValeur_rotation = $BonneRepValeur_rotation;
        $this->Marge_Orbit = $Marge_Orbit;
        $this->Marge_Rotation = $Marge_Rotation;
    }

    /**
     * @return mixed
     */
    public function getBonneRepValeurOrbit()
    {
        return $this->BonneRepValeur_orbit;
    }

    /**
     * @return mixed
     */
    public function getMargeOrbit()
    {
        return $this->Marge_Orbit;
    }

    /**
     * @return mixed
     */
    public function getBonneRepValeurRotation()
    {
        return $this->BonneRepValeur_rotation;
    }

    /**
     * @return mixed
     */
    public function getMargeRotation()
    {
        return $this->Marge_Rotation;
    }
}