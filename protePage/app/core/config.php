<?php

namespace core;

class Config
{

    public function __construct()
    {

        //turn on output buffering
        ob_start();

        //site address
        switch ($_SERVER['HTTP_HOST']) {
            case '127.0.0.1':
            case 'localhost':
                define('DIR', 'http://localhost/protecoviejo/');
                break;
            case 'proteco.mx':
                define('DIR', 'http://proteco.mx/');
                break;
        }

        define('PDFDIR', DIR . 'app/assets/');

        //set default controller and method for legacy calls
        define('DEFAULT_CONTROLLER', 'bienvenido');
        define('DEFAULT_METHOD', 'index');

        //set a default language
        define('LANGUAGE_CODE', 'es');

        //database details ONLY NEEDED IF USING A DATABASE
        define('DB_TYPE', 'mysql');
        switch ($_SERVER['HTTP_HOST']) {
            case '127.0.0.1':
            case 'localhost':
                define('DB_HOST', 'localhost');
                define('DB_NAME', 'proteco');
                define('DB_USER', 'root');
                define('DB_PASS', '');
                break;
            case 'proteco.mx':
                define('DB_HOST', 'db576899360.db.1and1.com');
                define('DB_NAME', 'db576899360');
                define('DB_USER', 'dbo576899360');
                define('DB_PASS', 'loi8nhdeo9r4;bd');
                break;
        }

        define('PREFIX', '');
        define('IMGTEMPLATE', DIR . 'app/templates/default/img/');

        //set prefix for sessions
        define('SESSION_PREFIX', '');

        //optionall create a constant for the name of the site
        define('SITETITLE', 'PROTECO');

        //turn on custom error handling
        set_exception_handler('core\logger::exception_handler');
        set_error_handler('core\logger::error_handler');

        //set timezone
        date_default_timezone_set('America/Mexico_City');

        //start sessions
        \helpers\session::init();

        //set the default template
        \helpers\session::set('template', 'default');
    }

}
