<?php

namespace domain;

class UserAnswer
{
    protected int $Num_Ques;
    protected int $Id_Partie;
    protected string $Date_Deb;
    protected string $Date_Fin;
    protected int $Reussite;

    /**
     * @param int $Num_Ques
     * @param int $Id_Partie
     * @param string $Date_Deb
     * @param string $Date_Fin
     * @param int $Reussite
     */
    public function __construct(int $Num_Ques, int $Id_Partie, string $Date_Deb, string $Date_Fin, int $Reussite)
    {
        $this->Num_Ques = $Num_Ques;
        $this->Id_Partie = $Id_Partie;
        $this->Date_Fin = $Date_Fin;
        $this->Date_Deb = $Date_Deb;
        $this->Reussite = $Reussite;
    }

    /**
     * @return int
     */
    public function getNumQues(): int
    {
        return $this->Num_Ques;
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
     * @return string
     */
    public function getDateFin(): string
    {
        return $this->Date_Fin;
    }

    /**
     * @return int
     */
    public function getReussite(): int
    {
        return $this->Reussite;
    }
}
