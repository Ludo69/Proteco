<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Alta Becario</small></h1>
        <?php if ($data['alumno']) { ?>
            <h3>No. Cuenta: <?php echo $data['alumno'][0]->noCuenta ?></h3>
            <h3>Nombre: <?php echo $data['alumno'][0]->nombres.' '.$data['alumno'][0]->apellidoP.' '.$data['alumno'][0]->apellidoM;?></h3>
            <h3><small>Introduzca los datos del becario a registrar:</small></h3>
        <?php } else{ ?>

            <h3><small>Introduzca un Número de cuenta para dar de alta a un nuevo becario</small></h3>
        <?php } ?>
        <div class="well">
            <?php if ($data['alumno']) { ?>
                <!--Generacion de Becario-->
                <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
                <div class="form-group">
                    <label for="generacion" class="col-sm-2 control-label">Generación PROTECO</label>
                    <div class="col-sm-10">
                        <select class="form-control" name="generacion">
                            <option value='' disabled selected>Generación del becario</option>
                            <?php foreach ($data['generaciones'] as $row) { ?>
                                <option value="<?php echo $row->numeroGen; ?>"><?php echo $row->numeroGen; ?></option>
                            <?php } ?>
                        </select>
                    </div>
                </div>
                <!--Sección del Becario-->
                <div class="form-group">
                    <label for="FK_seccion" class="col-sm-2 control-label">Sección en PROTECO</label>
                    <div class="col-sm-10">
                        <select class="form-control" name="FK_seccion">
                            <option value='' disabled selected>Seccion del becario</option>
                            <option value="1">Bases de datos</option>
                            <option value="2">Lenguajes de Programación</option>
                            <option value="3">Aplicaciones Móviles</option>
                            <option value="4">Hardware e Interfaces</option>
                            <option value="5">Redes y Seguridad</option>
                        </select>
                    </div>
                </div>
                <!--Numero de cuenta y nombre-->
                <input type="hidden" name="FK_UNAM" value="<?php echo $data['alumno'][0]->idUNAM;?>">
                <!--id de usuario-->
                <input type="hidden" name="usuario" value="<?php echo $data['alumno'][0]->idusuario;?>">
                <!--Fecha de ingreso a la fac-->
                <div class="form-group">
                    <label for="fechaingresofac" class="col-sm-2 control-label">Fecha de ingreso a la facultad</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'fechaingresofac', 'type' => 'date', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--Fecha de nacimiento-->
                <div class="form-group">
                    <label for="fechanacimiento" class="col-sm-2 control-label">Fecha de nacimiento</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'fechanacimiento', 'type' => 'date', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--rfc-->
                <div class="form-group">
                    <label for="rfc" class="col-sm-2 control-label">RFC</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'rfc', 'type' => 'text', 'maxlength' => '50', 'class' => 'form-control', 'placeholder' => "(Opcional)")); ?>
                    </div>
                </div>
                <!--curp-->
                <div class="form-group">
                    <label for="curp" class="col-sm-2 control-label">CURP</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'curp', 'type' => 'text', 'maxlength' => '50', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--calle-->
                <div class="form-group">
                    <label for="calle" class="col-sm-2 control-label">Calle</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'calle', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--noext-int-->
                <div class="form-group">
                    <label for="noextint" class="col-sm-2 control-label">Número exterior/interior</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'noextint', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--colonia-->
                <div class="form-group">
                    <label for="colonia" class="col-sm-2 control-label">Colonia</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'colonia', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--delegacion-->
                <div class="form-group">
                    <label for="delegacion" class="col-sm-2 control-label">Delegación</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'delegacion', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--codigo postal-->
                <div class="form-group">
                    <label for="codigopostal" class="col-sm-2 control-label">Código Postal</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'codigopostal', 'type' => 'text', 'maxlength' => '10', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--entidad federativa-->
                <div class="form-group">
                    <label for="entidadfederativa" class="col-sm-2 control-label">Entidad Federativa</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'entidadfederativa', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--telefono casa-->
                <div class="form-group">
                    <label for="telefonocasa" class="col-sm-2 control-label">Teléfono de casa</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'telefonocasa', 'type' => 'text', 'maxlength' => '20', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--curp-->
                <div class="form-group">
                    <label for="telefonocelular" class="col-sm-2 control-label">Teléfono celular</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'telefonocelular', 'type' => 'text', 'maxlength' => '20', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--escuela antecedente-->
                <div class="form-group">
                    <label for="escuelaantecedente" class="col-sm-2 control-label">Escuela antecedente</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'escuelaantecedente', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--años cursados-->
                <div class="form-group">
                    <label for="anoscursados" class="col-sm-2 control-label">Años cursados en Preparatoria</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'anoscursados', 'type' => 'number', 'maxlength' => '2', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--promedio prepa-->
                <div class="form-group">
                    <label for="promedioprepa" class="col-sm-2 control-label">Promedio Preparatoria</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'promedioprepa', 'type' => 'decimal', 'maxlength' => '5', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--promedio uni-->
                <div class="form-group">
                    <label for="promediouniversidad" class="col-sm-2 control-label">Promedio Universidad</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'promediouniversidad', 'type' => 'decimal', 'maxlength' => '5', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--Nombre de padre-->
                <div class="form-group">
                    <label for="nombrepadre" class="col-sm-2 control-label">Nombre del padre</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'nombrepadre', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--Nombre de madre-->
                <div class="form-group">
                    <label for="nombremadre" class="col-sm-2 control-label">Nombre de la madre</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'nombremadre', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--accidente-->
                <div class="form-group">
                    <label for="casoaccidente" class="col-sm-2 control-label">En caso de accidente contactar a:</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'casoaccidente', 'type' => 'text', 'maxlength' => '10', 'class' => 'form-control')); ?>
                    </div>
                </div>
                <!--salud-->
                <div class="form-group">
                    <label for="consideracionessalud" class="col-sm-2 control-label">Consideraciones de salud</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'consideracionessalud', 'type' => 'text', 'maxlength' => '100', 'class' => 'form-control', 'placeholder' => "(Opcional)")); ?>
                    </div>
                </div>
                <!-- AQUI ESTA EL ACTION -->
                <input type="hidden" name="action" value="registrar">
                <div class="form-group text-center">
                    <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Registrar nuevo becario")); ?>
                </div>
                <?php echo Form::close(); ?>
                <div class="text-right">
                    <p><a href="<?php echo DIR ?>altaBecario" class="hover-menu">Regresar</a></p>
                </div>
            <?php } else { ?>
                <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
                <div class="form-group">
                    <label for="nocuenta" class="col-sm-2 control-label">Número de Cuenta</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'nocuenta', 'type' => 'number', 'maxlength' => '9', 'class' => 'form-control', 'placeholder' => "Número de Cuenta")); ?>
                    </div>
                </div>
                <input type="hidden" name="action" value="verifica">
                <div class="form-group text-center">
                    <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Buscar número de cuenta")); ?>
                </div>
                <?php echo Form::close(); ?>
                <div class="text-right">
                    <p><a href="<?php echo DIR ?>altaBecario" class="hover-menu">Regresar</a></p>
                </div>
            <?php } ?>
        </div>
        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>
    </div>
</div>
