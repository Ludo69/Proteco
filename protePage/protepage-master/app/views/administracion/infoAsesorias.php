<?php

use \core\error as Error;

?>

<h1>Administración
    <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small>
</h1>
<hr/>
<h3>
    Administración de asesorías del PROTECO
</h3>
<?php
    echo Error::display($error);
    if ($data['aviso']) {
        ?>
        <div class="alert alert-success text-center">
            <p><?php echo $data['aviso']; ?> </p>
        </div>
<?php } ?>
<div class='row'>
    <div class='col-md-12'>

        <table class="table table-hover">
            <thead>
            <tr>
                <th>Fecha</th>
                <th>Hora</th>
                <th>Becario</th>
                <th>Usuario que registró</th>
                <th>Asesorado</th>
                <th>Materia</th>
                <th>Profesor</th>
                <th>Acciones</th>
            </tr>
            </thead>
            <tbody>
            <?php
            if ($data['asesorias']) {
                foreach ($data['asesorias'] as $row) {
                    ?>
                    <tr>
                        <td>
                            <?php echo $row->fecha; ?>
                        </td>
                        <td>
                            <?php echo $row->hora; ?>
                        </td>
                        <td>
                            <?php echo $row->nombresa.' '.$row->apellidoPa.' '.$row->apellidoMa; ?>
                        </td>
                        <td>
                            <?php echo $row->nombresu.' '.$row->apellidoPu.' '.$row->apellidoMu; ?>
                        </td>
                        <td>
                            <?php echo $row->nombreAsesorado; ?>
                        </td>
                        <td>
                            <?php echo $row->materia; ?>
                        </td>
                        <td>
                            <?php echo $row->profesor; ?>
                        </td>
                        <td>
                            <form method="post"><input type="hidden" name="asesoria" value="<?php echo $row->idAsesoria; ?>"><button type="submit" name="submit" class="btn btn-warning">Borrar</button></form>
                        </td>
                    </tr>
                    <?php
                }
            }
            ?>
            </tbody>
        </table>
        
    </div>
</div>
