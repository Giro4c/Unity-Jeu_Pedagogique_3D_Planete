<?php

namespace gui;

include_once "View.php";
class ViewQuestions extends View
{
    public function __construct($layout, $jsonQ){

        parent::__construct($layout);

        $this->title = 'Question';
        $this->content = $jsonQ;

    }
}