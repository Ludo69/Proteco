<?php 
require('conexion.php');

$resultado= mysqli_query($conexion,"SELECT * FROM `login`");
 	 	while ($renglon= mysqli_fetch_array($resultado)) {
 	 		echo $renglon['username'];
 	 		echo "<br>";
}

 ?>