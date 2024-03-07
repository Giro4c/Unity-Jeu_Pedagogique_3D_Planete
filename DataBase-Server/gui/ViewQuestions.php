<?php

namespace gui;

include_once "View.php";

class ViewQuestions extends View
{
    /**
     * Constructs a new ViewQuestions instance.
     *
     * @param Layout $layout The layout to use for displaying content.
     * @param mixed $jsonQ The JSON string representing the questions.
     */
    public function __construct($layout, mixed $jsonQ)
    {
        parent::__construct($layout);

        $this->title = 'Question';
        $this->content = $jsonQ;
    }
}
