<?php

namespace domain;

/**
 * Represents a player.
 *
 * Class Joueur
 * @package domain
 */
class Joueur
{
    protected string $Ip;
    protected string $Plateforme;

    /**
     * Constructs a new Joueur instance.
     *
     * @param string $Ip The IP address of the player.
     * @param string $Plateforme The platform of the player.
     */
    public function __construct(string $Ip, string $Plateforme)
    {
        $this->Plateforme = $Plateforme;
        $this->Ip = $Ip;
    }

    /**
     * Gets the IP address of the player.
     *
     * @return string The IP address of the player.
     */
    public function getIp(): string
    {
        return $this->Ip;
    }

    /**
     * Gets the platform of the player.
     *
     * @return string The platform of the player.
     */
    public function getPlateforme(): string
    {
        return $this->Plateforme;
    }
}
