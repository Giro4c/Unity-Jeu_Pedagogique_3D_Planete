<?php

include_once 'data/Database.php';

include_once 'controllers/controllerGame.php';
include_once 'controllers/controllerInteractions.php';
include_once 'controllers/controllerQuestions.php';

include_once 'gui/ViewRandomQuestion.php';
include_once 'gui/ViewInteractions.php';
include_once 'gui/ViewPartie.php';
include_once 'gui/ViewQuestions.php';

use controllers\{controllerGame, controllerQuestions, controllerInteractions};
use database\Database;

if (session_id() == ''){
    session_start();
}

$database = null;
try {
    $database = new Database( new PDO('mysql-jeupedagogique.alwaysdata.net','331395_jeu_pedag','Planete-T3rr3','jeupedagogique_bd'));

} catch (PDOException $e) {
    print "Erreur de connexion !: " . $e->getMessage() . "<br/>";
    die();
}

// initialisation des controllers
$controllerGame = new ControllerGame();
$controllerInte = new ControllerInteractions();
$controllerQuestions = new ControllerQuestions();


$uri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
//if ( '/annonces/index.php/signin' == $uri ){
//
//}

?>

<?php
//session_start();
//$ip = $_SERVER['REMOTE_ADDR'];
//var_dump($ip);
//$plateforme = $_SERVER["HTTP_USER_AGENT"];
////var_dump($plateforme);
//$date = date('Y-m-d H:i:s');
////var_dump($date);
//?>
<!--<form action="./views/test.php">-->
<!--    <button onclick="submit()">Aller vers Test</button>-->
<!--</form>-->