<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerQuestions($dbConn);
$dbPartie = new \database\DbPartie($dbConn);

$ip = $_SERVER['REMOTE_ADDR'];

if (isset($_GET['qid']) && $dbPartie->verifyPartieInProgress($ip) && isset($_GET['correct']) && isset($_GET['start'])){
    $dateFin = date('Y-m-d H:i:s');
    $dateDeb = $_GET['start'];
    $controller->addFinishedQuestion($_GET['qid'], $dbPartie->getPartieInProgress($ip)['Id_Partie'], $dateDeb, $dateFin, $_GET['correct']);
}
else{
    echo "URL not complete, cannot add question answer to database";
}