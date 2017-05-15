<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Configuracion de precios</small></h1>

        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>
        
        <h3><small>Configure los precios de los cursos intersemestrales.</small></h3>
        <hr>
        <h3><small>Precios UNAM</small></h3>
        <div class="well">
            
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="normal" class="col-sm-2 control-label">Precio Normal</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'normal', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'value' => $data['punam'][0]->precioCurso)); ?>
                </div>
            </div>
            <div class="form-group">
                <label for="caro" class="col-sm-2 control-label">Precio Caro</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'caro', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'value' => $data['punam'][1]->precioCurso)); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'unam', 'value' => "Actualizar")); ?>
            </div>
            <?php echo Form::close(); ?>
            
        </div>
        <h3><small>Precios Foraneos</small></h3>
        <div class="well">
            
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="normal" class="col-sm-2 control-label">Precio Normal</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'normal', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'value' => $data['pforaneo'][0]->precioCurso)); ?>
                </div>
            </div>
            <div class="form-group">
                <label for="caro" class="col-sm-2 control-label">Precio Caro</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'caro', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'value' => $data['pforaneo'][1]->precioCurso)); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'foraneo', 'value' => "Actualizar")); ?>
            </div>
            <?php echo Form::close(); ?>
            
        </div>
        <h3><small>Precios Externos</small></h3>
        <div class="well">
            
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="normal" class="col-sm-2 control-label">Precio Normal</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'normal', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'value' => $data['pexterno'][0]->precioCurso)); ?>
                </div>
            </div>
            <div class="form-group">
                <label for="caro" class="col-sm-2 control-label">Precio Caro</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'caro', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'value' => $data['pexterno'][1]->precioCurso)); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'externo', 'value' => "Actualizar")); ?>
            </div>
            <?php echo Form::close(); ?>
            
        </div>
        <br>

        <div class="text-right">
            <p><a href="<?php echo DIR ?>infoInters" class="hover-menu">Regresar al menú</a></p>
        </div>
    </div>
</div>