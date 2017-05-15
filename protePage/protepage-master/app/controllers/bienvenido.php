<?php

namespace controllers;

use \core\view as View,
    \helpers\paginator as Paginator,
    \helpers\url as Url,
    \core\router as Router;

class Bienvenido extends \core\controller {

    private $_model;

    public function __construct() {
        parent::__construct();
        $this->language->load('bienvenido');
        $this->_model = new \models\bienvenido();
    }

    public function index() {
        $data['title'] = $this->language->get('bienvenido_titulo');
        $data['paquetesRows'] = $this->_model->getPaquetes();
        $data['materialRows'] = $this->_model->getMaterial();

        $pages = new Paginator('4', 'pag');
        $pages->set_total(count($this->_model->getpoststotal()));
        $data['posts'] = $this->_model->getposts($pages->get_limit());
        $data['page_links'] = $pages->page_links();

        View::rendertemplate('header', $data);
        View::render('bienvenido/bienvenido', $data);
        View::rendertemplate('footer', $data);
    }

    public function post($slug) {
        $data['post'] = $this->_model->getpost($slug);
        if ($data['post'][0]->slug == $slug) {
            $data['title'] = $data['post'][0]->titulo;
            View::rendertemplate('header', $data);
            View::render('bienvenido/post', $data);
            View::rendertemplate('footer', $data);
        } else {
            header("HTTP/1.0 404 Not Found");
            $data['title'] = '404';
            $data['error'] = 'No routes found.';
            View::rendertemplate('header', $data);
            View::render('error/404', $data);
            View::rendertemplate('footer', $data);
        }
    }

    public function nosotros() {
        $data['title'] = $this->language->get('nosotros_titulo');
        View::rendertemplate('header', $data);
        View::render('bienvenido/nosotros', $data);
        View::rendertemplate('footer', $data);
    }

    public function ayuda() {
        $data['title'] = $this->language->get('ayuda_titulo');
        View::rendertemplate('header', $data);
        View::render('bienvenido/ayuda', $data);
        View::rendertemplate('footer', $data);
    }

    public function contacto() {
        $data['title'] = $this->language->get('contacto_titulo');
        View::rendertemplate('header', $data);
        View::render('bienvenido/contacto', $data);
        View::rendertemplate('footer', $data);
    }

    public function unete() {
        $data['title'] = $this->language->get('unete_titulo');
        View::rendertemplate('header', $data);
        View::render('bienvenido/unete', $data);
        View::rendertemplate('footer', $data);
    }

}
