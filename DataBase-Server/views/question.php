<?php
require("../loaders/autoloader.php");
$controller = new controllers\controllerQuestions($dbConn);

// See if there is an indicated question in the url
if (isset($_GET['qid'])){
    echo $controller->getJsonAttributesQ($_GET['qid']);
}
else{
    echo "URL not complete, cannot show question attributes";
}
