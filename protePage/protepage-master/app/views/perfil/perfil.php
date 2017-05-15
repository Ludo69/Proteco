<h1>Mi perfil <small class="pull-right">hola <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />
<?php if ($_SESSION) { ?>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            <div class="well">
                <?php if ($_SESSION['folio']) { ?>
                    <p><b>Folio Intersemestral: </b><?php echo $_SESSION['folio']; ?></p>
                <?php } ?>
                <p><b>Nombre: </b><?php echo $data['row'][0]->nombres . " " . $data['row'][0]->apellidoP . " " . $data['row'][0]->apellidoM . " "; ?></p>
                <p><b>Correo: </b><?php echo $data['row'][0]->correo; ?></p>
                <?php if ($data['row'][0]->tipo == 1) { ?>
                    <p><b>Cuenta: </b><?php echo $data['escuela'][0]->noCuenta; ?></p>
                    <p><b>Plantel: </b><?php echo $data['escuela'][0]->plantel; ?></p>
                    <p><b>Carrera: </b><?php echo $data['escuela'][0]->carrera; ?></p>
                <?php } elseif ($data['row'][0]->tipo == 2) { ?>
                    <p><b>RFC: </b><?php echo $data['escuela'][0]->RFC; ?></p>
                    <p><b>Escuela: </b><?php echo $data['escuela'][0]->nombre; ?></p>
                <?php } elseif ($data['row'][0]->tipo == 3) { ?>
                    <p><b>RFC: </b><?php echo $data['escuela'][0]->RFC; ?></p>
                <?php } ?>
            </div>
        </div>
    </div>
<?php } 

