<?php 
require('conexion.php');


 ?>

 <!DOCTYPE html>
 <html lang="en">
 <head>
 	<meta charset="UTF-8">
 	<title>Jueves</title>
 </head>
 <body>
 	<h3>Eliminar usuarios</h3>	

 	<?php 
	/*
	// hacer la query

 		$id=3;
        $consulta ="DELETE FROM usuario WHERE id=$id";
        // echo $consulta;
        // ejecutar la query
        mysqli_query($conexion,$consulta);
        // redireccionar

       */
 	 ?>
 	
	<?php

	 $id=2;
     mysqli_query($conexion,"UPDATE `usuario` SET `nombre` = 'Luis' WHERE `usuario`.`id` = 2;");

     var_dump($consulta);


 	?>
 </body>
 </html>