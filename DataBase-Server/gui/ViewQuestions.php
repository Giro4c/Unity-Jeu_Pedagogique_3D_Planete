<?php

namespace gui;

include_once "View.php";
class ViewQuestions extends View
{
    public function __construct($layout, $question){

        parent::__construct($layout);

        $this->title = 'Question';

        $this->content = "<p>$question</p>";
    }
}