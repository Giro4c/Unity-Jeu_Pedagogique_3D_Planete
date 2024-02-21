<?php

include_once 'data/DataAccess.php';

include_once 'controllers/controllerGame.php';
include_once 'controllers/controllerInteractions.php';
include_once 'controllers/controllerQuestions.php';

include_once 'gui/Layout.php';
include_once 'gui/ViewRandomQuestion.php';
include_once 'gui/ViewInteractions.php';
include_once 'gui/ViewPartie.php';
include_once 'gui/ViewQuestions.php';

use controllers\{controllerGame, controllerQuestions, controllerInteractions};
use data\DataAccess;
use gui\{Layout, ViewInteractions, ViewPartie, ViewQuestions, ViewRandomQuestion};


if (session_id() == '') {
    session_start();
}

$data = null;
try {
    $data = new DataAccess(new PDO('mysql-jeupedagogique.alwaysdata.net', '331395_jeu_pedag', 'Planete-T3rr3', 'jeupedagogique_bd'));

} catch (PDOException $e) {
    print "Erreur de connexion !: " . $e->getMessage() . "<br/>";
    die();
}

// initialisation des controllers
$controllerGame = new ControllerGame($data);
$controllerInte = new ControllerInteractions($data);
$controllerQuestions = new ControllerQuestions($data);


$uri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);

if ('index.php/addInteraction' == $uri) {

    if (isset($_GET["type"]) && isset($_GET["value"]) && isset($_GET["isEval"])) {
        $ip = $_SERVER['REMOTE_ADDR'];
        $type = $_GET["type"];
        $value = $_GET["value"];
        $isEval = $_GET["isEval"];
        $dateInteract = date('Y-m-d H:i:s');

        try {
            $controllerInte->addInteration($ip, $type, (float)$value, $isEval, $dateInteract);
        } catch (\utilities\CannotDoException $e) {
            $report = $e->getReport();
            $report = str_replace('\n', '<br />', $report);
            echo '<p>', $report, '</p>';
        }

        $layout = new Layout("gui/layout.html");
        $viewInterac = new ViewInteractions($layout);

        $viewInterac->display();
    } else {
        echo "URL not complete, cannot register new interaction.";
    }
}
elseif ( '/index.php/abordOnGoingGame' == $uri){

    $ip = $_SERVER['REMOTE_ADDR'];
    $controllerGame->abortPartie($ip);
}
elseif ( '/index.php/NewGame' == $uri){

    if (isset($_GET['plateforme'])){
        $ip = $_SERVER['REMOTE_ADDR'];
        $plateforme = $_GET['plateforme'];
        $date = date('Y-m-d H:i:s');
        try{
            $controllerGame->newPlayer($ip, $plateforme);
        } catch (\utilities\CannotDoException $e){
            $report = $e->getReport();
            $report = str_replace( '\n', '<br />', $report );
            echo '<p>', $report, '</p>';
        }
        try{
            $controllerGame->newPartie($ip, $date);
        } catch (\utilities\CannotDoException $e){
            $report = $e->getReport();
            $report = str_replace( '\n', '<br />', $report );
            echo '<p>', $report, '</p>';
        }
    }
    else{
        echo "URL not complete, cannot register new player or game.";
    }
}
elseif ( '/index.php/QuestionAnswer' == $uri){

    $ip = $_SERVER['REMOTE_ADDR'];

    if (isset($_GET['qid']) && $data->verifyPartieInProgress($ip) && isset($_GET['correct']) && isset($_GET['start'])){
        $dateFin = date('Y-m-d H:i:s');
        $dateDeb = $_GET['start'];
        $controllerQuestions->addFinishedQuestion($_GET['qid'], $data->getPartieInProgress($ip)['Id_Partie'], $dateDeb, $dateFin, $_GET['correct']);
    }
    else{
        echo "URL not complete, cannot add question answer to database";
    }
}
elseif ( '/index.php/endGame' == $uri){
    $ip = $_SERVER['REMOTE_ADDR'];
    $date = date('Y-m-d H:i:s');

    try{
        $controllerGame->endPartie($ip, $date);
        echo 'Done, no errors.';
    } catch (\utilities\CannotDoException $e){
        $report = $e->getReport();
        $report = str_replace( '\n', '<br />', $report );
        echo '<p>', $report, '</p>';
    }

}
elseif ( '/index.php/question' == $uri){

    // See if there is an indicated question in the url
    if (isset($_GET['qid'])){
        echo $controllerQuestions->getHTMLAttributesQ($_GET['qid']);
    }
    else{
        echo "URL not complete, cannot show question attributes";
    }
}
elseif ( '/index.php/randomQuestions' == $uri){

// Determining how many questions of each type to retrieve
    if (isset($_GET['qcu'])){
        $nbQCU = $_GET['qcu'];
    }
    else{
        $nbQCU = 0;
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

    echo $controllerQuestions->getRandomQs($nbQCU, $nbInteraction, $nbVraiFaux);
}
else {
    header('Status: 404 Not Found');
    echo '<html><body><h1>My Page NotFound</h1></body></html>';
}