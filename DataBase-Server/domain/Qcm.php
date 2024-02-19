<?php

namespace domain;

class Qcm extends Question
{
    protected $Rep1;
    protected $Rep2;
    protected $Rep3;
    protected $Rep4;
    protected $BonneRep;

    public function __construct($Num_Ques, $Enonce, $Type, $Rep1, $Rep2, $Rep3, $Rep4, $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Rep1 = $Rep1;
        $this->Rep3 = $Rep3;
        $this->Rep2 = $Rep2;
        $this->Rep4 = $Rep4;
        $this->BonneRep = $BonneRep;
    }

    /**
     * @return mixed
     */
    public function getRep1()
    {
        return $this->Rep1;
    }

    /**
     * @return mixed
     */
    public function getRep2()
    {
        return $this->Rep2;
    }

    /**
     * @return mixed
     */
    public function getRep3()
    {
        return $this->Rep3;
    }

    /**
     * @return mixed
     */
    public function getRep4()
    {
        return $this->Rep4;
    }

    /**
     * @return mixed
     */
    public function getBonneRep()
    {
        return $this->BonneRep;
    }
}