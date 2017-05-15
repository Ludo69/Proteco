<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Editar mi perfil <small class="pull-right">hola <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />
<?php if ($_SESSION) { ?>
    <?php if ($data['aviso']) { ?>
        <div class="alert alert-success text-center">
            <p><?php echo $data['aviso']; ?> </p>
        </div>
    <?php } ?>
    <?php echo Error::display($error); ?>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <h1><small>Nombres</small></h1>
            <div class="well">
                <form id="formuEdit" class='form-horizontal' method='post'>
                    <div class="form-group">
                        <label for="nombre" class="col-sm-2 control-label">Nombres</label>
                        <div class="col-sm-10">
                            <?php $value1 = $data['row'][0]->nombres; ?>
                            <?php echo Form::input(array('name' => 'nombre', 'placeholder' => $value1, 'type' => 'text', 'class' => 'form-control')); ?>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="apaterno" class="col-sm-2 control-label">Apellido paterno</label>
                        <div class="col-sm-10">
                            <?php $value2 = $data['row'][0]->apellidoP; ?>
                            <?php echo Form::input(array('name' => 'apaterno', 'placeholder' => $value2, 'type' => 'text', 'class' => 'form-control')); ?>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="amaterno" class="col-sm-2 control-label">Apellido materno</label>
                        <div class="col-sm-10">
                            <?php $value3 = $data['row'][0]->apellidoM; ?>
                            <?php echo Form::input(array('name' => 'amaterno', 'placeholder' => $value3, 'type' => 'text', 'class' => 'form-control')); ?>
                        </div>
                    </div>
                    <div class="form-group text-center">
                        <input type="hidden" name="editsubmit" value="editsubmit">
                        <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'value' => "Editar nombres")); ?>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <h1><small>Contraseña</small></h1>
            <div class="well">
                <form id="formuEditPassword" class='form-horizontal' method='post'>
                    <div class="form-group">
                        <label for="password" class="col-sm-2 control-label">Contraseña nueva</label>
                        <div class="col-sm-10">
                            <input type="password" maxlength="30" class="form-control" id='pass' name="password" placeholder="Contraseña nueva" required>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password2" class="col-sm-2 control-label">Confirmar contraseña</label>
                        <div class="col-sm-10">
                            <input type="password" maxlength="30" class="form-control" id='passC' name="password2" placeholder="Confirmar contraseña" required>
                        </div>
                    </div>
                    <div class="form-group text-center">
                        <input type="hidden" name="editsubmitpass" value="editsubmitpass">
                        <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'value' => "Editar contraseña")); ?>
                    </div>
                </form>
            </div>
        </div>
    </div>
<?php } 

