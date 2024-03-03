<?php

namespace domain;

class Qcu extends Question
{
    protected string $Rep1;
    protected string $Rep2;
    protected string $Rep3;
    protected string $Rep4;
    protected string $BonneRep;
    private string $dbName = "QCU";

    /**
     * @param int $Num_Ques
     * @param string $Enonce
     * @param string $Type
     * @param string $Rep1
     * @param string $Rep2
     * @param string $Rep3
     * @param string $Rep4
     * @param string $BonneRep
     */
    public function __construct(int $Num_Ques, string $Enonce, string $Type, string $Rep1, string $Rep2, string $Rep3, string $Rep4, string $BonneRep)
    {
        parent::__construct($Num_Ques, $Enonce, $Type);
        $this->Rep1 = $Rep1;
        $this->Rep3 = $Rep3;
        $this->Rep2 = $Rep2;
        $this->Rep4 = $Rep4;
        $this->BonneRep = $BonneRep;
    }

    public function getDbName(): string{
        return $this->dbName;
    }

    /**
     * @return string
     */
    public function getRep1(): string
    {
        return $this->Rep1;
    }

    /**
     * @return string
     */
    public function getRep2(): string
    {
        return $this->Rep2;
    }

    /**
     * @return string
     */
    public function getRep3(): string
    {
        return $this->Rep3;
    }

    /**
     * @return string
     */
    public function getRep4(): string
    {
        return $this->Rep4;
    }

    /**
     * @return string
     */
    public function getBonneRep(): string
    {
        return $this->BonneRep;
    }
}
