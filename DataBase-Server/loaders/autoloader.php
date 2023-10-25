<?php

use database\Database;

require("classloader.php");

$db = new Database('mysql-jeupedagogique.alwaysdata.net','331395_jeu_pedag','Planete-T3rr3','jeupedagogique_bd');
$dbConn = $db->getConnection()->getContent();
