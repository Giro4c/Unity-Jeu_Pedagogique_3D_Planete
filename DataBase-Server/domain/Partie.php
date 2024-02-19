<?php

namespace domain;

class Partie
{
    protected $Id_Partie;
    protected $Date_Deb;
    protected $Date_Fin;
    protected $Moy_Questions;
    protected $Ip_Joueur;
    protected $Abandon;

    public function __construct($Id_Partie, $Date_Deb, $Date_Fin, $Moy_Questions, $Ip_Joueur, $Abandon)
    {
        $this->Id_Partie = $Id_Partie;
        $this->Date_Deb = $Date_Deb;
        $this->Moy_Questions = $Moy_Questions;
        $this->Date_Fin = $Date_Fin;
        $this->Ip_Joueur = $Ip_Joueur;
        $this->Abandon = $Abandon;
    }

    /**
     * @return mixed
     */
    public function getIdPartie()
    {
        return $this->Id_Partie;
    }

    /**
     * @return mixed
     */
    public function getDateDeb()
    {
        return $this->Date_Deb;
    }

    /**
     * @return mixed
     */
    public function getDateFin()
    {
        return $this->Date_Fin;
    }

    /**
     * @return mixed
     */
    public function getMoyQuestions()
    {
        return $this->Moy_Questions;
    }

    /**
     * @return mixed
     */
    public function getIpJoueur()
    {
        return $this->Ip_Joueur;
    }

    /**
     * @return mixed
     */
    public function getAbandon()
    {
        return $this->Abandon;
    }
}