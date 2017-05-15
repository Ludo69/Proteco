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
        
        <h3><small>Introduzca un Número de folio para ver la información de un asistente.</small></h3>

        

        <div class="well">
            
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="nofolio" class="col-sm-2 control-label">Número de Folio</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'nofolio', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'placeholder' => "Número de Folio")); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Buscar número de folio")); ?>
            </div>
            <?php echo Form::close(); ?>
        </div>
    </div>
</div>