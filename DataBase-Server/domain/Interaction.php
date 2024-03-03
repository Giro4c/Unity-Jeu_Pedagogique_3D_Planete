<?php

namespace domain;
class Interaction
{
    protected int $Id_Inte;
    protected string $Nom_Inte;
    protected float $Valeur_Inte;
    protected int $Evaluation;
    protected string $Ip_Joueur;

    /**
     * @param int $Id_Inte
     * @param string $Nom_Inte
     * @param float $Valeur_Inte
     * @param int $Evaluation
     * @param string $Ip_Joueur
     */
    public function __construct(int $Id_Inte, string $Nom_Inte, float $Valeur_Inte, int $Evaluation, string $Ip_Joueur)
    {
        $this->Id_Inte = $Id_Inte;
        $this->Nom_Inte = $Nom_Inte;
        $this->Evaluation = $Evaluation;
        $this->Valeur_Inte = $Valeur_Inte;
        $this->Ip_Joueur = $Ip_Joueur;
    }

    /**
     * @return int
     */
    public function getIdInte(): int
    {
        return $this->Id_Inte;
    }

    /**
     * @return string
     */
    public function getNomInte(): string
    {
        return $this->Nom_Inte;
    }

    /**
     * @return float
     */
    public function getValeurInte(): float
    {
        return $this->Valeur_Inte;
    }

    /**
     * @return int
     */
    public function getEvaluation(): int
    {
        return $this->Evaluation;
    }

    /**
     * @return string
     */
    public function getIpJoueur(): string
    {
        return $this->Ip_Joueur;
    }
}