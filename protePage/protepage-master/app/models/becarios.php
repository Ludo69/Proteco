<?php

namespace models;

class Becarios extends \core\model {
	public function get_becarios() {
        return $this->_db->select("SELECT * from usuario, unam, becario WHERE usuario.idusuario = unam.FK_usuario AND unam.idUNAM = becario.FK_UNAM ORDER BY becario.FK_generacion");    
    }

    public function insert_asesoria($data) {
        return $this->_db->insert('asesoria',$data);    
    }
}