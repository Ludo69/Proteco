<?php

namespace models;

class Cursos extends \core\model {

    public function getClases($idPaquete) {
        return $this->_db->select("SELECT preciounam.precioCurso AS precioUnam, precioforaneo.precioCurso AS precioForaneo, precioexterno.precioCurso AS precioExterno, paquete.nombre AS pnombre, paquete.descripcion AS pdescrip, clase.idclase AS clave, clase.cupo AS cupo, curso.requisitos AS requisitos, curso.nombre AS curso, curso.material AS material, curso.temario AS temario, curso.imagen AS imagen, curso.descripcion AS descrip, lugar.nombre AS lugar, lugar.ubicacion AS ubica, horario.incio AS inicio, horario.final AS final, clase.fecha AS fecha, clase.fechaFin AS fin FROM  clase, curso, lugar, horario, paquete, preciounam, precioexterno, precioforaneo WHERE FK_curso = idcurso AND FK_lugar = idlugar AND FK_horario = idhorario AND FK_paquete = idpaquete AND FK_precioUNAM = idprecioUNAM AND FK_precioExterno = idprecioExterno AND FK_precioForaneo= idprecioForaneo AND FK_paquete = :idPaquete AND clase.visible = 1 ORDER BY clase.idclase", array(":idPaquete" => $idPaquete));
    }

    public function getPaquetes() {
        return $this->_db->select("SELECT * FROM paquete ORDER BY nombre");
    }

    public function getClase($idClase) {
        return $this->_db->select("SELECT curso.imagen AS imagen, preciounam.precioCurso AS precioUnam, precioforaneo.precioCurso AS precioForaneo, precioexterno.precioCurso AS precioExterno, clase.idclase AS clave, curso.nombre AS curso, horario.incio AS inicio, horario.final AS final, clase.fecha AS fecha, clase.fechaFin AS fin FROM clase, curso, lugar, horario, paquete, preciounam, precioexterno, precioforaneo WHERE FK_curso = idcurso AND FK_lugar = idlugar AND FK_horario = idhorario AND FK_precioUNAM = idprecioUNAM AND FK_precioExterno = idprecioExterno AND FK_precioForaneo= idprecioForaneo AND FK_paquete = idpaquete AND clase.idclase = :idClase", array(":idClase" => $idClase));
    }

    public function getMaterial() {
        return $this->_db->select("SELECT * FROM material ORDER BY nombre");
    }

    public function get_semestre() {
        $data = $this->_db->select("SELECT actual FROM semestre ORDER BY idsemestre DESC");
        return $data[0]->actual;
    }

}
