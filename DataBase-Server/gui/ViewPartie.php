<?php

namespace gui;

include_once "View.php";

class ViewPartie extends View
{
    /**
     * Constructs a new ViewPartie instance.
     *
     * @param Layout $layout The layout to use for displaying content.
     * @param string $partieStatus The status of the game.
     * @param string $ip The IP address associated with the game.
     * @param string $date The date of the game.
     */
    public function __construct($layout, string $partieStatus, string $ip, string $date)
    {
        parent::__construct($layout);

        $this->title = 'Partie';

        $this->content = "<p>$partieStatus de $ip, le $date</p>";
    }
}
