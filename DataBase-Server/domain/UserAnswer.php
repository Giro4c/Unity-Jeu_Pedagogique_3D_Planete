<?php

namespace domain;

class UserAnswer
{
    protected $Num_Ques;
    protected $Id_Partie;
    protected $Date_Deb;
    protected $Date_Fin;
    protected $Reussite;

    public function __construct($Num_Ques, $Id_Partie, $Date_Deb, $Date_Fin, $Reussite)
    {
        $this->Num_Ques = $Num_Ques;
        $this->Id_Partie = $Id_Partie;
        $this->Date_Fin = $Date_Fin;
        $this->Date_Deb = $Date_Deb;
        $this->Reussite = $Reussite;
    }

    /**
     * @return mixed
     */
    public function getNumQues()
    {
        return $this->Num_Ques;
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
    public function getReussite()
    {
        return $this->Reussite;
    }
}