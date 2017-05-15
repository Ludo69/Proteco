<?php

namespace models;

class Bienvenido extends \core\model {

    public function getPaquetes() {
        return $this->_db->select("SELECT * FROM paquete ORDER BY nombre");
    }

    public function getposts($limit) {
        return $this->_db->select("SELECT * FROM noticia, usuario WHERE FK_becario = idusuario AND estado = 1 ORDER BY fechaHora DESC " . $limit);
    }

    public function getpoststotal() {
        return $this->_db->select("SELECT idnoticia FROM noticia WHERE estado = 1");
    }

    public function getpost($slug) {
        return $this->_db->select("SELECT * FROM noticia, usuario WHERE slug = :slug AND FK_becario = idusuario AND estado = 1 ORDER BY fechaHora DESC", array(':slug' => $slug));
    }

    public function getMaterial() {
        return $this->_db->select("SELECT * FROM material ORDER BY nombre");
    }

}
