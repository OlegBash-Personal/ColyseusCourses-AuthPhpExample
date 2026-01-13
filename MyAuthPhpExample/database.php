<?php
require 'RedBeanPHP/rb-mysql.php';

R::setup('mysql:host=localhost;dbname=FirstBD', 'root', '');

if (R::testConnection() == false) {
    echo 'False connection';
    exit;
}
