<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerQuestions($dbConn);
$dbPartie = new \database\DbPartie($dbConn);

$ip = $_SERVER['REMOTE_ADDR'];

if (isset($_GET['qid']) && $dbPartie->verifyPartieInProgress($ip) && isset($_GET['duration']) && isset($_GET['correct'])){
    $controller->addFinishedQuestion($_GET['qid'], $dbPartie->getPartieInProgress($ip)['Id_Partie'], $_GET['duration'], $_GET['correct']);
}
else{
    echo "URL not complete, cannot add question answer to database";
}





