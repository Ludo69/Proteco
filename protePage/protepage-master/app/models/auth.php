<?php

namespace models;

class Auth extends \core\model {

    public function getHash($correo) {
        $data = $this->_db->select("SELECT password FROM usuario WHERE correo = :correo", array(':correo' => $correo));
        return $data[0]->password;
    }

    public function getUsuario($correo) {
        return $this->_db->select("SELECT idusuario, nombres, tipo, FK_rol FROM usuario WHERE correo = :correo", array(':correo' => $correo));
    }

    public function get_semestre() {
        $data = $this->_db->select("SELECT actual FROM semestre ORDER BY idsemestre DESC");
        return $data[0]->actual;
    }

    public function getIntersemestral($idusuario, $semestre) {
        return $this->_db->select("SELECT * FROM intersemestral WHERE FK_usuario = :idusuario AND semestre = :semestre", array(":idusuario" => $idusuario, ":semestre" => $semestre));
    }

    public function getMisCursos($folio) {
        return $this->_db->select("SELECT curso.imagen AS imagen, clase.idclase AS clave, curso.nombre AS curso, horario.incio AS inicio, horario.final AS final, clase.fecha AS fecha, clase.fechaFin AS fin FROM  miscursos, clase, curso, horario, lugar ,intersemestral WHERE miscursos.FK_clase = clase.idclase AND clase.FK_curso = curso.idcurso AND clase.FK_horario = horario.idhorario AND clase.FK_lugar = lugar.idlugar AND miscursos.FK_folio = intersemestral.folio AND miscursos.FK_folio= :folio", array(":folio" => $folio));
    }

    public function getCorreo($correo) {
        return $this->_db->select("SELECT correo, idusuario FROM usuario WHERE correo = :correo",array(":correo" => $correo));
    }

    public function update_password($data, $where) {
        $this->_db->update('usuario', $data, $where);
    }

}
