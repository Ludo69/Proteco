<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">Hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Dar de alta un nuevo curso</small></h1>

        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>
        
        <h3><small>Introduzca los datos de un nuevo curso intersemestral para dar de alta nuevas clases de ese curso.</small></h3>

        

        <div class="well">
            
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <div class="form-group">
                <label for="nombrecurso" class="col-sm-2 control-label">Nombre del curso</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'nombrecurso', 'type' => 'text', 'maxlength' => '20', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Precio para el curso unam-->
            <div class="form-group">
                <label for="unam" class="col-sm-2 control-label">Precio de la UNAM</label>
                <div class="col-sm-10">
                    <select name="unam" class="form-control input-sm">
                        <?php foreach ($data['punam'] as $subrow) { ?>
                            <option
                                value="<?php echo $subrow->idprecioUNAM; ?>" ><?php echo $subrow->precioCurso; ?></option>
                        <?php } ?>
                    </select>
                </div>
            </div>
            <!--Precio para el curso externo-->
            <div class="form-group">
                <label for="externo" class="col-sm-2 control-label">Precio para externos</label>
                <div class="col-sm-10">
                    <select name="externo" class="form-control input-sm">
                        <?php foreach ($data['pexterno'] as $subrow) { ?>
                            <option
                                value="<?php echo $subrow->idprecioExterno; ?>" ><?php echo $subrow->precioCurso; ?></option>
                        <?php } ?>
                    </select>
                </div>
            </div>
            <!--Precio para el curso foraneo-->
            <div class="form-group">
                <label for="foraneo" class="col-sm-2 control-label">Precio para foraneos</label>
                <div class="col-sm-10">
                    <select name="foraneo" class="form-control input-sm">
                        <?php foreach ($data['pforaneo'] as $subrow) { ?>
                            <option
                                value="<?php echo $subrow->idprecioForaneo; ?>" ><?php echo $subrow->precioCurso; ?></option>
                        <?php } ?>
                    </select>
                </div>
            </div>
            <!--Precio para el curso foraneo-->
            <div class="form-group">
                <label for="paquete" class="col-sm-2 control-label">Paquete al que pertenece el curso</label>
                <div class="col-sm-10">
                    <select name="paquete" class="form-control input-sm">
                        <?php foreach ($data['rowPaquetes'] as $subrow) { ?>
                            <option
                                value="<?php echo $subrow->idpaquete; ?>" ><?php echo $subrow->nombre; ?></option>
                        <?php } ?>
                    </select>
                </div>
            </div>
            <!--Nombre de imagen en la base-->
            <div class="form-group">
                <label for="imagen" class="col-sm-2 control-label">Nombre de icono en los archivos</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'imagen', 'type' => 'text', 'maxlength' => '15', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Nombre de temario en la base-->
            <div class="form-group">
                <label for="temario" class="col-sm-2 control-label">Nombre de temario en los archivos</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'temario', 'type' => 'text', 'maxlength' => '15', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Descripcion-->
            <div class="form-group">
                <label for="descripcion" class="col-sm-2 control-label">Descripción del curso</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'descripcion', 'type' => 'text', 'maxlength' => '70', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Requisitos-->
            <div class="form-group">
                <label for="requisitos" class="col-sm-2 control-label">Requisitos del curso</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'requisitos', 'type' => 'text', 'maxlength' => '50', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Material-->
            <div class="form-group">
                <label for="material" class="col-sm-2 control-label">Material del curso</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'material', 'type' => 'text', 'maxlength' => '70', 'class' => 'form-control')); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Dar de alta")); ?>
            </div>
            <?php echo Form::close(); ?>
        </div>
    </div>
</div>