<?php

namespace controllers;

use \core\view as View,
    \helpers\url as Url,
    \helpers\session as Session,
    \helpers\password as Password,
    \helpers\data as Data;

class Registro extends \core\controller {

    private $_registro;

    public function __construct() {
        parent::__construct();

        if (Session::get('loggedin') && Session::get('id')) {
            Url::redirect();
        }

        $this->language->load('registro');
        $this->_registro = new \models\registro();
    }

    public function index() {

        $data['title'] = $this->language->get('registro_titulo');
        View::rendertemplate('header', $data);

        if (!is_null(filter_input(INPUT_POST, 'registroUNAM')) && filter_input(INPUT_POST, 'registroUNAM') == 1 && !is_null(filter_input(INPUT_POST, 'tipoUsuario')) && filter_input(INPUT_POST, 'tipoUsuario') == 1) {

            $nombre = filter_input(INPUT_POST, 'nombre');
            $apaterno = filter_input(INPUT_POST, 'apaterno');
            $amaterno = filter_input(INPUT_POST, 'amaterno');
            $email = filter_input(INPUT_POST, 'email');
            $password = filter_input(INPUT_POST, 'password');
            $captcha = filter_input(INPUT_POST, 'captcha');
            $tipoUsuario = filter_input(INPUT_POST, 'tipoUsuario');
            $cuenta = filter_input(INPUT_POST, 'cuenta');
            $plantel = filter_input(INPUT_POST, 'plantel');
            $carrera = filter_input(INPUT_POST, 'carrera');
            $rol = 1;
            $id = 1;

            if ($nombre == '' || !isset($nombre) || $apaterno == '' || !isset($apaterno) || $amaterno == '' || !isset($amaterno) || $email == '' || !isset($email) || $password == '' || !isset($password) || $captcha == '' || !isset($captcha) || $password == '' || !isset($password) || $cuenta == '' || !isset($cuenta) || $plantel == '' || !isset($plantel) || $carrera == '' || !isset($carrera)) {
                $error[] = "Campos vacios";
            }

            if (!$error) {

                $usuariodata = array(
                    'apellidoP' => Data::ucw($apaterno),
                    'apellidoM' => Data::ucw($amaterno),
                    'nombres' => Data::ucw($nombre),
                    'correo' => Data::slw($email),
                    'password' => Password::make($password),
                    'tipo' => $tipoUsuario,
                    'FK_rol' => $rol
                );

                $this->_registro->insert_usuario($usuariodata);

                $usuarioRows = $this->_registro->get_usuario($email);

                if ($usuarioRows) {

                    foreach ($usuarioRows as $row) {
                        $id = $row->idusuario;
                        $nombre = $row->nombres;
                        $email = $row->correo;
                    }

                    $unamdata = array(
                        'noCuenta' => $cuenta,
                        'FK_plantel' => $plantel,
                        'FK_carrera' => $carrera,
                        'FK_usuario' => $id
                    );

                    $this->_registro->insert_unam($unamdata);

                    Session::set('loggedin', true);
                    Session::set('email', $email);
                    Session::set('nombre', $nombre);
                    Session::set('id', $id);
                    Session::set('tipo', $tipoUsuario);
                    Session::set('rol', $rol);

                    Url::redirect('perfil');
                }
            } else {
                $data['plantelesRows'] = $this->_registro->get_planteles();
                $data['foraneaRows'] = $this->_registro->get_foraneas();
                View::render('registro/registro', $data, $error);
            }
        } else if (!is_null(filter_input(INPUT_POST, 'registroForaneo')) && filter_input(INPUT_POST, 'registroForaneo') == 2 && !is_null(filter_input(INPUT_POST, 'tipoUsuario')) && filter_input(INPUT_POST, 'tipoUsuario') == 2) {

            $nombre = filter_input(INPUT_POST, 'nombre');
            $apaterno = filter_input(INPUT_POST, 'apaterno');
            $amaterno = filter_input(INPUT_POST, 'amaterno');
            $email = filter_input(INPUT_POST, 'email');
            $password = filter_input(INPUT_POST, 'password');
            $captcha = filter_input(INPUT_POST, 'captcha');
            $tipoUsuario = filter_input(INPUT_POST, 'tipoUsuario');
            $rfc = filter_input(INPUT_POST, 'rfc1');
            $foranea = filter_input(INPUT_POST, 'foranea');
            $rol = 1;
            $id = 1;

            if ($nombre == '' || !isset($nombre) || $apaterno == '' || !isset($apaterno) || $amaterno == '' || !isset($amaterno) || $email == '' || !isset($email) || $password == '' || !isset($password) || $captcha == '' || !isset($captcha) || $password == '' || !isset($password) || $rfc == '' || !isset($rfc) || $foranea == '' || !isset($foranea)) {
                $error[] = "Campos vacios";
            }

            if (!$error) {

                $usuariodata = array(
                    'apellidoP' => Data::ucw($apaterno),
                    'apellidoM' => Data::ucw($amaterno),
                    'nombres' => Data::ucw($nombre),
                    'correo' => Data::slw($email),
                    'password' => Password::make($password),
                    'tipo' => $tipoUsuario,
                    'FK_rol' => $rol
                );

                $this->_registro->insert_usuario($usuariodata);

                $usuarioRows = $this->_registro->get_usuario($email);

                if ($usuarioRows) {

                    foreach ($usuarioRows as $row) {
                        $id = $row->idusuario;
                        $nombre = $row->nombres;
                        $email = $row->correo;
                    }

                    $foraneodata = array(
                        'RFC' => Data::sup($rfc),
                        'FK_escuelaForanea' => $foranea,
                        'FK_usuario' => $id
                    );

                    $this->_registro->insert_foraneo($foraneodata);

                    Session::set('loggedin', true);
                    Session::set('email', $email);
                    Session::set('nombre', $nombre);
                    Session::set('id', $id);
                    Session::set('tipo', $tipoUsuario);
                    Session::set('rol', $rol);

                    Url::redirect('perfil');
                }
            } else {
                $data['plantelesRows'] = $this->_registro->get_planteles();
                $data['foraneaRows'] = $this->_registro->get_foraneas();
                View::render('registro/registro', $data, $error);
            }
        } else if (!is_null(filter_input(INPUT_POST, 'registroGeneral')) && filter_input(INPUT_POST, 'registroGeneral') == 3 && !is_null(filter_input(INPUT_POST, 'tipoUsuario')) && filter_input(INPUT_POST, 'tipoUsuario') == 3) {

            $nombre = filter_input(INPUT_POST, 'nombre');
            $apaterno = filter_input(INPUT_POST, 'apaterno');
            $amaterno = filter_input(INPUT_POST, 'amaterno');
            $email = filter_input(INPUT_POST, 'email');
            $password = filter_input(INPUT_POST, 'password');
            $captcha = filter_input(INPUT_POST, 'captcha');
            $tipoUsuario = filter_input(INPUT_POST, 'tipoUsuario');
            $rfc = filter_input(INPUT_POST, 'rfc2');
            $rol = 1;
            $id = 1;

            if ($nombre == '' || !isset($nombre) || $apaterno == '' || !isset($apaterno) || $amaterno == '' || !isset($amaterno) || $email == '' || !isset($email) || $password == '' || !isset($password) || $captcha == '' || !isset($captcha) || $password == '' || !isset($password) || $rfc == '' || !isset($rfc)) {
                $error[] = "Campos vacios";
            }

            if (!$error) {

                $usuariodata = array(
                    'apellidoP' => Data::ucw($apaterno),
                    'apellidoM' => Data::ucw($amaterno),
                    'nombres' => Data::ucw($nombre),
                    'correo' => Data::slw($email),
                    'password' => Password::make($password),
                    'tipo' => $tipoUsuario,
                    'FK_rol' => $rol
                );

                $this->_registro->insert_usuario($usuariodata);

                $usuarioRows = $this->_registro->get_usuario($email);

                if ($usuarioRows) {

                    foreach ($usuarioRows as $row) {
                        $id = $row->idusuario;
                        $nombre = $row->nombres;
                        $email = $row->correo;
                    }

                    $externodata = array(
                        'RFC' => Data::sup($rfc),
                        'FK_usuario' => $id
                    );

                    $this->_registro->insert_externo($externodata);

                    Session::set('loggedin', true);
                    Session::set('email', $email);
                    Session::set('nombre', $nombre);
                    Session::set('id', $id);
                    Session::set('tipo', $tipoUsuario);
                    Session::set('rol', $rol);

                    Url::redirect('perfil');
                }
            } else {
                $data['plantelesRows'] = $this->_registro->get_planteles();
                $data['foraneaRows'] = $this->_registro->get_foraneas();
                View::render('registro/registro', $data, $error);
            }
        } else {
            $data['plantelesRows'] = $this->_registro->get_planteles();
            $data['foraneaRows'] = $this->_registro->get_foraneas();
            View::render('registro/registro', $data, $error);
        }

        View::rendertemplate('footer', $data);
    }

    public function carreras() {
        $carrerasP = $this->_registro->get_carreras(filter_input(INPUT_POST, 'id'));
        $carreras = "<option value='0'>" . $this->language->get('selec') . "</option>";
        if ($carrerasP) {
            foreach ($carrerasP as $row) {
                $carreras .= "<option value='" . $row->id . "'>" . $row->carrera . "</option>";
            }
        }
        echo $carreras;
    }

    public function correo() {
        $correo = $this->_registro->get_correo(filter_input(INPUT_POST, 'email'));
        foreach ($correo as $row) {
            if ($row->idusuario) {
                echo 1;
            }
        }
    }

    public function hashPassword() {
        $usuarios = $this->_registro->get_usuario_password();

        $inferior = 1 - 1;
        $superior = -1 + 1;

        foreach ($usuarios as $row) {

            if ($row->idusuario <= $inferior) {
                continue;
            }

            if ($row->idusuario < $superior) {
                echo "<b>id:</b> " . $row->idusuario . " <b>correo: </b>" . $row->correo . "<b> password: </b>" . $row->password;
                $edit = array('password' => Password::make($row->password));
                $where = array('idusuario' => $row->idusuario);
                $this->_registro->update_password($edit, $where);
            }

            if ($row->idusuario == $superior) {
                break;
            }
        }
    }

}
