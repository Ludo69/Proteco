<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Control de Becarios <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Registro de Asesorías</small></h1>

        <h3><small>Registra los datos de la asesoría que se acaba de impartir.</small></h3>
        <?php
        echo Error::display($error);
        if ($data['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $data['aviso']; ?> </p>
            </div>
        <?php } ?>
        <div class="well">
            <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
            <!--Fecha de la asesoria-->
            <div class="form-group">
                <label for="fecha" class="col-sm-2 control-label">Fecha de la asesoría</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'fecha', 'type' => 'date', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Hora de la asesoria-->
            <div class="form-group">
                <label for="fecha" class="col-sm-2 control-label">Hora de la asesoría</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'hora', 'type' => 'time', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Nombre de la persona asesorada-->
            <div class="form-group">
                <label for="nombreAsesorado" class="col-sm-2 control-label">Nombre del asesorado</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'nombreAsesorado', 'type' => 'text', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Becario que atendió la asesoría-->
            <div class="form-group">
                <label for="FK_becario" class="col-sm-2 control-label">Becario que atendió</label>
                <div class="col-sm-10">
                    <select class="form-control" name="FK_becario">
                        <option value='' disabled selected>Selecciona al becario que te atendió</option>
                        <?php $etiqueta = ''; ?>
                        <?php foreach ($data['becarios'] as $row) { ?>
                            <?php if ($etiqueta != $row->FK_generacion) { ?>
                                <option value='' disabled>--Generación <?php echo $row->FK_generacion; ?>--</option>
                            <?php $etiqueta = $row->FK_generacion; } ?>
                            <option value="<?php echo $row->idbecario; ?>"><?php echo $row->nombres.' '.$row->apellidoP.' '.$row->apellidoM; ?></option>
                        <?php } ?>
                    </select>
                </div>
            </div>
            <!--Cuenta del usuario que registró la asesoría-->
            <input type="hidden" name="FK_usuario" value="<?php echo $_SESSION['id'];?>">
            <!--Materia-->
            <div class="form-group">
                <label for="materia" class="col-sm-2 control-label">Materia del tema asesorado</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'materia', 'type' => 'text', 'class' => 'form-control')); ?>
                </div>
            </div>
            <!--Profesor-->
            <div class="form-group">
                <label for="profesor" class="col-sm-2 control-label">Profesor del asesorado</label>
                <div class="col-sm-10">
                    <?php echo Form::input(array('name' => 'profesor', 'type' => 'text', 'class' => 'form-control')); ?>
                </div>
            </div>
            <div class="form-group text-center">
                <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Registrar Asesoría")); ?>
            </div>
            <?php echo Form::close(); ?>
        </div>
    </div>
</div>
