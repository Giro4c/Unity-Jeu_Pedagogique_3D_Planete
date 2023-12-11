<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerQuestions($dbConn);

// Determining how many questions of each type to retrieve
if (isset($_GET['qcm'])){
    $nbQCM = $_GET['qcm'];
}
else{
    $nbQCM = 0;
}
if (isset($_GET['interaction'])){
    $nbInteraction = $_GET['interaction'];
}
else{
    $nbInteraction = 0;
}
if (isset($_GET['vraifaux'])){
    $nbVraiFaux = $_GET['vraifaux'];
}
else{
    $nbVraiFaux = 0;
}

$ip = $_SERVER['REMOTE_ADDR'];

echo $controller->getRandomQs();
