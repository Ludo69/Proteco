<?php 

	include ("./conexion.php");
	$nombre = $_GET["nombre"];
	$correo = $_GET["correo"];

	$query = "INSERT INTO `usuarios` (id, nombre, correo) VALUES (NULL, '".$nombre."','".$correo."');";

	$inserta = mysqli_query($miConexion,$query);
	var_dump($inserta);
 ?>