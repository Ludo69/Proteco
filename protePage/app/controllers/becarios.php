<?php
//esto es un comentario agregado
namespace controllers;

use \core\view as View,
    \helpers\session as Session,
    \helpers\url as Url;

class Becarios extends \core\controller {

    private $_model;

    public function __construct() {
        parent::__construct();


        if (!Session::get('loggedin') && !Session::get('id')) {
            Url::redirect();
        }

        if (!($_SESSION['rol'] == '4' || $_SESSION['rol'] = '3')) {
            Url::redirect();
        }

        $this->language->load('becarios');
        $this->_model = new \models\becarios();
    }

    public function index() {

    }

    public function isVacia($arg){
        return ($arg == '');
    }

    public function registroAsesorias() {
        $data['title'] = $this->language->get('becarios_titulo');
        
        $data['becarios'] = $this->_model->get_becarios();

        if (!is_null(filter_input(INPUT_POST, 'submit'))){
            $fecha = filter_input(INPUT_POST, 'fecha');
            $nombreAsesorado = filter_input(INPUT_POST, 'nombreAsesorado');
            $FK_becario = filter_input(INPUT_POST, 'FK_becario');
            $materia = filter_input(INPUT_POST, 'materia');
            $profesor = filter_input(INPUT_POST, 'profesor');
            $hora = filter_input(INPUT_POST, 'hora');
            $FK_usuario = filter_input(INPUT_POST, 'FK_usuario');

            if(
                $this->isVacia($fecha) ||
                $this->isVacia($nombreAsesorado) ||
                $this->isVacia($FK_becario) ||
                $this->isVacia($materia) ||
                $this->isVacia($profesor) ||
                $this->isVacia($hora) ||
                $this->isVacia($FK_usuario)
            ){
                $error[] = "Campos vacíos.";
            }
            else{
                $asesoriaData = array(
                    'fecha' => $fecha,
                    'nombreAsesorado' => $nombreAsesorado,
                    'FK_becario' => $FK_becario,
                    'materia' => $materia,
                    'profesor' => $profesor,
                    'hora' => $hora,
                    'FK_usuario' => $FK_usuario
                );
                $this->_model->insert_asesoria($asesoriaData);
                $data['aviso'] = '<b>Asesoria registrada en la base de datos.</b>';
            }
        }

        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('becarios/registroAsesorias', $data, $error);
        View::rendertemplate('footer', $data);
    }

}
