<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Alta alumno</small></h1>
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
                <p>Total a pagar: <b>$<?php echo $data['alumno'][0]->cuota; ?></b></p>
                <p>Cantidad ingresada: <b>$<?php echo $data['cantidadIngresada']; ?></b></p>
                <p>Cantidad pagada: <b>$<?php echo $data['parcialPagado']; ?></b></p>
                <p>Ticket ingresado: <b><?php echo $data['ticketIngresado']; ?></b></p>
                <?php if ($data['ticket']) { ?>
                    <div class="text-right">
                        <p><a href="<?php echo DIR ?>altaAlumno" class="hover-menu">Regresar</a></p>
                    </div>
                    <?php
                } else {
                    if ($data['alumno'][0]->estado == 1) {
                        ?>
                        <p>Primer pago</p>
                        <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal'));
                        ?>
                        <input type="hidden" name="action" value="altaCurso">
                        <input type="hidden" name="folioInsert" value="<?php echo $data['alumno'][0]->folio; ?>">
                        <input type="hidden" name="ticketInsert" value="<?php echo $data['ticketIngresado']; ?>">
                        <input type="hidden" name="cantidadInsert" value="<?php echo $data['cantidadIngresada']; ?>">
                        <input type="hidden" name="parcialInsert" value="<?php echo $data['parcialPagado']; ?>">
                        <input type="hidden" name="totalInsert" value="<?php echo $data['alumno'][0]->cuota; ?>">
                        <div class="form-group text-center"><?php echo Form::input(array('class' => 'btn btn-success', 'type' => 'submit', 'name' => 'submit', 'value' => "Confirmar")); ?></div>
                        <div class="text-right">
                            <p><a href="<?php echo DIR ?>altaAlumno" class="hover-menu">Regresar</a></p>
                        </div>
                        <?php
                        echo Form::close();
                    } elseif ($data['alumno'][0]->estado == 2) {
                        ?>
                        <p>Pago parcial</p>
                        <?php echo Form::open(array('method' => 'post', 'class' => 'form-horizontal'));
                        ?>
                        <input type="hidden" name="action" value="altaCursoParcial">
                        <input type="hidden" name="folioInsert" value="<?php echo $data['alumno'][0]->folio; ?>">
                        <input type="hidden" name="ticketInsert" value="<?php echo $data['ticketIngresado']; ?>">
                        <input type="hidden" name="cantidadInsert" value="<?php echo $data['cantidadIngresada']; ?>">
                        <input type="hidden" name="parcialInsert" value="<?php echo $data['parcialPagado']; ?>">
                        <input type="hidden" name="totalInsert" value="<?php echo $data['alumno'][0]->cuota; ?>">
                        <div class="form-group text-center"><?php echo Form::input(array('class' => 'btn btn-success', 'type' => 'submit', 'name' => 'submit', 'value' => "Confirmar")); ?></div>
                        <div class="text-right">
                            <p><a href="<?php echo DIR ?>altaAlumno" class="hover-menu">Regresar</a></p>
                        </div>
                        <?php
                        echo Form::close();
                    } elseif ($data['alumno'][0]->estado == 3) {
                        ?>
                        <p>Ya esta dado de alta</p>
                        <div class="text-right">
                            <p><a href="<?php echo DIR ?>altaAlumno" class="hover-menu">Regresar</a></p>
                        </div>
                        <?php
                    }
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
                    <label for="ticket" class="col-sm-2 control-label">Ticket</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'ticket', 'type' => 'number', 'maxlength' => '9', 'class' => 'form-control', 'placeholder' => "Ticket")); ?>
                    </div>
                </div>
                <div class="form-group">
                    <label for="cantidad" class="col-sm-2 control-label">Cantidad</label>
                    <div class="col-sm-10">
                        <?php echo Form::input(array('name' => 'cantidad', 'type' => 'number', 'maxlength' => '4', 'class' => 'form-control', 'placeholder' => "Cantidad")); ?>
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
