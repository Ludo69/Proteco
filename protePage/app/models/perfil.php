<?php

namespace models;

class Perfil extends \core\model {

    public function insert_intersemestral($data) {
        $this->_db->insert('intersemestral', $data);
    }

    public function insert_miscursos($data) {
        $this->_db->insert('miscursos', $data);
    }

    public function get_folio($cuota, $estado, $usuario, $tipo, $semestre) {
        $data = $this->_db->select("SELECT folio FROM intersemestral WHERE cuota = :cuota AND FK_estado = :estado AND FK_usuario = :fk_usuario AND tipo = :tipo AND semestre = :semestre", array(":cuota" => $cuota, ":estado" => $estado, "fk_usuario" => $usuario, ":tipo" => $tipo, ":semestre" => $semestre));
        return $data[0]->folio;
    }

    public function get_semestre() {
        $data = $this->_db->select("SELECT actual FROM semestre ORDER BY idsemestre DESC");
        return $data[0]->actual;
    }

    public function getClase($idClase) {
        return $this->_db->select("SELECT curso.imagen AS imagen, preciounam.precioCurso AS precioUnam, precioforaneo.precioCurso AS precioForaneo, precioexterno.precioCurso AS precioExterno, clase.idclase AS clave, curso.nombre AS curso, horario.incio AS inicio, horario.final AS final, clase.fecha AS fecha, clase.fechaFin AS fin FROM clase, curso, lugar, horario, paquete, preciounam, precioexterno, precioforaneo WHERE FK_curso = idcurso AND FK_lugar = idlugar AND FK_horario = idhorario AND FK_precioUNAM = idprecioUNAM AND FK_precioExterno = idprecioExterno AND FK_precioForaneo= idprecioForaneo AND FK_paquete = idpaquete AND clase.idclase = :idClase", array(":idClase" => $idClase));
    }

    public function get_estatus($id, $semestre) {
        return $this->_db->select("SELECT folio, FK_estado, semestre FROM intersemestral, usuario WHERE intersemestral.FK_usuario = usuario.idusuario AND intersemestral.semestre = :semestre AND intersemestral.FK_usuario = :id", array(":id" => $id, ":semestre" => $semestre));
    }

    public function get_misCursos($folio) {
        return $this->_db->select("SELECT clase.fecha AS fecha, clase.fechafin AS fechafin, curso.nombre AS nombre, curso.imagen AS imagen, lugar.Nombre AS lugar, lugar.Ubicacion AS ubica, horario.incio AS inicio, horario.final AS final FROM  miscursos,  clase, curso, horario, lugar WHERE miscursos.FK_clase = clase.idclase AND clase.FK_curso = curso.idcurso AND clase.FK_horario = horario.idhorario AND clase.FK_lugar = lugar.idlugar AND miscursos.FK_folio = :folio", array(":folio" => $folio));
    }

    public function get_datosInter($id, $semestre) {
        return $this->_db->select("SELECT folio, FK_estado, semestre FROM intersemestral, usuario WHERE intersemestral.FK_usuario = usuario.idusuario AND intersemestral.semestre = :semestre AND intersemestral.FK_usuario = :id", array(":id" => $id, ":semestre" => $semestre));
    }

    public function get_datos($id) {
        return $this->_db->select("SELECT * FROM usuario WHERE usuario.idusuario = :id", array(":id" => $id));
    }

    public function get_unam($id) {
        return $this->_db->select("SELECT unam.noCuenta, plantel.nombre AS plantel, carrera.nombre AS carrera FROM unam, plantel, carrera WHERE FK_plantel = idplantel AND FK_carrera = idcarrera AND FK_usuario = :id", array(":id" => $id));
    }

    public function get_externo($id) {
        return $this->_db->select("SELECT * FROM externo WHERE FK_usuario = :id", array(":id" => $id));
    }

    public function get_foraneo($id) {
        return $this->_db->select("SELECT * FROM foraneo, escuelaforanea WHERE FK_usuario = :id AND FK_escuelaForanea = idescuelaForanea", array(":id" => $id));
    }

    public function delete_intersemestral($where) {
        $this->_db->delete('intersemestral', $where);
    }

    public function delete_mis_cursos($where, $limit) {
        $this->_db->delete('miscursos', $where, $limit);
    }

    public function update_password($data, $where) {
        $this->_db->update('usuario', $data, $where);
    }

    public function update_nombres($data, $where) {
        $this->_db->update('usuario', $data, $where);
    }

}
