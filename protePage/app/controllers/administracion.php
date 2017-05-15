<?php
//esto es un comentario agregado
namespace controllers;

use \core\view as View,
    \helpers\session as Session,
    \helpers\url as Url;

class Administracion extends \core\controller {

    private $_pdf;
    private $_model;

    public function __construct() {
        parent::__construct();

        if (!Session::get('loggedin') && !Session::get('id')) {
            Url::redirect();
        }

        if ($_SESSION['rol'] != '4') {
            Url::redirect();
        }

        $this->language->load('administracion');
        $this->_model = new \models\administracion();
        $this->_pdf = new \fpdi\FPDI();
    }

    public function index() {
        $data['title'] = $this->language->get('administracion_titulo');
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/administracion', $data);
        View::rendertemplate('footer', $data);
    }

    public function isVacia($arg){
        return ($arg == '');
    }

    public function altaAlumno() {
        $data['title'] = $this->language->get('administracion_titulo');
        if (!is_null(filter_input(INPUT_POST, 'submit')) && !is_null(filter_input(INPUT_POST, 'action'))) {
            if (filter_input(INPUT_POST, 'action') == "verifica") {
                $folio = filter_input(INPUT_POST, 'folio');
                $ticket = filter_input(INPUT_POST, 'ticket');
                $cantidad = filter_input(INPUT_POST, 'cantidad');
                $parcialPagado = 0;

                if ($folio == '' || $ticket == '' || $cantidad == '') {
                    $error[] = "Campos vacios";
                }

                if (!$error) {
                    $parcialTicket = $this->_model->get_pagoparcial($folio);
                    if ($parcialTicket) {
                        foreach ($parcialTicket as $row) {
                            $parcialPagado += $row->cantidad;
                        }
                        $data['parcialPagado'] = $parcialPagado;
                    } else {
                        $data['parcialPagado'] = 0;
                    }
                    $data['alumno'] = $this->_model->get_intersemestral($folio);
                    $data['cursos'] = $this->_model->get_miscursos($folio);
                    $data['ticket'] = $this->_model->get_ticket($ticket);
                    if ($data['ticket']) {
                        $error[] = "El ticket ya ha sido usado";
                    }
                    $data['ticketIngresado'] = $ticket;
                    $data['cantidadIngresada'] = $cantidad;
                }
            } elseif (filter_input(INPUT_POST, 'action') == "altaCurso") {
                $folio = filter_input(INPUT_POST, 'folioInsert');
                $ticket = filter_input(INPUT_POST, 'ticketInsert');
                $cantidad = filter_input(INPUT_POST, 'cantidadInsert');
                $parcialPagado = filter_input(INPUT_POST, 'parcialInsert');
                $totalPagar = filter_input(INPUT_POST, 'totalInsert');

                if (is_null($folio) || is_null($ticket) || is_null($cantidad)) {
                    $error[] = "Ocurrio algun error al darlo de alta, intente de nuevo";
                } else {
                    $interdata = array(
                        'FK_folio' => $folio,
                        'ticket' => $ticket,
                        'cantidad' => $cantidad
                    );
                    $this->_model->insert_interpagado($interdata);
                    //Baja cupo
                    $data['cursos'] = $this->_model->get_miscursos($folio);
                    foreach ($data['cursos'] as $curso) {
                        $cupo = $curso->cupo - 1;
                        $edit = array('cupo' => $cupo);
                        $where = array('idclase' => $curso->idclase);
                        $this->_model->update_cupo($edit, $where);
                    }
                    //Fin baja cupo
                    if (($parcialPagado + $cantidad) < $totalPagar) {
                        $edit = array('FK_estado' => 2);
                        $where = array('folio' => $folio);
                        $this->_model->update_intersemestral($edit, $where);
                        $data['aviso'] = "<b>Pago parcial.</b> ";
                    } else {
                        $edit = array('FK_estado' => 3);
                        $where = array('folio' => $folio);
                        $this->_model->update_intersemestral($edit, $where);
                        $data['aviso'] = "<b>Pago completo.</b> ";
                    }
                    $data['aviso'] .= "Alumno dado de alta exitosamente <br>Folio: " . $folio . " Ticket: " . $ticket . " Cantidad: $" . $cantidad;
                }
            } elseif (filter_input(INPUT_POST, 'action') == "altaCursoParcial") {
                // FALTA ESTA PARTE
            }
        }

        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/altaAlumno', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function altaBecado() {
        $data['title'] = $this->language->get('administracion_titulo');
        $data['becadores'] = $this->_model->get_becadores();
        if (!is_null(filter_input(INPUT_POST, 'submit')) && !is_null(filter_input(INPUT_POST, 'action'))) {
            if (filter_input(INPUT_POST, 'action') == "verifica") {
                $folio = filter_input(INPUT_POST, 'folio');
                $becador = filter_input(INPUT_POST, 'becador');

                if ($folio == '') {
                    $error[] = "Campos vacios";
                }

                if (!$error) {
                    $data['alumno'] = $this->_model->get_intersemestral($folio);
                    $data['cursos'] = $this->_model->get_miscursos($folio);
                    $data['becador'] = $this->_model->get_becador($becador);
                    $data['idbecador'] = $becador;
                }
            } elseif (filter_input(INPUT_POST, 'action') == "altaCurso") {
                $folio = filter_input(INPUT_POST, 'folioInsert');
                $becador = filter_input(INPUT_POST, 'becador');

                if (is_null($folio)) {
                    $error[] = "Ocurrio algun error al darlo de alta, intente de nuevo";
                } else {
                    $interdata = array(
                        'FK_folio' => $folio,
                        'FK_becador' => $becador
                    );
                    $this->_model->insert_interbecado($interdata);
                    //Baja cupo
                    $data['cursos'] = $this->_model->get_miscursos($folio);
                    foreach ($data['cursos'] as $curso) {
                        $cupo = $curso->cupo - 1;
                        $edit = array('cupo' => $cupo);
                        $where = array('idclase' => $curso->idclase);
                        $this->_model->update_cupo($edit, $where);
                    }
                    //Fin baja cupo
                    $edit1 = array('FK_estado' => 3);
                    $where1 = array('folio' => $folio);
                    $this->_model->update_intersemestral($edit1, $where1);
                    $edit2 = array('tipo' => 2);
                    $where2 = array('folio' => $folio);
                    $this->_model->update_intersemestral($edit2, $where2);
                    $data['aviso'] = "<b>Pago completo.</b> ";
                    $data['aviso'] .= "Alumno dado de alta exitosamente <br>Folio: " . $folio . " Becador: " . $becador;
                }
            }
        }

        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/altaBecado', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function altaBecario() {
        
        $data['title'] = $this->language->get('administracion_becario');

        /*
            si el admin entra sin ninguna acción marcada, 
                entonces se carga la primera vista para buscar a un alumno
            si tiene la accion noencontrado
                significa que el numero de cuenta ingresado tiene un error o no existe
            si tiene la accion de registrar
                entonces se carga la segunda vista con los formularios
            si tiene la accion de registrado
                significa que previamente se registro a un becario y no hubo problema
            si tiene la accion regiserror
                significa que trato de de registrar un becario, pero no hubo exito (datos vacíos, datos erroneos etc..)
        
        */
        if (!is_null(filter_input(INPUT_POST, 'submit')) && !is_null(filter_input(INPUT_POST, 'action'))) {
            
            if (filter_input(INPUT_POST, 'action') == 'verifica') {
                $nocuenta = filter_input(INPUT_POST, 'nocuenta');

                if ($nocuenta == '') {
                    $error[] = "Campos vacíos";
                }else{
                    $alumno = $this->_model->get_alumno($nocuenta);
                    if($alumno){
                        
                        $bec = $this->_model->get_becario($nocuenta);

                        if($bec){
                            $error[] = "El número de cuenta le pertenece a un becario registrado.";
                        }
                        else{
                            $data['alumno'] = $alumno;
                            $data['generaciones'] = $this->_model->get_generaciones();                           
                        }
                                                
                    }else{
                        $error[] = "El número de cuenta no está registrado.";
                    }

                }
            } elseif (filter_input(INPUT_POST, 'action') == "registrar") {
                $generacion = filter_input(INPUT_POST, 'generacion');
                $seccion = filter_input(INPUT_POST, 'FK_seccion');
                $unam = filter_input(INPUT_POST, 'FK_UNAM');
                $estado = 1;
                $fechaingresofac = filter_input(INPUT_POST, 'fechaingresofac');
                $fechanacimiento = filter_input(INPUT_POST, 'fechanacimiento');
                $rfc = filter_input(INPUT_POST, 'rfc');
                $curp = filter_input(INPUT_POST, 'curp');
                $calle = filter_input(INPUT_POST, 'calle');
                $noextint = filter_input(INPUT_POST, 'noextint');
                $colonia = filter_input(INPUT_POST, 'colonia');
                $delegacion = filter_input(INPUT_POST, 'delegacion');
                $codigopostal = filter_input(INPUT_POST, 'codigopostal');
                $entidadfederativa = filter_input(INPUT_POST, 'entidadfederativa');
                $telefonocasa = filter_input(INPUT_POST, 'telefonocasa');
                $telefonocelular = filter_input(INPUT_POST, 'telefonocelular');
                $escuelaantecedente = filter_input(INPUT_POST, 'escuelaantecedente');
                $promedioprepa = filter_input(INPUT_POST, 'promedioprepa');
                $promediouniversidad = filter_input(INPUT_POST, 'promediouniversidad');
                $anoscursados = filter_input(INPUT_POST, 'anoscursados');
                $nombrepadre = filter_input(INPUT_POST, 'nombrepadre');
                $nombremadre = filter_input(INPUT_POST, 'nombremadre');
                $casoaccidente = filter_input(INPUT_POST, 'casoaccidente');
                $consideracionessalud = filter_input(INPUT_POST, 'consideracionessalud');
                $usuario = filter_input(INPUT_POST, 'usuario');

                if (
                    $this->isVacia($generacion) ||
                    $this->isVacia($seccion) ||
                    $this->isVacia($fechaingresofac) || 
                    $this->isVacia($fechanacimiento) || 
                    $this->isVacia($curp) ||
                    $this->isVacia($calle) ||
                    $this->isVacia($noextint) ||
                    $this->isVacia($colonia) ||
                    $this->isVacia($delegacion) ||
                    $this->isVacia($codigopostal) ||
                    $this->isVacia($entidadfederativa) ||
                    $this->isVacia($telefonocasa) ||
                    $this->isVacia($telefonocelular) ||
                    $this->isVacia($escuelaantecedente) ||
                    $this->isVacia($promedioprepa) ||
                    $this->isVacia($promediouniversidad) ||
                    $this->isVacia($anoscursados) ||
                    $this->isVacia($nombremadre) ||
                    $this->isVacia($nombrepadre) ||
                    $this->isVacia($casoaccidente) 
                ) {

                    $error[] = "Campos vacíos.";
                    
                }else{
                    $becariodata = array(
                        'FK_generacion' => $generacion,
                        'FK_seccion' => $seccion,
                        'FK_UNAM' => $unam,
                        'FK_estado' => $estado,
                        'fechaingresofac' => $fechaingresofac,
                        'fechanacimiento' => $fechanacimiento,
                        'rfc' => $rfc,
                        'curp' => $curp,
                        'calle' => $calle,
                        'noextint' => $noextint,
                        'colonia' => $colonia,
                        'delegacion' => $delegacion,
                        'codigopostal' => $codigopostal,
                        'entidadfederativa' => $entidadfederativa,
                        'telefonocasa' => $telefonocasa,
                        'telefonocelular' => $telefonocelular,
                        'escuelaantecedente' => $escuelaantecedente,
                        'promediouniversidad' => $promediouniversidad,
                        'promedioprepa' => $promedioprepa,
                        'anoscursados' => $anoscursados,
                        'nombrepadre' => $nombrepadre,
                        'nombremadre' => $nombremadre,
                        'casoaccidente' => $casoaccidente,
                        'consideracionessalud' => $consideracionessalud
                    );
                    $this->_model->insert_becario($becariodata);
                    $data = array('FK_rol' => 3);
                    $where = array('idusuario' => $usuario);
                    $this->_model->update_usuario($data,$where);
                    $data['aviso'] = '<b>Becario registrado en la base de datos.</b>';    
                }

                
            }

        }

        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/altaBecario', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function infoAsesorias() {
        
        $data['title'] = $this->language->get('administracion_asesorias');
        
        if (!is_null(filter_input(INPUT_POST, 'submit'))){
            $asesoria = filter_input(INPUT_POST, 'asesoria');
            $where = array( 'idAsesoria' => $asesoria );
            $this->_model->delete_asesoria($where);
            $data['aviso'] = "La asesoría fue borrada correctamente.";
        }
        $data['asesorias'] = $this->_model->get_asesorias();
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/infoAsesorias', $data, $error);
        View::rendertemplate('footer', $data);
    }    

    public function infoBecarios() {
        
        $data['title'] = $this->language->get('administracion_becario');

        if (!is_null(filter_input(INPUT_POST, 'borrar'))) {
            $becario = filter_input(INPUT_POST, 'becario');
            $where = array( 'idbecario' => $becario );
            $this->_model->delete_becario($where);
            $data['aviso'] = "El becario fue borrado correctamente.";
        }

        $data['becarios'] = $this->_model->get_becarios();
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/infoBecarios', $data, $error);
        View::rendertemplate('footer', $data);
    }




    public function infoInters() {
        $data['title'] = "Administración de cursos intersemestrales";
        $data['semestreActual'] = $this->_model->get_semestre();
        $idsemestre = $this->_model->get_datos_semestre()->idsemestre;
        $data['rowClases'] = $this->_model->get_clases($idsemestre);
        $data['rowCursos'] = $this->_model->get_cursos();
        $data['rowPaquetes'] = $this->_model->get_paquetes();
        $data['rowLugares'] = $this->_model->get_lugares();
        $data['rowHorarios'] = $this->_model->get_horarios();
        

        // guardar nuevos datos
        if (!is_null(filter_input(INPUT_POST, 'submit'))) {
            $idclase = filter_input(INPUT_POST, 'idclase');
            //$idcurso = filter_input(INPUT_POST, 'idcurso');
            //$idpaquete = filter_input(INPUT_POST, 'idpaquete');
            $total = filter_input(INPUT_POST, 'total');
            $disponible = filter_input(INPUT_POST, 'disponible');
            $idlugar = filter_input(INPUT_POST, 'idlugar');
            $idhorario = filter_input(INPUT_POST, 'idhorario');
            $fechaInicio = filter_input(INPUT_POST, 'fechaInicio');
            $fechaFin = filter_input(INPUT_POST, 'fechaFin');

            $dataclase = array(
                //'FK_curso' => $idcurso,
                'FK_lugar' => $idlugar,
                'FK_horario' => $idhorario,
                'cupoTotal' => $total,
                'cupo' => $disponible,
                'fecha' => $fechaInicio,
                'fechaFin' => $fechaFin
            );
            $where = array('idclase' => $idclase);
            $this->_model->update_clase($dataclase, $where);

            Url::redirect("infoInters");
        }

        if (!is_null(filter_input(INPUT_POST, 'remove'))) {
            $idclase = filter_input(INPUT_POST, 'idclase');
            $dataclase = array(
                'visible' => 0
            );
            $where = array('idclase' => $idclase);
            $this->_model->update_clase($dataclase, $where);
            Url::redirect("infoInters");
        }

        if (!is_null(filter_input(INPUT_POST, 'add'))) {
            $idclase = filter_input(INPUT_POST, 'idclase');
            $dataclase = array(
                'visible' => 1
            );
            $where = array('idclase' => $idclase);
            $this->_model->update_clase($dataclase, $where);
            Url::redirect("infoInters");
        }

        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/infoInters', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function altaSemestre() {
        $data['title'] = "Dar de alta un nuevo semestre";
        if (!is_null(filter_input(INPUT_POST, 'submit'))) {
            $nombresemestre = filter_input(INPUT_POST, 'nombresemestre');
            $fechainicio = filter_input(INPUT_POST, 'fechainicio');
            $fechafin = filter_input(INPUT_POST, 'fechafin');
            if (
                    $this->isVacia($nombresemestre) ||
                    $this->isVacia($fechainicio) ||
                    $this->isVacia($fechafin) 
            ){
                $error[] = "Campos vacíos.";
            }else{
                $sempasado = $this->_model->get_datos_semestre();
                $idnuevosem = $sempasado->idsemestre + 1;
                //$idnuevosem = 4;
                $datasem = array(
                    'idsemestre' => $idnuevosem,
                    'actual' => $nombresemestre,
                    'fechaInicio' => $fechainicio,
                    'fechaFin' => $fechafin
                );
                $this->_model->insert_semestre($datasem);
                $datac = array(
                    'visible' => 0
                );
                $where = array(
                    'FK_semestre' => $sempasado->idsemestre
                    //'FK_semestre' => 3 
                );
                $this->_model->update_clase($datac,$where);

                $cursos = $this->_model->get_id_cursos();
                foreach ($cursos as $curso) {
    
                    $clasedata = array(
                        'FK_curso' => $curso->idcurso,
                        'FK_lugar' => 9,
                        'FK_horario' => 5,
                        'cupoTotal' => 50,
                        'cupo' => 50,
                        'fecha' => $fechainicio,
                        'fechaFin' => $fechafin,
                        'FK_semestre' => $idnuevosem,
                        'visible' => 0
                    );
    
                    $this->_model->insert_clase($clasedata);  
                }
                $data['aviso'] = '<b>Semestre y nuevas clases dadas de alta.</b><br>Haga cambios y haga visibles las clases para finalizar.';    
            }
            


        }
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/altaSemestre', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function altaCurso() {
        $data['title'] = "Dar de alta un nuevo curso";
        $data['punam'] = $this->_model->get_preciounam();
        $data['pexterno'] = $this->_model->get_precioexterno();
        $data['pforaneo'] = $this->_model->get_precioforaneo();
        $data['rowPaquetes'] = $this->_model->get_paquetes();


        //$data['rowLugares'] = $this->_model->get_lugares();
        //$data['rowHorarios'] = $this->_model->get_horarios();
        if (!is_null(filter_input(INPUT_POST, 'submit'))) {
            $nombrecurso = filter_input(INPUT_POST, 'nombrecurso');
            $unam = filter_input(INPUT_POST, 'unam');
            $externo = filter_input(INPUT_POST, 'externo');
            $foraneo = filter_input(INPUT_POST, 'foraneo');
            $paquete = filter_input(INPUT_POST, 'paquete');
            $imagen = filter_input(INPUT_POST, 'imagen');
            $temario = filter_input(INPUT_POST, 'temario');
            $descripcion = filter_input(INPUT_POST, 'descripcion');
            $requisitos = filter_input(INPUT_POST, 'requisitos');
            $material = filter_input(INPUT_POST, 'material');

            if (
                $this->isVacia($nombrecurso) ||
                $this->isVacia($unam) ||
                $this->isVacia($externo) || 
                $this->isVacia($foraneo) || 
                $this->isVacia($paquete) ||
                $this->isVacia($imagen) ||
                $this->isVacia($temario) ||
                $this->isVacia($descripcion) ||
                $this->isVacia($requisitos)
            ) {
                $error[] = "Campos vacíos.";
                
            }else{
                $cursodata = array(
                    'nombre' => $nombrecurso,
                    'FK_precioUNAM' => $unam,
                    'FK_precioExterno' => $externo,
                    'FK_precioForaneo' => $foraneo,
                    'FK_paquete' => $paquete,
                    'imagen' => $imagen,
                    'temario' => $temario,
                    'descripcion' => $descripcion,
                    'requisitos' => $requisitos,
                    'material' => $material
                );
                $this->_model->insert_curso($cursodata);

                $idcurso = $this->_model->get_id_curso($nombrecurso);
                $semestre = $this->_model->get_datos_semestre();

                $clasedata = array(
                    'FK_curso' => $idcurso[0]->idcurso,
                    'FK_lugar' => 9,
                    'FK_horario' => 5,
                    'cupoTotal' => 50,
                    'cupo' => 50,
                    'fecha' => $semestre->fechaInicio,
                    'fechaFin' => $semestre->fechaFin,
                    'FK_semestre' => $semestre->idsemestre,
                    'visible' => 0
                );

                $this->_model->insert_clase($clasedata);

                $data['aviso'] = '<b>Curso y clase dados de alta.</b><br>Haga cambios y haga visible al curso para finalizar.';    
            }
        }
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/altaCurso', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function precios() {
        $data['title'] = "Configuracion de precios";
        $data['punam'] = $this->_model->get_preciounam();
        $data['pexterno'] = $this->_model->get_precioexterno();
        $data['pforaneo'] = $this->_model->get_precioforaneo();

        if (!is_null(filter_input(INPUT_POST, 'unam'))) {

            $normal = filter_input(INPUT_POST, 'normal');
            $caro = filter_input(INPUT_POST, 'caro');
            if($normal != '' && $caro != ''){
                $datac = array(
                    'precioCurso' => $normal
                );
                $where = array('idprecioUNAM' => 1);
                $this->_model->update_precio('preciounam',$datac, $where);

                $datac = array(
                    'precioCurso' => $caro
                );
                $where = array('idprecioUNAM' => 2);
                $this->_model->update_precio('preciounam',$datac, $where);
                //$data['aviso'] = 'Precios de la UNAM actualizados correctamente.';
                Url::redirect("precios");

            }
            else{
                $error[] = "Campos vacios en precio UNAM.";
            }
        }

        if (!is_null(filter_input(INPUT_POST, 'foraneo'))) {

            $normal = filter_input(INPUT_POST, 'normal');
            $caro = filter_input(INPUT_POST, 'caro');
            if($normal != '' && $caro != ''){
                $datac = array(
                    'precioCurso' => $normal
                );
                $where = array('idprecioForaneo' => 1);
                $this->_model->update_precio('precioforaneo',$datac, $where);

                $datac = array(
                    'precioCurso' => $caro
                );
                $where = array('idprecioForaneo' => 2);
                $this->_model->update_precio('precioforaneo',$datac, $where);
                //$data['aviso'] = 'Precios foraneos actualizados correctamente.';
                Url::redirect("precios");
            }
            else{
                $error[] = "Campos vacios en precio foraneo.";
            }
        }

        if (!is_null(filter_input(INPUT_POST, 'externo'))) {

            $normal = filter_input(INPUT_POST, 'normal');
            $caro = filter_input(INPUT_POST, 'caro');
            if($normal != '' && $caro != ''){
                $datac = array(
                    'precioCurso' => $normal
                );
                $where = array('idprecioExterno' => 1);
                $this->_model->update_precio('precioexterno',$datac, $where);

                $datac = array(
                    'precioCurso' => $caro
                );
                $where = array('idprecioExterno' => 2);
                $this->_model->update_precio('precioexterno',$datac, $where);
                //$data['aviso'] = 'Precios externos actualizados correctamente.';
                Url::redirect("precios");
            }
            else{
                $error[] = "Campos vacios en precio externo.";
            }
        }

        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/precios', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function infoAlumno() {
        $data['title'] = "Administración de inscripciones";
        if(filter_input(INPUT_POST, 'submit')){
            $nofolio = filter_input(INPUT_POST, 'nofolio');
            if($nofolio != ''){
                Url::redirect("infoAlumno/".$nofolio);    
            }
            else{
                $error[] = "Campo vacío.";
            }
            
        }
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/infoAlumno', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function infoAlumnoNum($folio) {
        $data['title'] = "Administración de inscripciones";
        //$data['aviso'] = "El numero de folio es ".$folio;
        $data['existe'] = $this->_model->existe_folio($folio);
        if($data['existe']){
            $data['datosfolio'] = $this->_model->get_inscripcion($folio);
            $data['clases'] = $this->_model->get_misCursos_menu($folio);
            $data['listaclases'] = $this->_model->get_datos_clases();
        }else{
            $error[] = 'El número de folio no está registrado';
        }
        //dar de alta en un curso

        if(!is_null(filter_input(INPUT_POST, 'add'))){
            $clase = filter_input(INPUT_POST, 'curso');
            if($clase != ''){
                $folio = filter_input(INPUT_POST, 'folio');
                $datos = array(
                    'FK_folio' => $folio, 
                    'FK_clase' => $clase,
                    'FK_estado' => 1,
                    'asistencia' => 0,
                    'calificacion' => 0
                );
                $this->_model->insert_miscursos($datos);
                Url::redirect('infoAlumno/'.$folio);
            }
            else{
                $error[]='Curso no seleccionado';
            }            
            
        }
        //dar de baja del curso
        if(!is_null(filter_input(INPUT_POST, 'remove'))){
            $id = filter_input(INPUT_POST, 'idmiscursos');
            $where = array(
                'idmiscursos' => $id 
            );
            $this->_model->delete_miscursos($where);
            Url::redirect('infoAlumno/'.$folio);
        }
        //cambiar de curso
        if(!is_null(filter_input(INPUT_POST, 'change'))){
            $clase = filter_input(INPUT_POST, 'curso');
            if($clase != ''){
                $id = filter_input(INPUT_POST, 'idmiscursos');
                $datos = array(
                    'FK_clase' => $clase 
                );
                $where = array(
                    'idmiscursos' => $id 
                );
                $this->_model->update_miscursos($datos,$where);
                Url::redirect('infoAlumno/'.$folio);
            }
            else{
                $error[]='Curso no seleccionado';
            } 
        }
        
        View::rendertemplate('header', $data);
        View::rendertemplate('navbar', $data);
        View::render('administracion/infoAlumnoNum', $data, $error);
        View::rendertemplate('footer', $data);
    }

    public function generarLista($id) {
        $curso = $this->_model->get_curso($id);
        $semestre = $this->_model->get_semestre();
        $asistentes = $this->_model->get_asistentes($id, $semestre);
        $this->_pdf->AddPage('L');
        switch ($_SERVER['HTTP_HOST']) {
            case '127.0.0.1':
            case 'localhost':
                if (is_dir("/opt/lampp/htdocs/proteco/app/assets/")) {
                    $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/lista.pdf");
                    //CAMBIAR RUTA AQUI
                } else {
                    $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/lista.pdf");
                }
                break;
            case 'proteco.mx':
                $this->_pdf->setSourceFile("/kunden/homepages/36/d576278833/htdocs/proteco/app/assets/lista.pdf");
                break;
        }
        $this->_pdf->useTemplate($this->_pdf->importPage(1), 0, 0, null, null);
        $this->_pdf->SetFont('Arial');
        $this->_pdf->SetFontSize(12);
        $this->_pdf->SetTextColor(0, 0, 0);
        $this->_pdf->SetXY(135, 30);
        $this->_pdf->Write(0, $semestre);
        $this->_pdf->SetXY(35, 36);
        $this->_pdf->Write(0, utf8_decode($curso[0]->curso));
        $this->_pdf->SetXY(38, 41.5);
        $this->_pdf->Write(0, $curso[0]->inicio);
        $this->_pdf->SetXY(55, 41.5);
        $this->_pdf->Write(0, " - " . $curso[0]->final);
        $this->_pdf->SetXY(36, 47);
        $this->_pdf->Write(0, date("d/m/Y", strtotime($curso[0]->fecha)));
        $this->_pdf->Ln(12);
        $this->_pdf->SetFont('Arial', '', 14);
        $this->_pdf->Cell(23, 12, utf8_decode('Folio'), 'LBTR', 0, 'C');
        $this->_pdf->Cell(125, 12, utf8_decode('Nombre'), 'LBTR', 0, 'C');
        $this->_pdf->Cell(26, 12, utf8_decode('Lunes'), 'LBTR', 0, 'C');
        $this->_pdf->Cell(26, 12, utf8_decode('Martes'), 'LBTR', 0, 'C');
        $this->_pdf->Cell(26, 12, utf8_decode('Miércoles'), 'LBTR', 0, 'C');
        $this->_pdf->Cell(26, 12, utf8_decode('Jueves'), 'LBTR', 0, 'C');
        $this->_pdf->Cell(26, 12, utf8_decode('Viernes'), 'LBTR', 1, 'C');
        $i = 1;
        foreach ($asistentes as $row) {
            $this->_pdf->Cell(23, 12, utf8_decode($i . ' - ' . $row->folio), 'LBTR', 0, 'L');
            $this->_pdf->Cell(125, 12, utf8_decode(' ' . ucwords($row->apellidoP . ' ' . $row->apellidoM . ' ' . $row->nombres)), 'LBTR', 0, 'L');
            $this->_pdf->Cell(26, 12, '', 'LBTR', 0, 'C');
            $this->_pdf->Cell(26, 12, '', 'LBTR', 0, 'C');
            $this->_pdf->Cell(26, 12, '', 'LBTR', 0, 'C');
            $this->_pdf->Cell(26, 12, '', 'LBTR', 0, 'C');
            $this->_pdf->Cell(26, 12, '', 'LBTR', 1, 'C');
            $i++;
        }
        $this->_pdf->Output("Lista " . utf8_decode($curso[0]->curso) . ".pdf", "I");
    }

}
