<?php

namespace domain;

/**
 * Represents a generic question.
 */
class Question
{
    public int $Num_Ques;
    public string $Enonce;
    public string $Type;

    /**
     * Constructs a new Question instance.
     *
     * @param int $Num_Ques The question number.
     * @param string $Enonce The question statement.
     * @param string $Type The type of question.
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type)
    {
        $this->Enonce = $Enonce;
        $this->Num_Ques = $Num_Ques;
        $this->Type = $Type;
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
     * Gets the question statement.
     *
     * @return string The question statement.
     */
    public function getEnonce(): string
    {
        return $this->Enonce;
    }

    /**
     * Gets the type of question.
     *
     * @return string The type of question.
     */
    public function getType(): string
    {
        return $this->Type;
    }
}
