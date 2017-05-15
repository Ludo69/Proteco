<?php

use \helpers\form as Form,
    \core\error as Error;
?>

<h1>Administración <small class="pull-right">hola Sr. <?php echo $_SESSION['nombre'] ?></small></h1>
<hr />

<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <?php echo Error::display($error); ?>
        <h1><small>Alta post</small></h1>
        <form class='form-horizontal' method='post' enctype="multipart/form-data">
        <div class="form-group">
            <label for="postTitle" class="col-sm-2 control-label">Título</label>
            <div class="col-sm-10">
                <?php if(isset($error)) { $value1 = filter_input(INPUT_POST,'postTitle'); } else { $value1 = ""; } ?>
                <?php echo Form::input(array('name' => 'postTitle', 'value' => $value1, 'type' => 'text', 'class' => 'form-control')); ?>
            </div>
        </div>
        <div class="form-group">
            <label for="postDesc" class="col-sm-2 control-label">Descripción</label>
            <div class="col-sm-10">
                <?php if(isset($error)) { $value2 = filter_input(INPUT_POST,'postDesc'); } else { $value2 = ""; } ?>
                <textarea class="form-control" rows="4" name='postDesc'><?php echo $value2; ?></textarea>			        
            </div>
        </div>
        <div class="form-group">
            <label for="postCont" class="col-sm-2 control-label">Contenido</label>
            <div class="col-sm-10">
                <?php if(isset($error)) { $value3 = filter_input(INPUT_POST,'postCont'); } else { $value3 = ""; } ?>
                <textarea class="form-control" rows="50" name='postCont'><?php echo $value3; ?></textarea>			        
            </div>
        </div>
        <div class="form-group">
            <label for="image" class="col-sm-2 control-label">Imagen</label>
            <div class="col-sm-10">
                <input type="file" name='image'>	
                <p class="help-block">La imagen debe tener una resolucion de 300x300</p>		        
            </div>
        </div>
        <div class="form-group text-center">
            <?php echo Form::input(array('class' => 'btn btn-warning', 'type' => 'submit', 'name' => 'submit', 'value' => "Mandar a revisión")); ?>
        </div>
        <?php echo Form::close(); ?>
        <div class="text-right">
            <p><a href="<?php echo DIR ?>administracion" class="hover-menu">Regresar</a></p>
        </div>
        <?php echo Error::display($error); ?>
    </div>
</div>

<script src="http://js.nicedit.com/nicEdit-latest.js" type="text/javascript"></script>
<script type="text/javascript">bkLib.onDomLoaded(nicEditors.allTextAreas);</script>
