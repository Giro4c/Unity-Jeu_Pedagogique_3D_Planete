<?php

namespace domain;

class Interaction
{
    protected $Id_Inte;
    protected $Nom_Inte;
    protected $Valeur_Inte;
    protected $Evaluation;
    protected $Ip_Joueur;

    public function __construct($Id_Inte, $Nom_Inte, $Valeur_Inte, $Evaluation, $Ip_Joueur)
    {
        $this->Id_Inte = $Id_Inte;
        $this->Nom_Inte = $Nom_Inte;
        $this->Evaluation = $Evaluation;
        $this->Valeur_Inte = $Valeur_Inte;
        $this->Ip_Joueur = $Ip_Joueur;
    }

    public function getIdInte()
    {
        return $this->Id_Inte;
    }

    public function getNomInte()
    {
        return $this->Nom_Inte;
    }

    public function getValeurInte()
    {
        return $this->Valeur_Inte;
    }

    public function getEvaluation()
    {
        return $this->Evaluation;
    }

    public function getIpJoueur()
    {
        return $this->Ip_Joueur;
    }
}
