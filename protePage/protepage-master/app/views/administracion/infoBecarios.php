<?php

use \core\error as Error;

?>

<h1>Administración
    <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small>
</h1>
<hr/>
<h3>
    Administración de becarios del PROTECO
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
                <th>No. de Cuenta</th>
                <th>Nombre</th>
                <th>Generación</th>
                <th>Estado</th>
                <th>Acciones</th>
            </tr>
            </thead>
            <tbody>
            <?php
            if ($data['becarios']) {
                foreach ($data['becarios'] as $row) {
                    ?>
                    <tr>
                        <td>
                            <?php echo $row->noCuenta; ?>
                        </td>
                        <td>
                            <?php echo $row->nombres.' '.$row->apellidoP.' '.$row->apellidoM; ?>
                            <?php echo $row->hora; ?>
                        </td>
                        <td>
                            <?php echo $row->FK_generacion; ?>
                        </td>
                        <td>
                            <?php
                                switch($row->FK_estado){
                                    case 1:
                                        echo "Becario Activo";
                                        break;
                                    case 2:
                                        echo "Exbecario";
                                        break;
                                    case 3:
                                        echo "Prebecario";
                                        break;
                                } 
                            ?>
                        </td>
                        <td>
                            <form method="post"><input type="hidden" name="becario" value="<?php echo $row->idbecario; ?>"><button type="submit" name="borrar" class="btn btn-warning">Borrar becario</button></form>
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