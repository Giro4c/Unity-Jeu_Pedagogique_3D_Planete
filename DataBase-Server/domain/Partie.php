<?php

namespace domain;

/**
 * Represents a game party.
 */
class Partie
{
    protected int|null $Id_Partie;
    protected string $Date_Deb;
    protected string $Date_Fin;
    protected float|null $Moy_Questions;
    protected string $Ip_Joueur;
    protected int $Abandon;

    /**
     * Constructs a new Partie instance.
     *
     * @param string $Date_Deb The start date of the party.
     * @param string $Ip_Joueur The IP address of the player.
     * @param int $Abandon Indicates if the party was abandoned.
     * @param string|null $Date_Fin The end date of the party. Default is null.
     * @param float|null $Moy_Questions The average score of the questions. Default is null.
     * @param int|null $Id_Partie The ID of the party. Default is null.
     */
    public function __construct(string $Date_Deb, string $Ip_Joueur, int $Abandon, string|null $Date_Fin = null, float|null $Moy_Questions = null, int|null $Id_Partie = null)
    {
        $this->Id_Partie = $Id_Partie;
        $this->Date_Deb = $Date_Deb;
        $this->Moy_Questions = $Moy_Questions;
        $this->Date_Fin = $Date_Fin;
        $this->Ip_Joueur = $Ip_Joueur;
        $this->Abandon = $Abandon;
    }

    /**
     * Gets the ID of the party.
     *
     * @return int|null The ID of the party.
     */
    public function getIdPartie(): int|null
    {
        return $this->Id_Partie;
    }

    /**
     * Gets the start date of the party.
     *
     * @return string The start date of the party.
     */
    public function getDateDeb(): string
    {
        return $this->Date_Deb;
    }

    /**
     * Sets the ID of the party.
     *
     * @param int $Id_Partie The ID of the party.
     * @return void
     */
    public function setIdPartie(int $Id_Partie): void
    {
        $this->Id_Partie = $Id_Partie;
    }

    /**
     * Sets the start date of the party.
     *
     * @param string $Date_Deb The start date of the party.
     * @return void
     */
    public function setDateDeb(string $Date_Deb): void
    {
        $this->Date_Deb = $Date_Deb;
    }

    /**
     * Sets the end date of the party.
     *
     * @param string $Date_Fin The end date of the party.
     * @return void
     */
    public function setDateFin(string $Date_Fin): void
    {
        $this->Date_Fin = $Date_Fin;
    }

    /**
     * Sets the average score of the questions.
     *
     * @param float $Moy_Questions The average score of the questions.
     * @return void
     */
    public function setMoyQuestions(float $Moy_Questions): void
    {
        $this->Moy_Questions = $Moy_Questions;
    }

    /**
     * Sets the IP address of the player.
     *
     * @param string $Ip_Joueur The IP address of the player.
     * @return void
     */
    public function setIpJoueur(string $Ip_Joueur): void
    {
        $this->Ip_Joueur = $Ip_Joueur;
    }

    /**
     * Sets the indication if the party was abandoned.
     *
     * @param int $Abandon Indicates if the party was abandoned.
     * @return void
     */
    public function setAbandon(int $Abandon): void
    {
        $this->Abandon = $Abandon;
    }

    /**
     * Gets the end date of the party.
     *
     * @return string|null The end date of the party.
     */
    public function getDateFin(): string|null
    {
        return $this->Date_Fin;
    }

    /**
     * Gets the average score of the questions.
     *
     * @return float|null The average score of the questions.
     */
    public function getMoyQuestions(): float|null
    {
        return $this->Moy_Questions;
    }

    /**
     * Gets the IP address of the player.
     *
     * @return string The IP address of the player.
     */
    public function getIpJoueur(): string
    {
        return $this->Ip_Joueur;
    }

    /**
     * Gets the indication if the party was abandoned.
     *
     * @return int Indicates if the party was abandoned.
     */
    public function getAbandon(): int
    {
        return $this->Abandon;
    }
}
