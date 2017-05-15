<?php

namespace models;

class Administracion extends \core\model {

    public function get_semestre() {
        $data = $this->_db->select("SELECT actual FROM semestre ORDER BY idsemestre DESC");
        return $data[0]->actual;
    }

    public function get_datos_semestre() {
        $data = $this->_db->select("SELECT * FROM semestre ORDER BY idsemestre DESC");
        return $data[0];
    }

    public function get_semestres() {
        return $this->_db->select("SELECT * FROM semestre");
    }

    public function get_intersemestral($folio) {
        return $this->_db->select("SELECT intersemestral.folio, intersemestral.cuota, intersemestral.FK_estado AS estado, intersemestral.semestre AS semestre, usuario.nombres AS nombre, usuario.apellidoP, usuario.apellidoM, usuario.correo FROM intersemestral, usuario WHERE intersemestral.FK_usuario = usuario.idusuario AND intersemestral.folio = :folio", array(":folio" => $folio));
    }

    public function get_miscursos($folio) {
        return $this->_db->select("SELECT curso.nombre AS nombre, clase.idclase as idclase, clase.cupo AS cupo FROM miscursos, intersemestral, clase, curso WHERE miscursos.FK_folio = intersemestral.folio AND clase.FK_curso = curso.idcurso AND miscursos.FK_clase = clase.idclase AND intersemestral.folio = :folio", array(":folio" => $folio));
    }

    public function get_ticket($ticket) {
        return $this->_db->select("SELECT ticket FROM interpagado WHERE ticket = :ticket", array(':ticket' => $ticket));
    }

    public function get_pagoparcial($folio) {
        return $this->_db->select("SELECT idinterPagado, FK_folio, ticket, cantidad FROM interpagado WHERE FK_folio = :folio", array(':folio' => $folio));
    }

    public function get_preciounam() {
        return $this->_db->select("SELECT * FROM preciounam");
    }

    public function get_precioexterno() {
        return $this->_db->select("SELECT * FROM precioexterno");
    }

    public function get_precioforaneo() {
        return $this->_db->select("SELECT * FROM precioforaneo");
    }

    public function get_becadores() {
        return $this->_db->select("SELECT idbecador, nombre FROM becador");
    }

    public function get_becador($id) {
        return $this->_db->select("SELECT nombre FROM becador WHERE idbecador = :id", array(":id" => $id));
    }

    public function get_cursos() {
        return $this->_db->select("SELECT * FROM curso");
    }

    public function get_id_curso($nombre) {
        return $this->_db->select("SELECT idcurso FROM curso WHERE nombre = '".$nombre."'");
    }

    public function get_id_cursos() {
        return $this->_db->select("SELECT idcurso FROM curso");
    }

    public function get_paquetes() {
        return $this->_db->select("SELECT * FROM paquete");
    }

    public function get_lugares() {
        return $this->_db->select("SELECT * FROM lugar");
    }

    public function get_horarios() {
        return $this->_db->select("SELECT * FROM horario");
    }

    public function get_clases($semestre) {
        $sql = "SELECT clase.idclase AS idclase, curso.nombre AS curso, curso.idcurso AS idcurso, ";
        $sql .= "paquete.nombre AS nombrepaquete, clase.cupo AS cupo, clase.cupoTotal AS total, ";
        $sql .= "horario.incio AS horarioInicio, horario.final AS horarioFinal, horario.idhorario AS idhorario, ";
        $sql .= "clase.fecha AS fechaInicio, clase.fechaFin AS fechaFin, ";
        $sql .= "clase.visible AS visible,";
        $sql .= "lugar.idlugar AS idlugar, lugar.Nombre AS lugar, lugar.ubicacion AS ubicacion, ";
        $sql .= "paquete.idpaquete AS idpaquete ";
        $sql .= "FROM clase, lugar, horario, curso, paquete ";
        $sql .= "WHERE clase.FK_curso = curso.idcurso ";
        $sql .= "AND clase.FK_lugar = lugar.idlugar ";
        $sql .= "AND clase.FK_horario = horario.idhorario ";
        $sql .= "AND curso.FK_paquete = paquete.idpaquete ";
        $sql .= "AND clase.FK_semestre = ".$semestre." ";
        $sql .= "ORDER BY idcurso ASC";
        
        return $this->_db->select($sql);
    }

    public function get_datos_clases() {
        return $this->_db->select("
            SELECT clase.idclase AS idclase, 
            curso.nombre AS curso
            FROM clase, curso
            WHERE clase.FK_curso = curso.idcurso AND
            clase.visible = 1
            ORDER BY idclase ASC"
        );
    }

    public function get_inscripcion($id) {
        $data = $this->_db->select("
            SELECT intersemestral.folio AS folio, 
            intersemestral.cuota AS cuota,  
            intersemestral.FK_estado AS estado,
            intersemestral.semestre AS semestre,
            usuario.nombres AS nombre,
            usuario.apellidoP AS apellidoP,
            usuario.apellidoM AS apellidoM,
            usuario.correo AS correo 
            FROM intersemestral, usuario
            WHERE intersemestral.folio = :id AND
            intersemestral.FK_usuario = usuario.idusuario", 
            array(":id" => $id)
        );
        return $data[0];
    }

    public function get_misCursos_menu($folio) {
        return $this->_db->select("
            SELECT miscursos.idmiscursos as id,
            clase.fecha AS fecha, 
            clase.fechafin AS fechafin, 
            curso.nombre AS nombre,  
            horario.incio AS inicio, 
            horario.final AS final 
            FROM miscursos, clase, curso, horario 
            WHERE miscursos.FK_clase = clase.idclase AND 
            clase.FK_curso = curso.idcurso AND 
            clase.FK_horario = horario.idhorario AND
            miscursos.FK_folio = :folio", 
            array(":folio" => $folio)
        );
    }

    public function existe_folio($folio) {
        $res = $this->_db->select("
            SELECT folio FROM intersemestral WHERE folio = :folio", 
            array(":folio" => $folio)
        );
        if($res){
            return true;
        }else{
            return false;
        }
    }

    public function get_curso($id) {
        return $this->_db->select("SELECT clase.fecha AS fecha, curso.nombre AS curso,  horario.incio AS inicio, horario.final AS final FROM clase, curso, horario WHERE clase.FK_curso = curso.idcurso AND clase.FK_horario = horario.idhorario AND idclase = :id", array(":id" => $id));
    }

    public function get_asistentes($id, $semestre) {
        return $this->_db->select("SELECT intersemestral.folio, usuario.apellidoP, usuario.apellidoM, usuario.nombres, usuario.correo, intersemestral.tipo FROM miscursos, intersemestral, usuario WHERE intersemestral.folio = miscursos.FK_folio AND intersemestral.FK_usuario = usuario.idusuario AND (intersemestral.FK_estado =3 OR intersemestral.FK_estado =2) AND intersemestral.semestre = :semestre AND FK_clase = :id ORDER BY usuario.apellidoP, usuario.apellidoM, usuario.nombres", array(":id" => $id, ":semestre" => $semestre));
    }

    //para alta de becarios
    public function get_alumno($nocuenta) { //PIDE NUMERO DE CUENTA DEL USUARIO
        return $this->_db->select("SELECT * from usuario inner join unam on usuario.idusuario = unam.FK_usuario where unam.noCuenta = ".$nocuenta);    
    }

    //obtener un becario con un numero de cuenta
    public function get_becario($nocuenta) { //PIDE NUMERO DE CUENTA DEL USUARIO
        return $this->_db->select("SELECT * from becario inner join unam on unam.idUNAM = becario.FK_UNAM where unam.noCuenta = ".$nocuenta);    
    }

    //para el listado de los becarios
    public function get_becarios() {
        return $this->_db->select("SELECT 
            unam.noCuenta,usuario.nombres,usuario.apellidoP,usuario.apellidoM,becario.FK_generacion,becario.FK_estado,becario.idbecario
            from usuario,unam,becario WHERE usuario.idusuario = unam.FK_usuario AND unam.idUNAM = becario.FK_UNAM ");    
    }

    //para la vista
    public function get_generaciones() {
        return $this->_db->select("SELECT * from generacionproteco");    
    }

    /*
    Este select es muy largo porque se mete 
    dos veces con la tabla usuario para sacar el nombre de la persona
    que dio la asesoría y tambien de la persona que hizo el registro,
    que pueden ser diferentes. 
    */
    public function get_asesorias() {
        return $this->_db->select("
            SELECT 
                asesoria.idAsesoria,
                asesoria.fecha, 
                asesoria.hora, 
                asesoria.nombreAsesorado, 
                asesoria.materia, 
                asesoria.profesor, 

                usuario.nombres as nombresa, 
                usuario.apellidoP as apellidoPa, 
                usuario.apellidoM as apellidoMa,

                usuario2.nombres as nombresu, 
                usuario2.apellidoP as apellidoPu, 
                usuario2.apellidoM as apellidoMu

            from asesoria,usuario,becario,unam,usuario as usuario2
            WHERE asesoria.FK_becario = becario.idbecario AND 
            becario.FK_UNAM = unam.idUNAM AND 
            unam.FK_usuario = usuario.idusuario AND
            asesoria.FK_usuario = usuario2.idusuario
        ");
    }

    public function insert_becario($data) {
        $this->_db->insert('becario', $data);
    }

    public function insert_interpagado($data) {
        $this->_db->insert('interpagado', $data);
    }

    public function insert_interbecado($data) {
        $this->_db->insert('interbecado', $data);
    }

    public function insert_clase($data) {
        $this->_db->insert('clase', $data);
    }

    public function insert_curso($data) {
        $this->_db->insert('curso', $data);
    }

    public function insert_semestre($data) {
        $this->_db->insert('semestre', $data);
    }

    public function insert_miscursos($data) {
        $this->_db->insert('miscursos', $data);
    }

    //para modificar al rol de usuario como becario
    public function update_usuario($data, $where) {
        $this->_db->update('usuario', $data, $where);
    }

    public function update_becario($data, $where) {
        $this->_db->update('becario', $data, $where);
    }

    public function update_intersemestral($data, $where) {
        $this->_db->update('intersemestral', $data, $where);
    }

    public function update_interpagado($data, $where) {
        $this->_db->update('interpagado', $data, $where);
    }

    public function update_cupo($data, $where) {
        $this->_db->update('clase', $data, $where);
    }

    public function update_clase($data, $where) {
        $this->_db->update('clase', $data, $where);
    }

    public function update_paquete($data, $where) {
        $this->_db->update('curso', $data, $where);
    }

    public function update_miscursos($data, $where) {
        $this->_db->update('miscursos', $data, $where);
    }

    public function update_precio($tabla, $data, $where) {
        $this->_db->update($tabla, $data, $where);
    }    

    public function delete_asesoria($where){
        $this->_db->delete('asesoria',$where);
    }

    public function delete_miscursos($where){
        $this->_db->delete('miscursos',$where);
    }

    public function delete_becario($where){
        $this->_db->delete('becario',$where);
    }

}
