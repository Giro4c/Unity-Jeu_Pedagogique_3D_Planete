<?php

namespace gui;

include_once "View.php";
class ViewInteractions extends View
{
    public function __construct($layout, $interaction){

        parent::__construct($layout);

        $this->title = 'Ajout Interaction';

        $this->content = "<p>L'interaction $interaction à bien été enregistrée</p>";

    }
}