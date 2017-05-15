<?php 
  
  include("./conexion.php");

  //var_dump($miConexion);

  //$query = mysqli_query($miConexion,"SELECT * FROM `usuarios`");
  //$usuarios = mysqli_fetch_all($query);
/*
  var_dump($usuarios);

  echo $usuarios[0][0];//1
  echo $usuarios[0][1];//nombre
  echo $usuarios[0][2];//correo

  echo $usuarios[1][2];
*/
 ?>

<!DOCTYPE html>
<html>
<head>
 <meta charset="utf-8">
 <title>Mi primera query</title>
</head>
<body>
 <h1>Hola query</h1>
 <ul>
   <?php 
      $res = mysqli_query($miConexion,"SELECT * FROM `usuarios`"); //

    while ($fila = mysqli_fetch_array($res)){
      $id = utf8_encode($fila["id"]);    
      $nombre = utf8_encode($fila["nombre"]);    
      $email = utf8_encode($fila["correo"]);    
      echo "<li>".$id.$nombre.$email."</li>";
    }

    ?>
 </ul>
</body>
</html>