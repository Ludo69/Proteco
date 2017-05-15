<?php

use \core\error as Error,
    \helpers\form as Form;

?>

<h1>Administración
    <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small>
</h1>
<hr/>

<div class='row'>
    <div class='col-md-12'>
        <h1>
            <?php echo "Semestre actual: " . $data['semestreActual']; ?>
        </h1>
        
        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>

            <ol>
                <li>
                    <a href="<?php echo DIR ?>altaSemestre" class="hover-menu footer-a">Dar de alta un nuevo intersemestral</a>
                </li>
                <li>
                    <a href="<?php echo DIR ?>altaCurso" class="hover-menu footer-a">Agregar nuevo curso</a>
                </li>
                <li>
                    <a href="<?php echo DIR ?>precios" class="hover-menu footer-a">Configurar precios</a>
                </li>

            </ol>
        <table class="table table-hover">
            <thead>
            <tr>
                <th>Curso</th>
                <th>Paquete</th>
                <th>Cupo Tot.</th>
                <th>Cupo Disp.</th>
                <th>Lugar</th>
                <th>Horario</th>
                <th>Inicio</th>
                <th>Fin</th>
                <th>Acciones</th>
            </tr>
            </thead>
            <tbody>
            <?php
            if ($data['rowClases']) {
                foreach ($data['rowClases'] as $row) {
                    ?>
                    <?php echo Form::open(array('method' => 'post')); ?>
                    <!--form method="post"-->
                        <input type="hidden" name="idclase" value="<?php echo $row->idclase ?>">
                        <tr>
                            <td>
                                <?php foreach ($data['rowCursos'] as $subrow) { ?>
                                    <?php 
                                        if ($subrow->idcurso == $row->idcurso) { 
                                            ?> <p class="small"> <?php echo $subrow->nombre; ?> </p> <?php
                                        } 
                                    ?>
                                <?php } ?>
                            </td>
                            <td class="col-sm-4">
                                <?php foreach ($data['rowPaquetes'] as $subrow) { ?>
                                    <?php 
                                        if ($subrow->idpaquete == $row->idpaquete) { 
                                            ?> <p class="small"> <?php echo $subrow->nombre; ?> </p> <?php
                                        } 
                                    ?>
                                <?php } ?>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input type="text" name="total" value="<?php echo $row->total; ?>"
                                           class="form-control input-sm" maxlength="2"/>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input type="text" name="disponible" value="<?php echo $row->cupo; ?>"
                                           class="form-control input-sm" maxlength="2"/>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <select class="form-control input-sm" name="idlugar">
                                        <?php foreach ($data['rowLugares'] as $subrow) { ?>
                                            <option
                                                value="<?php echo $subrow->idlugar; ?>" <?php if ($subrow->idlugar == $row->idlugar) { ?> selected="selected" <?php } ?>><?php echo $subrow->Nombre . " " . $subrow->Ubicacion; ?></option>
                                        <?php } ?>
                                    </select>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <select class="form-control input-sm" name="idhorario">
                                        <?php foreach ($data['rowHorarios'] as $subrow) { ?>
                                            <option
                                                value="<?php echo $subrow->idhorario; ?>" <?php if ($subrow->idhorario == $row->idhorario) { ?> selected="selected" <?php } ?>><?php echo $subrow->incio . " - " . $subrow->final; ?></option>
                                        <?php } ?>
                                    </select>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input type="date" name="fechaInicio" value="<?php echo $row->fechaInicio; ?>"
                                           class="form-control input-sm col-sm-4"/>
                                </div>
                            </td>
                            <td>
                                <div class="form-group">
                                    <input type="date" name="fechaFin" value="<?php echo $row->fechaFin; ?>"
                                           class="form-control input-sm col-sm-4"/>
                                </div>
                            </td>
                            <td>
                                <button title="Guardar" type="submit" name="submit" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-floppy-save" aria-hidden="true"></span></button>
                                <a title="Ver lista" target="_blank" href="<?php echo DIR ?>generarLista/<?php echo $row->idcurso ?>" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span></a>
                                <?php
                                    if($row->visible){

                                ?>
                                    <button title="Desactivar Curso" type="submit" name="remove" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span></button>
                                <?php        
                                    }
                                    else{
                                ?>
                                    <button title="Activar Curso" type="submit" name="add" class="btn btn-link hover-menu footer-a"><span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span></button>
                                <?php
                                    }
                                ?>     
                            </td>
                        </tr>
                    <?php echo Form::close(); ?>
                    <?php
                }
            }
            ?>
            </tbody>
        </table>
        <div class="text-right">
            <p><a href="<?php echo DIR ?>administracion" class="hover-menu">Regresar</a></p>
        </div>
        
    </div>
</div>
