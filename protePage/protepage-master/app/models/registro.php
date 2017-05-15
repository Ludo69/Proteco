<?php

namespace models;

class Registro extends \core\model {

    public function __construct() {
        parent::__construct();
    }

    public function get_planteles() {
        return $this->_db->select("SELECT * FROM plantel");
    }

    public function get_carreras($id) {
        return $this->_db->select("SELECT carrera.idcarrera AS id, carrera.nombre AS carrera, plantel.nombre AS plantel FROM  plantelcarrera , plantel, carrera WHERE plantel.idplantel = plantelcarrera.FK_plantel AND plantelcarrera.FK_carrera = carrera.idcarrera AND plantel.idplantel = :id", array(':id' => $id));
    }
    
    public function get_foraneas() {
        return $this->_db->select("SELECT * FROM escuelaforanea");
    }

    public function get_correo($correo) {
        return $this->_db->select("SELECT idusuario FROM usuario WHERE correo = :correo",array(':correo' => $correo));
    }

    public function get_usuario($correo){
        return $this->_db->select("SELECT idusuario, nombres, correo FROM usuario WHERE correo = :correo",array(':correo' => $correo));
    }

    public function insert_usuario($data) {
        $this->_db->insert('usuario', $data);
    }

    public function insert_unam($data) {
        $this->_db->insert('unam', $data);
    }
    
    public function insert_foraneo($data) {
        $this->_db->insert('foraneo', $data);
    }
    
    public function insert_externo($data) {
        $this->_db->insert('externo', $data);
    }

    public function update_password($data, $where) {
        $this->_db->update('usuario', $data, $where);
    }

    public function get_usuario_password() {
        return $this->_db->select("SELECT idusuario, correo, password FROM usuario");
    }

}
