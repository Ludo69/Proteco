<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Alta becado</small></h1>
        <div class="well">
            <?php if ($data['alumno']) { ?>
                <p>Folio: <b><?php echo $data['alumno'][0]->folio; ?></b></p>
                <p>Nombre: <b><?php echo $data['alumno'][0]->nombre . " " . $data['alumno'][0]->apellidoP . " " . $data['alumno'][0]->apellidoM; ?></b></p>
                <p>Correo: <b><?php echo $data['alumno'][0]->correo; ?></b></p>
                <?php if ($data['cursos']) { ?>
                    <p>Mis cursos: </p>
                    <?php
                    $i = 1;
                    foreach ($data['cursos'] as $curso) {
                        ?>
                        <p>&nbsp&nbsp&nbsp&nbsp&nbsp<b><?php echo $i . ". " . $curso->nombre . " | Cupo disponible: " . $curso->cupo; ?></b></p>
                        <?php
                        $i++;
                    }
                }
                ?>
                <p>Becador: <b><?php echo $data['becador'][0]->nombre; ?></b></p>
                <p>Total: <b>$<?php echo $data['alumno'][0]->cuota; ?></b></p>
                <?php
                if ($data['alumno'][0]->estado == 1) {
                    ?>
                    <p>Primer pago</p>
                    <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal'));
                    ?>
                    <input type="hidden" name="action" value="altaCurso">
                    <input type="hidden" name="folioInsert" value="<?php echo $data['alumno'][0]->folio; ?>">
                    <input type="hidden" name="becador" value="<?php echo $data['idbecador']; ?>">
                    <div class="form-group text-center"><?php echo Form::input(array('class' => 'btn btn-success', 'type' => 'submit', 'name' => 'submit', 'value' => "Confirmar")); ?></div>
                    <div class="text-right">
                        <p><a href="<?php echo DIR ?>altaBecado" class="hover-menu">Regresar</a></p>
                    </div>
                    <?php
                    echo Form::close();
                } elseif ($data['alumno'][0]->estado == 3) {
                    ?>
                    <p>Ya esta dado de alta</p>
                    <div class="text-right">
                        <p><a href="<?php echo DIR ?>altaBecado" class="hover-menu">Regresar</a></p>
                    </div>
                    <?php
                }
                ?>
            <?php } else { ?>
                <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal')); ?>
                <div class="form-group">
                    <label for="folio" class="col-sm-2 control-label">Folio</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'folio', 'type' => 'number', 'maxlength' => '5', 'class' => 'form-control', 'placeholder' => 'Folio')); ?>
                    </div>
                </div>
                <div class="form-group">
                    <label for="becador" class="col-sm-2 control-label">Becador</label>
                    <div class="col-sm-10">
                        <select name="becador" class="form-control">
                            <?php foreach ($data['becadores'] as $row) { ?>
                                <option value="<?php echo $row->idbecador; ?>"><?php echo $row->nombre; ?></option>
                            <?php } ?>
                        </select>
                    </div>
                </div>
                <input type="hidden" name="action" value="verifica">
                <div class="form-group text-center">
                    <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Dar de alta")); ?>
                </div>
                <?php echo Form::close(); ?>
                <div class="text-right">
                    <p><a href="<?php echo DIR ?>administracion" class="hover-menu">Regresar</a></p>
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
