<?php

namespace domain;

class Joueur
{
    protected $Ip;
    protected $Plateforme;

    public function __construct($Ip, $Plateforme)
    {
        $this->Plateforme = $Plateforme;
        $this->Ip = $Ip;
    }

    public function getIp()
    {
        return $this->Ip;
    }

    public function getPlateforme()
    {
        return $this->Plateforme;
    }
}