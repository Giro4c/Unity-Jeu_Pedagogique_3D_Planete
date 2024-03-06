<?php

namespace domain;

include_once 'domain/Question.php';

/**
 * Represents a multiple choice question.
 */
class Qcu extends Question
{
    protected string $Rep1;
    protected string $Rep2;
    protected string $Rep3;
    protected string $Rep4;
    protected string $BonneRep;

    /**
     * Constructs a new Qcu instance.
     *
     * @param int $Num_Ques The question number.
     * @param string $Enonce The question statement.
     * @param string $Type The type of question.
     * @param string $Rep1 The first answer option.
     * @param string $Rep2 The second answer option.
     * @param string $Rep3 The third answer option.
     * @param string $Rep4 The fourth answer option.
     * @param string $BonneRep The correct answer.
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, string $Rep1, string $Rep2, string $Rep3, string $Rep4, string $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Rep1 = $Rep1;
        $this->Rep2 = $Rep2;
        $this->Rep3 = $Rep3;
        $this->Rep4 = $Rep4;
        $this->BonneRep = $BonneRep;
    }

    /**
     * Gets the first answer option.
     *
     * @return string The first answer option.
     */
    public function getRep1(): string
    {
        return $this->Rep1;
    }

    /**
     * Gets the second answer option.
     *
     * @return string The second answer option.
     */
    public function getRep2(): string
    {
        return $this->Rep2;
    }

    /**
     * Gets the third answer option.
     *
     * @return string The third answer option.
     */
    public function getRep3(): string
    {
        return $this->Rep3;
    }

    /**
     * Gets the fourth answer option.
     *
     * @return string The fourth answer option.
     */
    public function getRep4(): string
    {
        return $this->Rep4;
    }

    /**
     * Gets the correct answer.
     *
     * @return string The correct answer.
     */
    public function getBonneRep(): string
    {
        return $this->BonneRep;
    }
}
