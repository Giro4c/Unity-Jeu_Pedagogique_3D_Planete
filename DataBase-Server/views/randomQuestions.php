<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerQuestions($dbConn);

// Determining how many questions of each type to retrieve
if (isset($_GET['qcu'])){
    $nbQCU = $_GET['qcu'];
}
else{
    $nbQCU = 0;
}
//var_dump($nbQCM);
if (isset($_GET['interaction'])){
    $nbInteraction = $_GET['interaction'];
}
else{
    $nbInteraction = 0;
}
//var_dump($nbInteraction);
if (isset($_GET['vraifaux'])){
    $nbVraiFaux = $_GET['vraifaux'];
}
else{
    $nbVraiFaux = 0;
}
//var_dump($nbVraiFaux);

echo $controller->getRandomQs($nbQCU, $nbInteraction, $nbVraiFaux);
