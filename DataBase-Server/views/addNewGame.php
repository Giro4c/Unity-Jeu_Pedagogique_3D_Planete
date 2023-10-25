<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerGame($dbConn);

if (isset($_GET['plateforme'])){
    $ip = $_SERVER['REMOTE_ADDR'];
    //var_dump($ip);
    $plateforme = $_GET['plateforme'];
    //var_dump($plateforme);
    $date = date('Y-m-d H:i:s');
    //var_dump($date);
    try{
        $controller->newPlayer($ip, $plateforme);
    } catch (\utilities\CannotDoException $e){
        $report = $e->getReport();
        $report = str_replace( '\n', '<br />', $report );
        echo '<p>', $report, '</p>';
    }
    try{
        $controller->newPartie($ip, $date);
    } catch (\utilities\CannotDoException $e){
        $report = $e->getReport();
        $report = str_replace( '\n', '<br />', $report );
        echo '<p>', $report, '</p>';
    }
}
else{
    echo "URL not complete, cannot register new player or game.";
}
