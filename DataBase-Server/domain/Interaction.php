<?php

namespace domain;

/**
 * Class Interaction
 * @package domain
 */
class Interaction
{
    protected int|null $Id_Inte;
    protected string $Nom_Inte;
    protected float $Valeur_Inte;
    protected int $Evaluation;
    protected string $Ip_Joueur;
    protected string $Date_Inte;

    /**
     * Interaction constructor.
     *
     * @param string $Nom_Inte The name of the interaction.
     * @param float $Valeur_Inte The value of the interaction.
     * @param int $Evaluation The evaluation of the interaction.
     * @param string $Ip_Joueur The IP address of the player.
     * @param string $Date_Inte The date of the interaction.
     * @param int|null $Id_Inte The ID of the interaction.
     */
    public function __construct(string $Nom_Inte, float $Valeur_Inte, int $Evaluation, string $Ip_Joueur, string $Date_Inte, int|null $Id_Inte = null)
    {
        $this->Id_Inte = $Id_Inte;
        $this->Nom_Inte = $Nom_Inte;
        $this->Evaluation = $Evaluation;
        $this->Valeur_Inte = $Valeur_Inte;
        $this->Ip_Joueur = $Ip_Joueur;
        $this->Date_Inte = $Date_Inte;
    }

    /**
     * Gets the ID of the interaction.
     *
     * @return int|null The ID of the interaction.
     */
    public function getIdInte(): int|null
    {
        return $this->Id_Inte;
    }

    /**
     * Gets the name of the interaction.
     *
     * @return string The name of the interaction.
     */
    public function getNomInte(): string
    {
        return $this->Nom_Inte;
    }

    /**
     * Gets the value of the interaction.
     *
     * @return float The value of the interaction.
     */
    public function getValeurInte(): float
    {
        return $this->Valeur_Inte;
    }

    /**
     * Gets the evaluation of the interaction.
     *
     * @return int The evaluation of the interaction.
     */
    public function getEvaluation(): int
    {
        return $this->Evaluation;
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
     * Gets the date of the interaction.
     *
     * @return string The date of the interaction.
     */
    public function getDateInte(): string
    {
        return $this->Date_Inte;
    }
}
