<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <h1><small>Opciones</small></h1>
        <div class="well">
            <div class="list-group">
                <a href="<?php echo DIR ?>altaAlumno" class="list-group-item">1. Dar de alta un alumno</a>
                <a href="<?php echo DIR ?>altaBecado" class="list-group-item">2. Dar de alta un becado</a>
                <a href="<?php echo DIR ?>infoAlumno" class="list-group-item">3. Ver inscripción de un asistente</a>
                <a href="<?php echo DIR ?>infoInters" class="list-group-item">4. Informacion de cursos intersemestrales</a>
                <a href="<?php echo DIR ?>verPost" class="list-group-item">5. Posts</a>
                <a href="<?php echo DIR ?>altaBecario" class="list-group-item">6. Dar de alta un nuevo becario</a>
                <a href="<?php echo DIR ?>infoBecarios" class="list-group-item">7. Ver listado de todos los becarios registrados</a>
                <a href="<?php echo DIR ?>infoAsesorias" class="list-group-item">8. Ver listado de las asesorías registradas</a>
            </div>
        </div>
    </div>
</div>
