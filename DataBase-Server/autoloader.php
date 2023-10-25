<?php

use database\Database;

require_once("database/Database.php");
require_once("database/");

$db = new Database('mysql-echo.alwaysdata.net','echo_mathieu','130304leroux','echo_bd');
$dbConn = $db->getConnection()->getContent();
