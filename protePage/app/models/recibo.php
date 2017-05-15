<?php

namespace models;

class Recibo extends \core\model {

    public function get_semestre() {
        $data = $this->_db->select("SELECT actual FROM semestre ORDER BY idsemestre DESC");
        return $data[0]->actual;
    }

    public function get_usuario($folio) {
        return $this->_db->select("SELECT intersemestral.folio AS folio, intersemestral.cuota AS cuota, intersemestral.semestre AS semestre, usuario.apellidoP AS apellidoP, usuario.apellidoM AS apellidoM, usuario.nombres AS nombres, usuario.correo AS correo, usuario.tipo AS tipo FROM intersemestral, usuario WHERE intersemestral.folio = :folio AND intersemestral.FK_usuario = usuario.idusuario",array(":folio" => $folio));
    }

    public function get_usuario_unam($id) {
        return $this->_db->select("SELECT noCuenta FROM unam WHERE FK_usuario = :id",array(":id" => $id));
    }

    public function get_usuario_externo($id) {
        return $this->_db->select("SELECT RFC FROM foraneo WHERE FK_usuario = :id",array(":id" => $id));
    }

    public function get_usuario_general($id) {
        return $this->_db->select("SELECT RFC FROM externo WHERE FK_usuario = :id",array(":id" => $id));
    }

    public function get_cursos($folio) {
        return $this->_db->select("SELECT curso.nombre AS nombre,  clase.FK_horario AS horario, clase.fecha AS fecha FROM  miscursos,  clase, curso WHERE miscursos.FK_clase = clase.idclase AND clase.FK_curso = curso.idcurso AND miscursos.FK_folio = :folio ORDER BY clase.FK_horario",array(":folio" => $folio));
    }

    public function get_user($email, $id) {
        return $this->_db->select("SELECT usuario.nombres AS nombres, usuario.apellidoP AS apellidoP, usuario.apellidoM AS apellidoM, usuario.correo AS correo, usuario.tipo AS tipo FROM usuario WHERE usuario.correo = :email AND usuario.idusuario = :id",array(":email" => $email, ":id" => $id));
    }

    public function getMaterial($id) {
        return $this->_db->select("SELECT * FROM material WHERE material.idmaterial = :id",array(":id" => $id));
    }
}
