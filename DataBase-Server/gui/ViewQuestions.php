<?php

namespace gui;

include_once "View.php";
class ViewQuestions extends View
{
    public function __construct($layout, $question){

        parent::__construct($layout);

        $this->title = 'Question';
        $question = "Pk t gay ?";
        $json = array("Question" => $question);
        $this->content = json_encode($json, JSON_PRETTY_PRINT);

        echo (json_encode($json, JSON_PRETTY_PRINT));
    }
}