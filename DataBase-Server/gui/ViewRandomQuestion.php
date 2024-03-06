<?php

namespace gui;

include_once "View.php";

class ViewRandomQuestion extends View
{
    /**
     * Constructs a new ViewRandomQuestion instance.
     *
     * @param Layout $layout The layout to use for displaying content.
     * @param mixed $jsonRandQ The random question data to display.
     */
    public function __construct($layout, $jsonRandQ)
    {
        parent::__construct($layout);

        $this->title = 'Random question';
        $this->content = json_encode($jsonRandQ, JSON_PRETTY_PRINT);
    }
}
