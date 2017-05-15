<?php

use \core\language as Language,
    \helpers\form as Form;

?>
    <h1><?php echo Language::show('cursos_mensaje', 'perfil'); ?></h1>
    <hr/>
<?php
if (!$_SESSION['folio']) {
    $precioCursoUNAM = 750;
    $precioCursoForaneo = 1700;
    $precioCursoExterno = 2400;
    $precioPaqueteUNAM = 1500;
    $precioPaqueteForaneo = 3300;
    $precioPaqueteExterno = 4800;
    $subtotal = 0; // Total real
    $total = 0; // Total con descuento 
    $cursoCaro = 0; // Precio si se selecciona un curso de los caros
    $cursoCaroPaquete = 0; // Precio por el paquete caro 
    $descuentoCaro = 0;
    $descuento = 0; // Descuentos gracias al paquete 
    $count = count($_SESSION['cart_item']); // Numero de cursos
    $cuota = 0; // Total de los totales
    $subCuota = 0;
    if ($_SESSION['cart_item']) {
        ?>
        <div class="alert alert-info text-center">
            <p>Verifica que tus fechas y horarios no se empalmen.</p>
        </div>
        <div class='row'>
            <div class="col-sm-12 col-md-12">
                <table class="table table-condensed table-hover table-responsive">
                    <thead>
                    <tr>
                        <th></th>
                        <th class="text-center"><h3>Curso</h3></th>
                        <th class="text-center"><h3>Fecha</h3></th>
                        <th class="text-center"><h3>Horario</h3></th>
                        <th class="text-center"><h3>Precio</h3></th>
                        <th></th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php foreach ($_SESSION['cart_item'] as $k => $v) { ?>
                        <tr>
                            <td>
                                <div class="img-responsive">
                                    <img src="<?php echo helpers\url::template_path() . "img/" . $v['imagen']; ?>" alt="PROTECO" height="100%" width="">
                                </div>
                            </td>
                            <td class="text-center"><?php echo $v['nombre'] ?></td>
                            <td class="text-center"><?php echo $v['fecha'] ?></td>
                            <td class="text-center"><?php echo $v['horario'] ?></td>
                            <td class="text-center">$<?php echo $v['precio'] ?></td>
                            <td class="text-center">
                                <?php echo Form::open(array('method' => 'post')); ?>
                                <input type="hidden" name="action" value="remove">
                                <input type="hidden" name="idclase" value="<?php echo $k ?>">
                                <?php
                                echo Form::input(array('class' => 'btn btn-default-dl', 'type' => 'submit', 'name' => 'submit', 'value' => 'Eliminar'));
                                echo Form::close();
                                ?>
                            </td>
                        </tr>
                        <?php
                        $subtotal += $v['precio'];
                    }
                    if ($_SESSION['tipo'] == 1) {
                        $total = $count * $precioCursoUNAM;
                        if ($count >= 3 && $count <= 5) {
                            $total = $precioPaqueteUNAM + (($count - 3) * $precioCursoUNAM);
                        } elseif ($count == 6) {
                            $total = $precioPaqueteUNAM * 2;
                        }
                    } else if ($_SESSION['tipo'] == 2) {
                        $total = $count * $precioCursoForaneo;
                        if ($count >= 3 && $count <= 5) {
                            $total = $precioPaqueteForaneo + (($count - 3) * $precioCursoForaneo);
                        } elseif ($count == 6) {
                            $total = $precioPaqueteForaneo * 2;
                        }
                    } else if ($_SESSION['tipo'] == 3) {
                        $total = $count * $precioCursoExterno;
                        if ($count >= 3 && $count <= 5) {
                            $total = $precioPaqueteExterno + (($count - 3) * $precioCursoExterno);
                        } elseif ($count == 6) {
                            $total = $precioPaqueteExterno * 2;
                        }
                    }
                    ?>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class='text-right'><h5>Subtotal:</h5></td>
                        <?php $subCuota = $subtotal + $cursoCaro; ?>
                        <td class="text-center"><b><h4>$<?php echo $subCuota; ?></h4></b></td>
                        <td class="text-center">
                            <?php echo Form::open(array('method' => 'post')); ?>
                            <input type="hidden" name="action" value="empty">
                            <?php
                            echo Form::input(array('class' => 'btn btn-default-dl', 'type' => 'submit', 'name' => 'submit', 'value' => 'Eliminar todo'));
                            echo Form::close();
                            ?>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class='text-right'><h5>Descuento:</h5></td>
                        <?php $descuento = ($subtotal - $total) + $descuentoCaro; ?>
                        <td class="text-center"><b><h4>$<?php echo $descuento; ?></h4></b></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class='text-right'><h5>Total:</h5></td>
                        <?php $cuota = $subCuota - $descuento; ?>
                        <td class="text-center"><b><h4>$<?php echo $cuota; ?></h4></b></td>
                        <td></td>
                    </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <br>
        <div class='row'>
            <div class="col-sm-offset-4 col-md-offset-4 col-sm-4 col-md-4">
                <div class="text-center">
                    <button type="button" class="btn btn-warning btn-lg btn-block" data-toggle="modal" data-target="#modalConfirma">
                        Inscribirme
                    </button>
                </div>
            </div>
        </div>
        <div class="modal fade bs-example-modal-lg" id="modalConfirma" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">¿Estas seguro de inscribir los cursos
                            seleccionados?</h4>
                    </div>
                    <div class="modal-body">

                        <div class="alert alert-info text-center">
                            <p>Verifica que tus fechas y horarios no se empalmen</p>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <?php echo Form::open(array('method' => 'post')); ?>
                        <input type="hidden" name="action" value="inscribir">
                        <input type="hidden" name="cuota" value="<?php echo $cuota; ?>">
                        <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => 'Inscribirme')); ?>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <?php echo Form::close(); ?>
                    </div>
                </div>
            </div>
        </div>
        <br><br>
        <div class="alert alert-danger text-center">
            <p>Al darle clic al botón <b>inscribirme</b> los cursos quedan registrados, recuerda que el siguiente paso es ir a
                pagar a las cajas de la Facultad de Ingeniería con el recibo de pago que va a generarte el sistema.
                Dudas: cursosproteco@gmail.com</p>
        </div>
    <?php } else { ?>
        <div class="row">
            <div class="col-md-12">
                <?php if ($data['aviso']) { ?>
                    <div class="alert alert-info text-center">
                        <p><?php echo $data['aviso']; ?> </p>
                    </div>
                <?php } ?>
            </div>
        </div>
        <div class="alert alert-warning">
            <p>No tienes ningún curso :(
                <a href="<?php echo DIR ?>cursos" class="hover-menu"><strong class="alert-link">
                        inscríbete </strong></a>antes de que se acaben</p>
        </div>
    <?php } ?>
<?php } else { ?>
    <div class="row">
        <div class="col-md-12">
            <?php if ($data['aviso']) { ?>
                <div class="alert alert-success text-center">
                    <p><?php echo $data['aviso']; ?> </p>
                </div>
            <?php } ?>
        </div>
    </div>
    <?php if ($data['estadoRows']) { ?>
        <?php foreach ($data['estadoRows'] as $row) { ?>
            <div class="row">
                <div class="col-md-12">
                    <h1 class="pull-right">Cursos intersemestrales
                        <small><?php echo $row->semestre; ?></small>
                    </h1>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-offset-1 col-md-offset-1 col-sm-10 col-md-10">
                    <?php if ($row->FK_estado == 1) { ?>
                        <div class="alert alert-danger">
                            <p><strong><h3>Estado: Confirmación pendiente.</h3></strong> <br>Puede ser que te falte
                                confirmar el pago, para esto deberás generar tu recibo de pago y seguir con el
                                procedimiento indicado en el recibo. Para dudas o aclaraciones comúnicate con nosotros:
                                cursosproteco@gmail.com y 56 22 38 99 ext. 44174. Síguenos en Twitter: @proteco
                            </p>

                        </div>
                    <?php } else if ($row->FK_estado == 2) { ?>
                        <div class="alert alert-warning">
                            <p><strong><h3>Estado: Parcialmente confirmado.</h3></strong> <br>Puede ser que te falte
                                realizar <strong>la totalidad</strong> del pago, continúa con el procedimiento. Para
                                dudas o aclaraciones comúnicate con nosotros: cursosproteco@gmail.com y 56 22 38 99 ext.
                                44174. Síguenos en Twitter: @proteco
                            </p>
                        </div>
                    <?php } else if ($row->FK_estado == 3) { ?>
                        <div class="alert alert-success">
                            <p><strong><h3>Estado: Confirmado.</h3></strong> <br>Gracias por inscribirte, te esperamos
                                cuando inicie el curso :) Para dudas o aclaraciones comúnicate con nosotros:
                                cursosproteco@gmail.com y 56 22 38 99 ext. 44174. Síguenos en Twitter: @proteco
                            </p>
                        </div>
                    <?php } ?>
                </div>
            </div>
            <div class='row'>
                <div class="col-sm-offset-4 col-md-offset-4 col-sm-4 col-md-4">
                    <div class="text-center">
                        <a class="btn btn-primary btn-lg btn-block" href="<?php echo DIR; ?>pdf" target="_blank" role="button">Generar
                            comprobante de pago</a>
                    </div>
                </div>
            </div><br>
            <?php if(!(sizeof($data['misCursos']) <= 1)) { ?>
                <div class='row'>
                    <div class="col-sm-offset-4 col-md-offset-4 col-sm-4 col-md-4">
                        <div class="text-center">
                            <a class="btn btn-info btn-md btn-block" href="<?php echo DIR; ?>pdfh" target="_blank" role="button">Generar
                                comprobante de pago parcial</a>
                        </div>
                    </div>
                </div><br>
            <?php } ?>
            <div class='row'>
                <div class="col-sm-offset-4 col-md-offset-4 col-sm-4 col-md-4">
                    <div class="text-center">
                        <a class="btn btn-warning btn-md btn-block" href="<?php echo PDFDIR . "reglamento.pdf"; ?>" target="_blank" role="button">Ver
                            reglamento de cursos intersemestrales</a>
                    </div>
                </div>
            </div><br>
            
            <?php if ($row->FK_estado == 1) { ?>
                <div class="row">
                    <div class="col-sm-offset-4 col-md-offset-4 col-sm-4 col-md-4">
                        <div class="text-center">
                            <button type="button" class="btn btn-danger btn-md btn-block" data-toggle="modal" data-target="#modalBaja">
                                Dar de baja los cursos
                            </button>
                        </div>
                    </div>
                </div>
                <div class="modal fade bs-example-modal-lg" id="modalBaja" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="myModalLabel">¿Estas seguro de eliminar los cursos?</h4>
                            </div>
                            <div class="modal-body">
                                <div class="alert alert-danger text-center">
                                    <p>Eliminará tu pre-registro para que vuelvas a seleccionar cursos</p>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <?php echo Form::open(array('method' => 'post')); ?>
                                <input type="hidden" name="action" value="baja">
                                <?php echo Form::input(array('class' => 'btn btn-danger', 'type' => 'submit', 'name' => 'submit', 'value' => 'Eliminar')); ?>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                <?php echo Form::close(); ?>
                            </div>
                        </div>
                    </div>
                </div>
                <?php
            }
        }
    }
    if ($data['misCursos']) {
        ?>
        <br>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-striped table-hover table-responsive">
                    <thead>
                    <tr>
                        <th class="text-center">Curso</th>
                        <th class="text-center">Lugar</th>
                        <th class="text-center">Ubicación</th>
                        <th class="text-center">Fecha de inicio</th>
                        <th class="text-center">Horario</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php foreach ($data['misCursos'] as $row) { ?>
                        <tr>
                            <td class="text-center"><?php echo $row->nombre; ?></td>
                            <td class="text-center"><?php echo $row->lugar; ?></td>
                            <td class="text-center"><?php echo $row->ubica; ?></td>
                            <td class="text-center"><?php echo date('d M Y', strtotime($row->fecha)); ?></td>
                            <td class="text-center"><?php echo date('H:i', strtotime($row->inicio)) ?>
                                a <?php echo date('H:i', strtotime($row->final)); ?></td>
                        </tr>
                    <?php } ?>
                    </tbody>
                </table>
            </div>
        </div>
        <?php
    }
} 