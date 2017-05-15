<?php

use \helpers\session as Session,
    \helpers\form as Form;

?>
<div class="row">
    <h1>Cursos Intersemestrales <?php echo $data['semestreActual']; ?></h1>
    <hr/>
</div>

<div class="row">
    <div class="col-md-12">
        <h3 class="text-center">
            <?php
            if ($data['paquetesRows']) {
                $i = 1;
                foreach ($data['paquetesRows'] as $row) {
                    ?>
                    <a href="<?php echo DIR . "cursos/" . $row->idpaquete; ?>" class="hover-menu footer-a"><?php echo $row->nombre; ?></a>
                    <?php
                    if (count($data['paquetesRows']) == $i) {
                        continue;
                    } else {
                        echo " | ";
                    }
                    $i++;
                }
            }
            ?>
        </h3>
    </div>
</div>

<br>

<div class="row">
    <div class="col-md-offset-2 col-md-8">
        <?php if (Session::get('loggedin') && Session::get('id') && !empty($_SESSION["cart_item"]) && !$_SESSION['folio']) { ?>
            <div class="panel panel-warning">
                <div class="panel-heading">Selecciona los cursos a los que desees inscribirte con el <b>botón amarillo</b> que
                    tiene cada curso y se agregarán <b>aquí</b>, verifica que no se empalmen los horarios y fechas. Cuando estes listo
                    preciona el <b>boton verde</b> para proceder con la inscripción</div>
                <table class="table table-hover table-responsive">
                    <thead>
                    <tr>
                        <th class="text-center">Cursos a inscribir</th>
                        <th class="text-center">Fecha</th>
                        <th class="text-center">Horario</th>
                        <th class="text-center">Precio</th>
                        <th></th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php foreach ($_SESSION['cart_item'] as $k => $v) { ?>
                        <tr>
                            <td class="text-center"><?php echo $v['nombre'] ?></td>
                            <td class="text-center"><?php echo $v['fecha'] ?></td>
                            <td class="text-center"><?php echo $v['horario'] ?></td>
                            <td class="text-center">$<?php echo $v['precio'] ?></td>
                            <td class="text-center"><?php echo Form::open(array('method' => 'post')); ?>
                                <input type="hidden" name="action" value="remove">
                                <input type="hidden" name="idclase" value="<?php echo $k ?>">
                                <?php
                                echo Form::input(array('class' => 'btn btn-default-dl btn-xs', 'type' => 'submit', 'name' => 'submit', 'value' => 'Eliminar'));
                                echo Form::close();
                                ?>
                            </td>
                        </tr>
                    <?php } ?>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class="text-center">
                            <?php echo Form::open(array('method' => 'post')); ?>
                            <input type="hidden" name="action" value="empty">
                            <?php
                            echo Form::input(array('class' => 'btn btn-default-dl btn-xs', 'type' => 'submit', 'name' => 'submit', 'value' => 'Eliminar todo'));
                            echo Form::close();
                            ?>
                        </td>
                    </tr>
                    </tbody>
                </table>
            </div>
            <div class='row'>
                <div class="col-sm-offset-4 col-md-offset-4 col-sm-4 col-md-4">
                    <div class="text-center">
                        <a class="btn btn-success  btn-lg btn-block" href="<?php echo DIR ?>miscursos" role="button">Inscribirme</a>
                    </div>
                </div>
            </div>
        <?php } ?>
    </div>
</div>

<div class="row">
    <div class="col-md-12">
        <?php if ($data['clasesRows']) { ?>
            <h1><?php echo $data['clasesRows'][0]->pnombre; ?></h1>
            <hr/>
        <?php } ?>
    </div>
</div>

<div class="row">
    <div class="col-md-12">
        <?php if ($data['clasesRows']) { ?>
            <?php foreach ($data['clasesRows'] as $row) { ?>
                <div class="col-md-4" style="max-height: 0px; min-height: 700px;">
                    <?php echo Form::open(array('method' => 'post')); ?>
                    <a class="thumbnail">
                        <img src="<?php echo helpers\url::template_path() . "img/" . $row->imagen; ?>" alt="PROTECO">
                    </a>
                    <div class="caption">
                        <h2><b><?php echo $row->curso; ?></b></h2>
                        <p>Requisitos: <b><?php echo $row->requisitos; ?></b></p>
                        <p>Material: <b><?php echo $row->material == null ? "Ninguno" : $row->material; ?></b></p>
                        <p>Lugar: <b><?php echo $row->lugar; ?> - <?php echo $row->ubica; ?></b></p>
                        <p>Horario: <b><?php echo date("H:i", strtotime($row->inicio)); ?>
                                - <?php echo date("H:i", strtotime($row->final)); ?> hrs</b></p>
                        <p>Fecha: <b>Del <?php echo date("d-m-Y", strtotime($row->fecha)); ?>
                                al <?php echo date("d-m-Y", strtotime($row->fin)); ?></b></p>
                        <?php if ($_SESSION['tipo'] == 1) { ?>
                            <p>Precio: <b>$<?php echo $row->precioUnam; ?></b></p>
                        <?php } elseif ($_SESSION['tipo'] == 2) { ?>
                            <p>Precio: <b>$<?php echo $row->precioExterno; ?></b></p>
                        <?php } elseif ($_SESSION['tipo'] == 3) { ?>
                            <p>Precio: <b>$<?php echo $row->precioForaneo; ?></b></p>
                        <?php } ?>
                        <?php if ($row->cupo > 0) { ?>
                            <p>Cupo: <b><?php echo $row->cupo; ?> vacantes disponibles</b></p>
                            <p>
                                <a href="<?php echo PDFDIR . $row->temario . ".pdf"; ?>" class="hover-menu footer-a" target="_blank"><b>
                                        <h3>Ver temario</h3></b></a>
                            </p>
                            <?php if ($_SESSION['folio']) { ?>
                                <div class="alert alert-warning">
                                    <p>Ya te encuentras inscrito, ve a la sección de
                                        <a href="<?php echo DIR ?>miscursos" class="hover-menu">
                                            <strong class="alert-link">mis cursos</strong></a> para ver el estado de tu
                                        inscripción</p>
                                </div>
                            <?php } elseif (!Session::get('loggedin') && !Session::get('id')) { ?>
                                <div class="alert alert-warning">
                                    <p>Para inscribirte tienes que
                                        <a href="<?php echo DIR ?>registro" class="hover-menu">
                                            <strong class="alert-link">registrarte</strong></a> primero</p>
                                </div>
                            <?php } else { ?>
                                <input type="hidden" name="action" value="add">
                                <input type="hidden" name="idclase" value="<?php echo $row->clave ?>">
                                <?php echo Form::input(array('class' => 'btn btn-warning btn-lg btn-block', 'type' => 'submit', 'name' => 'submit', 'value' => 'Agregar')); ?>
                            <?php } ?>
                        <?php } else { ?>
                            <p>Cupo: <b>No hay vacantes disponibles</b></p>
                            <p>
                                <a href="<?php echo PDFDIR . $row->temario . ".pdf"; ?>" class="hover-menu footer-a" target="_blank"><b>
                                        <h3>Ver temario</h3></b></a></p>
                        <?php } ?>
                    </div>
                    <?php echo Form::close(); ?>
                </div>
            <?php } ?>
        <?php } else { ?>
            <div class="center-block">
                <img class="img-responsive" alt="Intersemestral" src="<?php echo helpers\url::template_path(); ?>img/20161.jpg" height="100%" width="100%">
            </div>
        <?php }
        ?>
    </div>
</div>

<div class="row">
    <div class="col-md-9">
        <h1>
            <small><?php echo "Costos"; ?></small>
        </h1>
        <hr/>
        <div class="row">
            <div class="col-md-4">
                <h4 class="well well-sm text-center">Comunidad UNAM</h4>
                <ol class="list-group">
                    <li class="list-group-item">1 curso = $750</li>
                    <li class="list-group-item">2 cursos = $1,500</li>
                    <li class="list-group-item">3 cursos = $1,500</li>
                </ol>
            </div>
            <div class="col-md-4">
                <h4 class="well well-sm text-center">Estudiantes Externos</h4>
                <ol class="list-group">
                    <li class="list-group-item">1 curso = $1700</li>
                    <li class="list-group-item">2 cursos = $3,300</li>
                    <li class="list-group-item">3 cursos = $3,300</li>
                </ol>
            </div>
            <div class="col-md-4">
                <h4 class="well well-sm text-center">Público en General</h4>
                <ol class="list-group">
                    <li class="list-group-item">1 curso = $2,400</li>
                    <li class="list-group-item">2 cursos = $4,800</li>
                    <li class="list-group-item">3 cursos = $4,800</li>
                </ol>
            </div>
        </div>
    </div>
    <div class="col-md-3">
        <h1>
            <small><?php echo "Material para cursos"; ?></small>
        </h1>
        <hr/>
        <?php if ($data['materialRows']) { ?>
            <ol class="list-group">
                <?php foreach ($data['materialRows'] as $row) {
                    ?>
                    <li class="list-group-item"><?php echo $row->nombre; ?> - $<?php echo $row->precio; ?>
                    <?php if (!Session::get('loggedin') && !Session::get('id')) { ?>
                        Para comprar tienes que <a href="<?php echo DIR ?>registro" class="hover-menu">
                            <strong class="alert-link">registrarte</strong></a>
                    <?php } else { ?>
                        <a target="_blank" href="<?php echo DIR . $row->compra ?>" class="hover-menu"><strong class="alert-link">comprar</strong></a></li>
                        <?php
                    }
                }
                ?>
            </ol>
        <?php } ?>
    </div>
</div>