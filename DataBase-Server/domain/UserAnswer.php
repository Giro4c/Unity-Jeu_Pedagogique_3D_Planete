<?php

namespace domain;

/**
 * Represents a user's answer to a question.
 */
class UserAnswer
{
    protected int $Num_Ques;
    protected int $Id_Partie;
    protected string $Date_Deb;
    protected string $Date_Fin;
    protected int $Reussite;

    /**
     * Constructs a new UserAnswer instance.
     *
     * @param int $Num_Ques The question number.
     * @param int $Id_Partie The ID of the game party.
     * @param string $Date_Deb The start date of the answer.
     * @param string $Date_Fin The end date of the answer.
     * @param int $Reussite The success status of the answer.
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
     * Gets the question number.
     *
     * @return int The question number.
     */
    public function getNumQues(): int
    {
        return $this->Num_Ques;
    }

    /**
     * Gets the ID of the game party.
     *
     * @return int The ID of the game party.
     */
    public function getIdPartie(): int
    {
        return $this->Id_Partie;
    }

    /**
     * Gets the start date of the answer.
     *
     * @return string The start date of the answer.
     */
    public function getDateDeb(): string
    {
        return $this->Date_Deb;
    }

    /**
     * Gets the end date of the answer.
     *
     * @return string The end date of the answer.
     */
    public function getDateFin(): string
    {
        return $this->Date_Fin;
    }

    /**
     * Gets the success status of the answer.
     *
     * @return int The success status of the answer.
     */
    public function getReussite(): int
    {
        return $this->Reussite;
    }
}
