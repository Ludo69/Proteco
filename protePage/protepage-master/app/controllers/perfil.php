<?php

namespace controllers;

use \core\view as View,
    \helpers\session as Session,
    \helpers\url as Url,
    \helpers\password as Password,
    \helpers\data as Data;

class Perfil extends \core\controller {

    private $_model;

    public function __construct() {
        parent::__construct();

        if (!Session::get('loggedin') && !Session::get('id')) {
            Url::redirect();
        }

        $this->language->load('perfil');
        $this->_model = new \models\perfil();
    }

    public function index() {
        $data['title'] = $this->language->get('perfil_titulo');
        View::rendertemplate('header', $data);

        $data["row"] = $this->_model->get_datos($_SESSION['id']);

        if ($data["row"][0]->tipo == 1) {
            $data['escuela'] = $this->_model->get_unam($data["row"][0]->idusuario);
        } elseif ($data["row"][0]->tipo == 2) {
            $data['escuela'] = $this->_model->get_foraneo($data["row"][0]->idusuario);
        } elseif ($data["row"][0]->tipo == 3) {
            $data['escuela'] = $this->_model->get_externo($data["row"][0]->idusuario);
        }

        View::render('perfil/perfil', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function misCursos() {
        $data['title'] = $this->language->get('cursos_titulo');

        if (Session::get('loggedin') && Session::get('id') && !isset($_SESSION["folio"])) {
            if (!is_null(filter_input(INPUT_POST, 'action'))) {
                switch (filter_input(INPUT_POST, 'action')) {
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
                    case "inscribir":
                        $cuota = filter_input(INPUT_POST, "cuota");
                        // Estado  
                        // 1 -> No confirmado
                        // 2 -> Parcial
                        // 3 -> Confirmado
                        $estado = 1;
                        $usuario = $_SESSION['id'];
                        // Tipo
                        // Becado -> 2
                        // Normal -> 1
                        $tipo = 1;
                        $semestre = $this->_model->get_semestre();
                        $interdata = array(
                            'cuota' => $cuota,
                            'FK_estado' => $estado,
                            'FK_usuario' => $usuario,
                            'tipo' => $tipo,
                            'semestre' => $semestre
                        );
                        $this->_model->insert_intersemestral($interdata);
                        $_SESSION['folio'] = $this->_model->get_folio($cuota, $estado, $usuario, $tipo, $semestre);
                        foreach ($_SESSION["cart_item"] as $k => $v) {
                            $misCursosdata = array(
                                'FK_folio' => $_SESSION['folio'],
                                'FK_clase' => $k,
                                'FK_estado' => 1,
                                'asistencia' => 0,
                                'calificacion' => 0
                            );
                            $this->_model->insert_miscursos($misCursosdata);
                        }
                        $data["aviso"] = "Cursos registrados correctamente.";
                        if (isset($_SESSION["folio"])) {
                            $data["estadoRows"] = $this->_model->get_estatus($_SESSION['id'], $semestre);
                            $data["misCursos"] = $this->_model->get_misCursos($_SESSION['folio']);
                        }
                        break;
                }
            }
        } elseif (isset($_SESSION["folio"])) {

            if (!is_null(filter_input(INPUT_POST, 'action'))) {
                switch (filter_input(INPUT_POST, 'action')) {
                    case 'baja':
                        $folio = $_SESSION["folio"];
                        if (isset($_SESSION["folio"])) {
                            $where1 = array('FK_folio' => $folio);
                            $this->_model->delete_mis_cursos($where1, count($_SESSION['cart_item']));
                            $where2 = array('folio' => $folio);
                            $this->_model->delete_intersemestral($where2);
                            unset($_SESSION['cart_item']);
                            unset($_SESSION['folio']);
                            $data["aviso"] = "Cursos eliminados correctamente.";
                        }
                        break;
                }
            }
            if (isset($_SESSION["folio"])) {
                $semestre = $this->_model->get_semestre();
                $data["estadoRows"] = $this->_model->get_estatus($_SESSION['id'], $semestre);
                $data["misCursos"] = $this->_model->get_misCursos($_SESSION['folio']);
            }
        }

        View::rendertemplate('header', $data);
        View::render('perfil/miscursos', $data);
        View::rendertemplate('footer', $data);
    }

    public function misTalleres() {
        $data['title'] = $this->language->get('talleres_titulo');
        View::rendertemplate('header', $data);
        View::render('perfil/mistalleres', $data);
        View::rendertemplate('footer', $data);
    }

    public function configuracion() {

        $data['title'] = "Editar mi perfil";
        View::rendertemplate('header', $data);

        $data["row"] = $this->_model->get_datos($_SESSION['id']);

        if (!is_null(filter_input(INPUT_POST, 'editsubmit'))) {
            $nombre = filter_input(INPUT_POST, 'nombre');
            $apaterno = filter_input(INPUT_POST, 'apaterno');
            $amaterno = filter_input(INPUT_POST, 'amaterno');

            if ($nombre == '') {
                $error[] = 'Campos vacios';
            }

            if ($apaterno == '') {
                $error[] = 'Campos vacios';
            }

            if ($amaterno == '') {
                $error[] = 'Campos vacios';
            }

            if (!$error) {

                $datausuario = array(
                    'apellidoP' => Data::ucw($apaterno),
                    'apellidoM' => Data::ucw($amaterno),
                    'nombres' => Data::ucw($nombre)
                );

                $where = array('idusuario' => $data["row"][0]->idusuario);

                $this->_model->update_nombres($datausuario, $where);
                
                $_SESSION['nombre'] = $nombre;

                $data["row"] = $this->_model->get_datos($_SESSION['id']);

                $data['aviso'] = "Datos actualizados correctamente";
            }

        } elseif (!is_null(filter_input(INPUT_POST, 'editsubmitpass'))) {
            $password = filter_input(INPUT_POST, 'password');

            if ($password == '') {
                $error[] = 'Campos vacios';
            }

            if (!$error) {

                $datausuario = array(
                    'password' => Password::make($password)
                );

                $where = array('idusuario' => $data["row"][0]->idusuario);

                $this->_model->update_password($datausuario, $where);

                $data['aviso'] = "Contraseña actualizada correctamente";
            }
        }

        View::render('perfil/configuracion', $data, $error);
        View::rendertemplate('footer', $data);
    }

}
