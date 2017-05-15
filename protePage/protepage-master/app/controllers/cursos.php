<?php

namespace controllers;

use \core\view as View,
    \helpers\session as Session;

class Cursos extends \core\controller {

    private $_model;

    public function __construct() {
        parent::__construct();
        $this->language->load('cursos');
        $this->_model = new \models\cursos();
    }

    public function index($idpaquete = 0) {
        $data['title'] = $this->language->get('cursos_titulo');

        if (Session::get('loggedin') && Session::get('id')) {
            if (!is_null(filter_input(INPUT_POST, 'action'))) {
                switch (filter_input(INPUT_POST, 'action')) {
                    case "add":
                        $claseRows = $this->_model->getClase(filter_input(INPUT_POST, 'idclase'));
                        if ($_SESSION['tipo'] == 1) {
                            $itemArray = array($claseRows[0]->clave => array("imagen" => $claseRows[0]->imagen, "precio" => $claseRows[0]->precioUnam, "nombre" => $claseRows[0]->curso, "fecha" => date("d-m-Y", strtotime($claseRows[0]->fecha)) . " al " . date("d-m-Y", strtotime($claseRows[0]->fin)), "horario" => date("H:i", strtotime($claseRows[0]->inicio)) . " - " . date("H:i", strtotime($claseRows[0]->final))));
                        } elseif ($_SESSION['tipo'] == 2) {
                            $itemArray = array($claseRows[0]->clave => array("imagen" => $claseRows[0]->imagen, "precio" => $claseRows[0]->precioExterno, "nombre" => $claseRows[0]->curso, "fecha" => date("d-m-Y", strtotime($claseRows[0]->fecha)) . " al " . date("d-m-Y", strtotime($claseRows[0]->fin)), "horario" => date("H:i", strtotime($claseRows[0]->inicio)) . " - " . date("H:i", strtotime($claseRows[0]->final))));
                        } elseif ($_SESSION['tipo'] == 3) {
                            $itemArray = array($claseRows[0]->clave => array("imagen" => $claseRows[0]->imagen, "precio" => $claseRows[0]->precioForaneo, "nombre" => $claseRows[0]->curso, "fecha" => date("d-m-Y", strtotime($claseRows[0]->fecha)) . " al " . date("d-m-Y", strtotime($claseRows[0]->fin)), "horario" => date("H:i", strtotime($claseRows[0]->inicio)) . " - " . date("H:i", strtotime($claseRows[0]->final))));
                        }
                        if (!empty($_SESSION["cart_item"])) {
                            if (!in_array($claseRows[0]->clave, $_SESSION["cart_item"])) {
                                if (count($_SESSION['cart_item']) >= 6) {
                                    
                                } else {
                                    $_SESSION["cart_item"] = $_SESSION["cart_item"] + $itemArray;
                                }
                            }
                        } else {
                            $_SESSION["cart_item"] = $itemArray;
                        }
                        break;
                    case "remove":
                        if (!empty($_SESSION["cart_item"])) {
                            foreach ($_SESSION["cart_item"] as $k => $v) {
                                if (filter_input(INPUT_POST, 'idclase') == $k) {
                                    unset($_SESSION["cart_item"][$k]);
                                }
                                if (empty($_SESSION["cart_item"])) {
                                    unset($_SESSION["cart_item"]);
                                }
                            }
                        }
                        break;
                    case "empty":
                        unset($_SESSION["cart_item"]);
                        break;
                }
            }
        }

        if ($idpaquete) {
            $data['clasesRows'] = $this->_model->getClases($idpaquete);
        }

        $data['paquetesRows'] = $this->_model->getPaquetes();
        $data['materialRows'] = $this->_model->getMaterial();
        $data['semestreActual'] = $this->_model->get_semestre();

        View::rendertemplate('header', $data);
        View::render('cursos/cursos', $data);
        View::rendertemplate('footer', $data);
    }

}
