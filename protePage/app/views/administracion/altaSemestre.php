<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Alta de intersemestral</small></h1>

        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>
        
        <h3><small>Introduzca los datos de un nuevo intersemestral para dar de alta nuevas clases.</small></h3>

        

        <div class="well">
            
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="nombresemestre" class="col-sm-2 control-label">Nombre del intersemestral</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'nombresemestre', 'type' => 'text', 'maxlength' => '12', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Fecha de inicio-->
            <div class="form-group">
                <label for="fechainicio" class="col-sm-2 control-label">Fecha de inicio</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'fechainicio', 'type' => 'date', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Fecha de fin-->
            <div class="form-group">
                <label for="fechafin" class="col-sm-2 control-label">Fecha de fin</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'fechafin', 'type' => 'date', 'class' => 'form-control')); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Dar de alta")); ?>
            </div>
            <?php echo Form::close(); ?>
        </div>
    </div>
</div>