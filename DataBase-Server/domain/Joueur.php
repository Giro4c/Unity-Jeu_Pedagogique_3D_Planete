<?php

namespace domain;

class Joueur
{
    protected string $Ip;
    protected string $Plateforme;

    private string $dbName = "JOUEUR";

    /**
     * @param string $Ip
     * @param string $Plateforme
     */
    public function __construct(string $Ip, string $Plateforme)
    {
        $this->Plateforme = $Plateforme;
        $this->Ip = $Ip;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    /**
     * @return string
     */
    public function getIp(): string
    {
        return $this->Ip;
    }

    /**
     * @return string
     */
    public function getPlateforme(): string
    {
        return $this->Plateforme;
    }
}
