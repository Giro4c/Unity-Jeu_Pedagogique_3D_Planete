<?php
session_start();
$ip = $_SERVER['REMOTE_ADDR'];
var_dump($ip);
$plateforme = $_SERVER["HTTP_USER_AGENT"];
//var_dump($plateforme);
$date = date('Y-m-d H:i:s');
//var_dump($date);
?>
<form action="./views/test.php">
    <button onclick="submit()">Aller vers Test</button>
</form>
