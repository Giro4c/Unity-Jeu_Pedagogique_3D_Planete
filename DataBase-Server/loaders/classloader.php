<?php
// Utilities
require_once("../utilities/GReturn.php");
require_once("../utilities/CannotDoException.php");

// Database
require_once("../database/Database.php");
    // Partie Découverte
require_once("../database/DbInteraction.php");
require_once("../database/DbJoueur.php");
require_once("../database/DbPartie.php");
    // Partie Evaluation
require_once("../database/DbQcu.php");
require_once("../database/DbQuesinterac.php");
require_once("../database/DbReponseUser.php");
require_once("../database/DbQuestion.php");
require_once("../database/DbVraiFaux.php");

// Controllers
require_once("../controllers/controllerInteractions.php");
require_once("../controllers/controllerQuestions.php");
require_once("../controllers/controllerGame.php");