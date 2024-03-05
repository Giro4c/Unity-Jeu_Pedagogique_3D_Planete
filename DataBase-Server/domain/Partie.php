<?php

namespace domain;

class Partie
{
    protected int $Id_Partie;
    protected string $Date_Deb;
    protected string $Date_Fin;
    protected float $Moy_Questions;
    protected string $Ip_Joueur;
    protected int $Abandon;

    /**
     * @param int $Id_Partie
     * @param string $Date_Deb
     * @param string $Date_Fin
     * @param float $Moy_Questions
     * @param string $Ip_Joueur
     * @param int $Abandon
     */
    public function __construct(int $Id_Partie, string $Date_Deb, string $Date_Fin, float $Moy_Questions, string $Ip_Joueur, int $Abandon)
    {
        $this->Id_Partie = $Id_Partie;
        $this->Date_Deb = $Date_Deb;
        $this->Moy_Questions = $Moy_Questions;
        $this->Date_Fin = $Date_Fin;
        $this->Ip_Joueur = $Ip_Joueur;
        $this->Abandon = $Abandon;
    }

    /**
     * @return int
     */
    public function getIdPartie(): int
    {
        return $this->Id_Partie;
    }

    /**
     * @return string
     */
    public function getDateDeb(): string
    {
        return $this->Date_Deb;
    }

    /**
     * @param int $Id_Partie
     * @return void
     */
    public function setIdPartie(int $Id_Partie): void
    {
        $this->Id_Partie = $Id_Partie;
    }

    /**
     * @param string $Date_Deb
     * @return void
     */
    public function setDateDeb(string $Date_Deb): void
    {
        $this->Date_Deb = $Date_Deb;
    }

    /**
     * @param string $Date_Fin
     * @return void
     */
    public function setDateFin(string $Date_Fin): void
    {
        $this->Date_Fin = $Date_Fin;
    }

    /**
     * @param float $Moy_Questions
     * @return void
     */
    public function setMoyQuestions(float $Moy_Questions): void
    {
        $this->Moy_Questions = $Moy_Questions;
    }

    /**
     * @param string $Ip_Joueur
     * @return void
     */
    public function setIpJoueur(string $Ip_Joueur): void
    {
        $this->Ip_Joueur = $Ip_Joueur;
    }

    /**
     * @param int $Abandon
     * @return void
     */
    public function setAbandon(int $Abandon): void
    {
        $this->Abandon = $Abandon;
    }

    /**
     * @return string
     */
    public function getDateFin(): string
    {
        return $this->Date_Fin;
    }

    /**
     * @return float
     */
    public function getMoyQuestions(): float
    {
        return $this->Moy_Questions;
    }

    /**
     * @return string
     */
    public function getIpJoueur(): string
    {
        return $this->Ip_Joueur;
    }

    /**
     * @return int
     */
    public function getAbandon(): int
    {
        return $this->Abandon;
    }
}
