<?php

if (file_exists('vendor/autoload.php')) {
    require 'vendor/autoload.php';
} else {
    echo "<h1>Please install via composer.json</h1>";
    echo "<p>Install Composer instructions: <a href='https://getcomposer.org/doc/00-intro.md#globally'>https://getcomposer.org/doc/00-intro.md#globally</a></p>";
    echo "<p>Once composer is installed navigate to the working directory in your terminal/command promt and enter 'composer install'</p>";
    exit;
}

if (!is_readable('app/core/config.php')) {
    die('No config.php found, configure and rename config.example.php to config.php in app/core.');
}

switch ($_SERVER['HTTP_HOST']) {
    case '127.0.0.1':
    case 'localhost':
        define('ENVIRONMENT', 'development');
        break;
    case 'proteco.mx':
        define('ENVIRONMENT', 'production');
        break;
}



if (defined('ENVIRONMENT')) {
    switch (ENVIRONMENT) {
        case 'development':
            error_reporting(E_ALL);
            break;
        case 'production':
            error_reporting(0);
            break;
        default:
            exit('The application environment is not set correctly.');
    }
}

//set_time_limit (5000);
ini_set('memory_limit', '256M');
header("Content-Type: text/html;charset=utf-8");

//initiate config
new \core\config();

//create alias for Router
use \core\router as Router;

//define routes

// Rutas para Ambos
Router::any('', '\controllers\bienvenido@index');
Router::any('(:any)', '\controllers\bienvenido@post');
Router::any('nosotros', '\controllers\bienvenido@nosotros');
Router::any('contacto', '\controllers\bienvenido@contacto');
Router::any('ayuda', '\controllers\bienvenido@ayuda');
Router::any('unete', '\controllers\bienvenido@unete');
Router::any('cursos', '\controllers\cursos@index');
Router::any('cursos/(:num)', '\controllers\cursos@index');

// Rutas para No Logeados
Router::any('registro', '\controllers\registro@index');
Router::any('recupera', '\controllers\auth@recupera');
Router::any('login', '\controllers\auth@login');

// Rutas para Logeados
Router::any('logout', '\controllers\auth@logout');
Router::any('perfil', '\controllers\perfil@index');
Router::any('miscursos', '\controllers\perfil@misCursos');
Router::any('mistalleres', '\controllers\perfil@misTalleres');
Router::any('pdf', '\controllers\recibo@generar');
Router::any('pdfh', '\controllers\recibo@generar2');
Router::any('arduino', '\controllers\recibo@arduino');
Router::any('configuracion','\controllers\perfil@configuracion');

// Rutas para becarios
Router::any('registroAsesorias', '\controllers\becarios@registroAsesorias');

// Rutas para Administradores
Router::any('administracion', '\controllers\administracion@index');
Router::any('altaAlumno', '\controllers\administracion@altaAlumno');
Router::any('altaBecado', '\controllers\administracion@altaBecado');
Router::any('altaSemestre', '\controllers\administracion@altaSemestre'); //nuevo
Router::any('altaCurso', '\controllers\administracion@altaCurso'); //nuevo
Router::any('precios', '\controllers\administracion@precios'); //nuevo
Router::any('altaBecario', '\controllers\administracion@altaBecario'); //nuevo
Router::any('infoBecarios', '\controllers\administracion@infoBecarios'); 
Router::any('infoAsesorias', '\controllers\administracion@infoAsesorias'); 
Router::any('infoInters', '\controllers\administracion@infoInters');
Router::any('infoAlumno', '\controllers\administracion@infoAlumno'); //actualizado
Router::any('infoAlumno/(:num)', '\controllers\administracion@infoAlumnoNum'); //actualizado
Router::any('generarLista/(:num)', '\controllers\administracion@generarLista');
Router::any('verPost', '\controllers\post@index');
Router::any('altaPost', '\controllers\post@add');
Router::any('editarPost/(:num)', '\controllers\post@edit');
Router::any('eliminarPost/(:num)', '\controllers\post@delete');
Router::any('editarEstado/(:num)', '\controllers\post@update_estado');

//if no route found
Router::error('\core\error@index');

//turn on old style routing
Router::$fallback = true;

//execute matched routes
Router::dispatch();
