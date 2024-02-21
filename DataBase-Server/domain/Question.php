<?php

namespace domain;

class Question
{
    protected $Num_Ques;
    protected $Enonce;
    protected $Type;

    public function __construct($Num_Ques, $Enonce, $Type)
    {
        $this->Enonce = $Enonce;
        $this->Num_Ques = $Num_Ques;
        $this->Type = $Type;
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
    public function getEnonce()
    {
        return $this->Enonce;
    }

    /**
     * @return mixed
     */
    public function getType()
    {
        return $this->Type;
    }
}
