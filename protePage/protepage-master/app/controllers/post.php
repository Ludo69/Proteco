<?php

namespace controllers;

use \helpers\url as Url,
    \helpers\session as Session,
    \core\view as View;

class Post extends \core\controller {

    private $_model;

    public function __construct() {
        parent::__construct();

        if (!Session::get('loggedin') && !Session::get('id')) {
            Url::redirect();
        }

        if ($_SESSION['rol'] != '4') {
            Url::redirect();
        }

        $this->_model = new \models\post();
    }

    public function index() {
        $data['title'] = "Posts";
        $data['posts'] = $this->_model->getposts();

        View::rendertemplate('header', $data);
        View::render('post/post', $data);
        View::rendertemplate('footer', $data);
    }

    public function add() {
        $data['title'] = "Agregar post";
        View::rendertemplate('header', $data);

        if (!is_null(filter_input(INPUT_POST, 'submit'))) {

            $postTitle = filter_input(INPUT_POST, 'postTitle');
            $postDesc = filter_input(INPUT_POST, 'postDesc');
            $postCont = filter_input(INPUT_POST, 'postCont');
            $FK_becario = $_SESSION['id'];

            if ($postTitle == '') {
                $error[] = 'Campos vacios';
            }

            if ($postDesc == '') {
                $error[] = 'Campos vacios';
            }

            if ($postCont == '') {
                $error[] = 'Campos vacios';
            }

            if (!$error) {

                $slug = Url::generateSafeSlug($postTitle);

                $imageData = array(
                    'titulo' => $postTitle,
                    'descripcion' => $postDesc,
                    'contenido' => $postCont,
                    'slug' => $slug,
                    'FK_becario' => $FK_becario,
                    'estado' => 0,
                    'imagen' => ''
                );

                if ($_FILES['image']['size'] > 0) {
                    $name = 'images/' . $_FILES['image']['name'];
                    $tmp_name = $_FILES['image']['tmp_name'];
                    move_uploaded_file($tmp_name, $name);
                    $imageData['imagen'] = $name;
                }
                
                $this->_model->insert_post($imageData);

                Session::set('aviso', "Post mandado a revision correctamente");
                Url::redirect('verPost');
            }
        }

        View::render('post/addPost', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function edit($id) {
        $data['title'] = "Editar post";
        View::rendertemplate('header', $data);

        $data['row'] = $this->_model->getpost($id);

        if (!is_null(filter_input(INPUT_POST, 'submit'))) {

            $postTitle = filter_input(INPUT_POST, 'postTitle');
            $postDesc = filter_input(INPUT_POST, 'postDesc');
            $postCont = filter_input(INPUT_POST, 'postCont');
            $FK_becario = $_SESSION['id'];

            if ($postTitle == '') {
                $error[] = 'Campos vacios';
            }

            if ($postDesc == '') {
                $error[] = 'Campos vacios';
            }

            if ($postCont == '') {
                $error[] = 'Campos vacios';
            }

            if (!$error) {

                $slug = Url::generateSafeSlug($postTitle);

                $imageData = array(
                    'titulo' => $postTitle,
                    'descripcion' => $postDesc,
                    'contenido' => $postCont,
                    'slug' => $slug,
                    'FK_becario' => $FK_becario,
                    'estado' => 0
                );

                if ($_FILES['image']['size'] > 0) {
                    $name = 'images/' . $_FILES['image']['name'];
                    $tmp_name = $_FILES['image']['tmp_name'];
                    move_uploaded_file($tmp_name, $name);
                    $imageData['imagen'] = $name;
                }
                
                $where = array('idnoticia' => $id);
                
                $this->_model->update_post($imageData, $where);

                Session::set('aviso', "Post actualizado correctamente");
                Url::redirect('verPost');
            }
        }

        View::render('post/editPost', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function delete($id) {
        $this->_model->delete_post(array('idnoticia' => $id));
        Session::set('aviso', "Post eliminado correctamente");
        Url::redirect('verPost');
    }

    public function update_estado($id) {
        $estadoActual = $this->_model->getpost($id);
        // 0 es no aprobado
        // 1 es aprobado
        $dataEstado = array();
        
        if($estadoActual[0]->estado == 0) {
            $dataEstado = array('estado' => 1);
        } else {
            $dataEstado = array('estado' => 0);
        }

        $where = array('idnoticia' => $id);

        $this->_model->update_post($dataEstado, $where);
        Session::set('aviso', "Estado actualizado correctamente");
        Url::redirect('verPost');
    }

}
