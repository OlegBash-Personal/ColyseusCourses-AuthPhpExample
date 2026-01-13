<?php
require '../database.php';

$login = $_POST['login'];
$password = $_POST['password'];

if (!isset($login) || !isset($password)) {
    echo 'Data struct error';
    exit;
}

$repeatChecker = R::findOne('users', 'login = ?', array($login));

if (isset($repeatChecker)) {
    echo 'Login reserved';
    exit;
}

$user = R::dispense('users');
$user->login = $login;
$user->password = $password;

R::store($user);

echo 'OK';
