<?php

namespace controllers;

use \core\view as View,
    \helpers\session as Session,
    \helpers\password as Password,
    \helpers\url as Url;

class Auth extends \core\controller {

    private $_model;

    public function __construct() {
        parent::__construct();
        $this->language->load('auth');
        $this->_model = new \models\auth();
    }

    public function login() {
        $data['title'] = $this->language->get('auth_titulo');

        if (Session::get('loggedin') && Session::get('id')) {
            Url::redirect();
        }

        if (!is_null(filter_input(INPUT_POST, 'submit'))) {
            $correo = filter_input(INPUT_POST, 'correo');
            $password = filter_input(INPUT_POST, 'password');
            $id = 1;
            $tipo = 1;
            $FK_rol = 0;
            $semestre = $this->_model->get_semestre();

            if ($correo == '') {
                $error[] = "Campos vacios";
            }

            if (Password::verify($password, $this->_model->getHash($correo)) == false) {
                $error[] = "Correo o password incorrecto";
            }

            if (!$error) {

                $usuarioRows = $this->_model->getUsuario($correo);

                if ($usuarioRows) {

                    foreach ($usuarioRows as $row) {
                        $id = $row->idusuario;
                        $nombre = utf8_decode($row->nombres);
                        $tipo = $row->tipo;
                        $FK_rol = $row->FK_rol;
                    }

                    Session::set('loggedin', true);
                    Session::set('email', $correo);
                    Session::set('nombre', $nombre);
                    Session::set('id', $id);
                    Session::set('tipo', $tipo);
                    Session::set('rol', $FK_rol);

                    $interRows = $this->_model->getIntersemestral($id, $semestre);

                    if ($interRows) {

                        $folio = 0;

                        foreach ($interRows as $row) {
                            $folio = $row->folio;
                        }

                        Session::set('folio', $folio);

                        $itemArray = $this->_model->getMisCursos($folio);
                        $itemNew = array();

                        foreach ($itemArray as $row) {
                            $itemNew += array($row->clave => array("imagen" => $row->curso, "nombre" => $row->curso, "fecha" => date("d-m-Y", strtotime($row->fecha)) . " al " . date("d-m-Y", strtotime($row->fin)), "horario" => date("H:i", strtotime($row->inicio)) . " - " . date("H:i", strtotime($row->final))));
                        }

                        $_SESSION['cart_item'] = $itemNew;
                    }

                    Url::redirect();
                }
            }
        }

        View::rendertemplate('header', $data);
        View::render('auth/login', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function recupera() {
        $data['title'] = "Recuperar contraseña";

        if (Session::get('loggedin') && Session::get('id')) {
            Url::redirect();
        }

        if (!is_null(filter_input(INPUT_POST, 'submit'))) {
            $correo = filter_input(INPUT_POST, 'correo');

            if ($correo == '') {
                $error[] = "Campos vacios";
            } elseif (!filter_var($correo, FILTER_VALIDATE_EMAIL)) {
                $error[] = "Esta dirección de correo no es válida";
            } elseif(!$this->_model->getCorreo($correo)[0]->correo) {
                $error[] = "No existe la direccion de correo proporcionada en nuestra base de datos";
            }

            if (!$error) {

                $password = substr(str_shuffle('abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789') , 0 , 10 );

                $datausuario = array(
                    'password' => Password::make($password)
                );

                $where = array('idusuario' => $this->_model->getCorreo($correo)[0]->idusuario);

                $this->_model->update_password($datausuario, $where);

                $mail = new \helpers\phpmailer\mail();
                $mail->CharSet = 'UTF-8';
                $mail->setFrom('cursosproteco@gmail.com');
                $mail->addAddress($correo);
                $mail->subject('Contraseña temporal CURSOS PROTECO');
                $firma = "<blockquote><b>Programa de Tecnología en Cómputo | PROTECO</b><br>Coordinación de Cursos Intersemestrales | Coord. Alejandro Zepeda<br>Edificio Q \"Luis G. Valdés Vallejo\" 2do piso<br>Facultad de Ingeniería<br>Ciudad Universitaria<br>Universidad Nacional Autónoma de México<br>Sitio web: <a href='http://proteco.mx'>proteco.fi-b.unam.mx</a></blockquote>";
                $mail->body("Buen día<br><br>Le informamos que esta contraseña es temporal y es generada aleatoriamente, usted debe cambiarla en la siguiente sección <i>Perfil -> Configuración</i><br><br><h3>Contraseña temporal: </h3>" . $password . "<br><br><br>Saludos :)<br><br>" . $firma);
                
                if(!$mail->send()) {
                    $error[] = 'El correo no pudo ser enviado' . $mail->ErrorInfo;
                } else {
                    $data['aviso'] = "Se ha enviado la nueva contraseña al correo proporcionado";
                }
               
                
            }
        }

        View::rendertemplate('header', $data);
        View::render('auth/recupera', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function logout() {
        Session::destroy();
        Url::redirect();
    }

}
