<?php

namespace domain;

class Question
{
    protected int $Num_Ques;
    protected string $Enonce;
    protected string $Type;
    private string $dbName = "QUESTION";

    /**
     * @param int $Num_Ques
     * @param string $Enonce
     * @param string $Type
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type)
    {
        $this->Enonce = $Enonce;
        $this->Num_Ques = $Num_Ques;
        $this->Type = $Type;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    /**
     * @return int
     */
    public function getNumQues(): int
    {
        return $this->Num_Ques;
    }

    /**
     * @return string
     */
    public function getEnonce(): string
    {
        return $this->Enonce;
    }

    /**
     * @return string
     */
    public function getType(): string
    {
        return $this->Type;
    }
}
