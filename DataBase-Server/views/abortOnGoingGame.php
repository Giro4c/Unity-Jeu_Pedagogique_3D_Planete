<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerGame($dbConn);

$ip = $_SERVER['REMOTE_ADDR'];
$controller->abortPartie($ip);