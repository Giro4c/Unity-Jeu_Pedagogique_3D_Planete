<?php

namespace gui;

include_once "View.php";
class ViewRandomQuestion extends View
{
    public function __construct($layout, $jsonRandQ){

        parent::__construct($layout);

        $this->title = 'Random question';
        $this->content = json_encode($jsonRandQ, JSON_PRETTY_PRINT);
    }
}