<?php

use \core\error as Error;
?>

<h1>Administración <small>Configuración de cursos intersemestrales</small><small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <div class="text-right">
            <p><a href="<?php echo DIR ?>administracion" class="hover-menu">Regresar</a></p>
        </div>
        <h2>Paso 1. Dar de alta nuevo intersemestre y seleccionarlo como el actual</h2>
        <h2>Paso 2. Crear/Editar los paquetes que se van a impartir este nuevo intersemestre</h2>
        <h2>Paso 3. Crear/Editar los cursos que se van a impartir este nuevo intersemestre</h2>
        <h2>Paso 4. Crear/Editar las clases. A cada curso se le tiene que asignar un lugar, horario, cupo, fecha de inicio y fecha final</h2>
        <h3>Si es necesrio agregar un nuevo lugar u horario favor de hacerlo en la parte lateral</h3>
        <h2>Paso 5. Configurar los nuevos precios de los cursos</h2>





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
