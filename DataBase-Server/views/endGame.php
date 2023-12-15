<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerGame($dbConn);

$ip = $_SERVER['REMOTE_ADDR'];
$date = date('Y-m-d H:i:s');

try{
    $controller->endPartie($ip, $date);
    echo 'Done, no errors.';
} catch (\utilities\CannotDoException $e){
    $report = $e->getReport();
    $report = str_replace( '\n', '<br />', $report );
    echo '<p>', $report, '</p>';
}
