<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <?php
        if ($_SESSION['aviso']) {
            ?>
            <div class="alert alert-success text-center">
                <p><?php echo $_SESSION['aviso']; ?></p>
            </div>
            <?php
            unset($_SESSION['aviso']);
        }
        ?>
        <h1><small>Posts</small></h1>
        <div class="text-right">
            <a href="<?php echo DIR ?>altaPost" class="hover-menu footer-a">Agregar un post</a>
        </div>
        <?php if ($data['posts']) { ?>
            <table class="table table-striped table-hover">
                <thead>
                <th>Título</th>
                <th>Descripción</th>
                <th>Fecha</th>
                <th>Becario</th>
                <th>Estado</th>
                <th colspan="3"></th>
                </thead>
                <?php foreach ($data['posts'] as $row) { ?>
                    <tr>
                        <td><?php echo $row->titulo; ?></td>	
                        <td><?php echo $row->descripcion; ?></td>
                        <td><?php echo date('d M Y H:i:s', strtotime($row->fechaHora)); ?></td>
                        <td class="text-center"><?php echo $row->FK_becario; ?></td>
                        <td class="text-center"><?php echo ($row->estado == 1) ? "Aprobado" : "Oculto"; ?></td>
                        <td class="text-center"><a href="<?php echo DIR ?>editarPost/<?php echo $row->idnoticia ?>" class="hover-menu footer-a">Editar</a></td>
                        <td class="text-center"><a href="<?php echo DIR ?>eliminarPost/<?php echo $row->idnoticia ?>" class="hover-menu footer-a">Eliminar</a></td>
                        <td class="text-center"><a href="<?php echo DIR ?>editarEstado/<?php echo $row->idnoticia ?>" class="hover-menu footer-a"><?php echo ($row->estado == 0) ? "Aprobar" : "Ocultar"; ?></a></td>
                    </tr>
                <?php } ?>
            </table>
        <?php } ?>
        <div class="text-right">
            <p><a href="<?php echo DIR ?>administracion" class="hover-menu">Regresar</a></p>
        </div>
    </div>
</div>