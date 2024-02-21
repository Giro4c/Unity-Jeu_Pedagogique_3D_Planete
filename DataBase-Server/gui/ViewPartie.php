<?php

namespace gui;

include_once "View.php";
class ViewPartie extends View
{
    public function __construct($layout, $partieStatus, $ip, $date){

        parent::__construct($layout);

        $this->title = 'Partie';

        $this->content = "<p>$partieStatus de $ip, le $date</p>";
    }
}