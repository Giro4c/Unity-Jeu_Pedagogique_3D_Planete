<?php

namespace gui;

include_once "View.php";
class ViewRandomQuestion extends View
{
    public function __construct($layout, $nbRandomQs){

        parent::__construct($layout);

        $this->title = 'Random question';
        $json = array("Random question" => $nbRandomQs);
        $this->content = json_encode($json, JSON_PRETTY_PRINT);
    }
}