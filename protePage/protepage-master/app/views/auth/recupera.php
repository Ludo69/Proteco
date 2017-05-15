<?php

use \helpers\form as Form,
    \core\error as Error;
?>
<div class="row">
    <h1>Recupera tu contraseña</h1>
    <hr />    
</div>

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <div class="well">
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="correo" class="col-sm-2 control-label">Correo</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'correo', 'type' => 'text', 'maxlength' => '40', 'class' => 'form-control', 'placeholder' => 'Correo')); ?>
                    <p><small>Ingresa el correo con el que te registraste en el sitio</small></p>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Enviar contraseña temporal")); ?>
            </div>
            <?php echo Form::close(); ?>
            <div class="text-right">
                <p><small>Se te enviará una contraseña temporal al correo con el que te registraste en el sitio</small></p>
            </div>
        </div>
        <?php echo Error::display($error); ?>
        <?php
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?></p>
            </div>
        <?php } ?>
    </div>
</div>



