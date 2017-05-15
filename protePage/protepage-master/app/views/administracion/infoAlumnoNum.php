<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Información de inscripciones <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>
        
        <?php if($data['existe']) { ?>  
            <h1><small><b>Número de folio: <?php echo $data['datosfolio']->folio ?></b></small></h1>
            <div class="well">
                
                <h3><small><b>Nombre del asistente:</b> <?php echo $data['datosfolio']->nombre.' '.$data['datosfolio']->apellidoP.' '.$data['datosfolio']->apellidoM ?></small></h3>
                <h3><small><b>Correo del asistente:</b> <?php echo $data['datosfolio']->correo  ?></small></h3>
                <h3><small><b>Semestre del folio:</b> <?php echo $data['datosfolio']->semestre  ?></small></h3>
                <h3><small><b>Cuota a pagar:</b> $<?php echo $data['datosfolio']->cuota  ?>.00 MXN</small></h3>
                <h3><small><b>Estado del pago:</b> <?php 
                    switch($data['datosfolio']->estado){
                        case 1:
                            echo 'No confirmado.';
                            break;
                        case 2:
                            echo 'Parcial.';
                            break;
                        case 3:
                            echo 'Confirmado.';
                            break;
                    }  

                ?></small></h3>
            </div>
            <h1><small>Cursos inscritos de este folio</small></h1>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Nombre del Curso</th>
                        <th>Fechas</th>
                        <th>Horarios</th>
                        <th>Acciones</th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <?php foreach ($data['clases'] as $clase){ ?>
                        <?php echo Form::open(array('method' => 'post')); ?>
                            <input type="hidden" name="idmiscursos" value="<?php echo $clase->id ?>">
                            
                            <tr>
                                <td> <?php echo $clase->nombre ?></td>
                                <td> <small><?php echo $clase->fecha.' a '.$clase->fechafin ?></small></td>
                                <td> <small><?php echo $clase->inicio.'-'.$clase->final ?></small></td>
                                <td class="col-sm-2">
                                    
                                    <div class="form-group">
                                        <select class="form-control input-sm" name="curso">
                                            <option value='' disabled selected>Selecciona el curso al cual cambiar</option>
                                            <?php foreach ($data['listaclases'] as $row) { ?>
                                                <option
                                                    value="<?php echo $row->idclase; ?>" ><?php echo $row->curso ?></option>
                                            <?php } ?>
                                        </select>
                                    </div>
                                    
                                <td>
                                <td>
                                    <button title="Cambiar a clase seleccionada" type="submit" name="change" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-refresh" aria-hidden="true"></span></button>
                                </td>
                                <td>
                                    <button title="Dar de baja del curso" type="submit" name="remove" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span></button>
                                </td>
                            <tr>
                        <?php echo Form::close(); ?>
                    <?php } ?>
                        
                </tbody>
            </table>
            
            <hr>
            <h1><small>Dar de alta en un curso</small></h1>
            <?php echo Form::open(array('method' => 'post')); ?>
                <table class="table table-hover">
                    <tbody>
                        <td>
                            <input type="hidden" name="folio" value="<?php echo $data['datosfolio']->folio ?>">
                            <div class="form-group">
                                <select class="form-control input-sm" name="curso">
                                    <option value='' disabled selected>Selecciona el curso al cual dar de alta</option>
                                    <?php foreach ($data['listaclases'] as $row) { ?>
                                        <option
                                            value="<?php echo $row->idclase; ?>" ><?php echo $row->curso ?></option>
                                    <?php } ?>
                                </select>
                            </div>
                        </td>
                        <td>
                            <div class="form-group">
                                <button title="Dar de alta en curso seleccionado" type="submit" name="add" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span></button>
                            </div>
                        </td>
                    </tbody>
                </table>
            <?php echo Form::close(); ?>
            <hr>
        <?php 
            }
        ?>
        

        
        <div class="text-right">
            <p><a href="<?php echo DIR ?>infoAlumno" class="hover-menu">Regresar</a></p>
        </div>

        
    </div>
</div>