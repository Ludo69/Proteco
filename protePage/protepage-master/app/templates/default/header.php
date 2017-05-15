<!DOCTYPE html>
<html lang="<?php echo LANGUAGE_CODE; ?>">
    <head>
        <meta http-equiv="Content-type" content="text/html; charset=utf-8"/>
        <meta name="description" content="Programa de becarios | Cursos de programación | Blog de tecnología y programación"/>
        <meta name="keywords" content="Becarios Cursos Asesorias Programación Código Bootstrap Foundation PhoneGap Appcelerator Lenguaje C Arduino Cómputo Forense Desarrollo Web Ensamblado Mantenimiento Fortran Linux Matlab HTML CSS XML JavaScript Python Java Android iOS Bases Datos Redes Seguridad">
        <meta name="robots" content="Index, Follow">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="google" content="nositelinkssearchbox">
        <title><?php echo $data['title'] . ' | ' . SITETITLE; ?></title>
        <link rel="icon" type="image/x-icon" href="<?php echo helpers\url::template_path(); ?>img/favicon.ico"/>
        <?php helpers\assets::css(array(helpers\url::template_path() . 'css/bootstrap.min.css', \helpers\url::template_path() . 'css/style.css', \helpers\url::template_path() . 'css/bootstrapValidator.css',\helpers\url::template_path() . 'css/materialize.min.css',\helpers\url::template_path() . 'css/style1.css')); ?>
        <link href="http://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    </head>
        <div id="fb-root"></div>
        <script>(function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0];
                if (d.getElementById(id))
                    return;
                js = d.createElement(s);
                js.id = id;
                js.src = "//connect.facebook.net/en_GB/sdk.js#xfbml=1&version=v2.5&appId=523941137755681";
                fjs.parentNode.insertBefore(js, fjs);
            }(document, 'script', 'facebook-jssdk'));</script>
        <script>window.twttr = (function (d, s, id) {
                var js, fjs = d.getElementsByTagName(s)[0],
                        t = window.twttr || {};
                if (d.getElementById(id))
                    return t;
                js = d.createElement(s);
                js.id = id;
                js.src = "https://platform.twitter.com/widgets.js";
                fjs.parentNode.insertBefore(js, fjs);
                t._e = [];
                t.ready = function (f) {
                    t._e.push(f);
                };
                return t;
            }(document, "script", "twitter-wjs"));</script>

        <?php

        use \helpers\session as Session; ?>
<body>
<div class="navbar-fixed">
 <nav>
    <div class="nav-wrapper">
      <a class="brand-logo" href="<?php echo DIR ?>"><img alt="PROTECO" src="<?php echo helpers\url::template_path(); ?>img/tipo-proteco.png" class="logo" height="25" width="130"></a>
      <a href="#" data-activates="mobile-demo" class="button-collapse"><i class="material-icons">menu</i></a>
      <ul class="right hide-on-med-and-down">
        <li class="<?php echo $data['title'] === 'Programa de Tecnología en Cómputo' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>">Inicio</a></li>
          <li class="<?php echo $data['title'] === 'Nosotros' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>nosotros">Nosotros</a></li>
          <li class="<?php echo $data['title'] === 'Cursos de programación' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>cursos">Cursos</a></li>
          <li class="<?php echo $data['title'] === 'Únete a nuestro programa de becarios' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>unete">Únete</a></li>
          <li class="<?php echo $data['title'] === 'Ayuda' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>ayuda">Ayuda</a></li>
          <li class="<?php echo $data['title'] === 'Contacto' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>contacto">Contacto</a></li>
          <li class=""><a href="<?php echo DIR ?>moodle">Moodle</a></li>
          <li><a class="waves-effect waves-light btn" href="<?php echo DIR; ?>cursos" role="button">Inscríbete</a></li>
          


          <?php if (!Session::get('loggedin') && !Session::get('id')) { ?>
                        <li><a href="<?php echo DIR ?>login">Iniciar sesión</a></li>
                    <?php } else { ?>
                        <li><a class="dropdown-button" href="#!" data-activates="dropdown1">Perfil  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<i class="material-icons right">arrow_drop_down</i></a></li>

                        <ul id="dropdown1" class="dropdown-content">
                        <li class="dropdown-header"><?php echo "Hola " . $_SESSION['nombre'] ?></li>
                                <li class="divider"></li>
                                <li><a href="<?php echo DIR ?>perfil">Mi perfil</a></li>
                                <li><a href="<?php echo DIR ?>miscursos">Mis cursos <p class="badge"><?php echo count($_SESSION['cart_item']) ?></p></a></li>
                                <li><a href="<?php echo DIR ?>mistalleres">Mis talleres <p class="badge">0</p></a></li>
                                <!--li><a href="<?php echo DIR ?>moodle">Moodle</a></li-->
                                <?php if (Session::get('rol') == 4) { ?>
                                    <li class="divider"></li>
                                    <li><a href="<?php echo DIR ?>administracion">Administración</a></li>
                                <?php } ?>
                                <?php if (Session::get('rol') == 4 || Session::get('rol') == 3)  { ?>
                                    <li><a href="<?php echo DIR ?>registroAsesorias">Registro de Asesorías</a></li>
                                <?php } ?>
                                <li class="divider"></li>
                                <li><a href="<?php echo DIR ?>configuracion">Configuración</a></li>
                                <li><a href="<?php echo DIR ?>logout">Cerrar sesión</a></li>
                      </ul>
        <?php } ?>

      </ul>

    
  



      <ul class="side-nav oro" id="mobile-demo">
        <li class="<?php echo $data['title'] === 'Programa de Tecnología en Cómputo' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>">Inicio</a></li>
        <li class="<?php echo $data['title'] === 'Nosotros' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>nosotros">Nosotros</a></li>
        <li class="<?php echo $data['title'] === 'Cursos de programación' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>cursos">Cursos</a></li>
        <li class="<?php echo $data['title'] === 'Únete a nuestro programa de becarios' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>unete">Únete</a></li>
        <li class="<?php echo $data['title'] === 'Ayuda' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>ayuda">Ayuda</a></li>
        <li class="<?php echo $data['title'] === 'Contacto' ? 'active' : ''; ?>"><a href="<?php echo DIR ?>contacto">Contacto</a></li>
        <li class=""><a href="<?php echo DIR ?>moodle">Moodle</a></li>
        <li><a class="waves-effect waves-light btn" href="<?php echo DIR; ?>cursos" role="button">Inscríbete</a></li>
        <?php if (!Session::get('loggedin') && !Session::get('id')) { ?>
                        <li><a href="<?php echo DIR ?>login">Iniciar sesión</a></li>
                    <?php } else { ?>
                        <li><a class="dropdown-button" href="#!" data-activates="dropdown2">Perfil<i class="material-icons right">arrow_drop_down</i></a></li>

                        <ul id="dropdown2" class="dropdown-content">
                        <li class="dropdown-header"><?php echo "Hola " . $_SESSION['nombre'] ?></li>
                                <li class="divider"></li>
                                <li><a href="<?php echo DIR ?>perfil">Mi perfil</a></li>
                                <li><a href="<?php echo DIR ?>miscursos">Mis cursos <p class="badge"><?php echo count($_SESSION['cart_item']) ?></p></a></li>
                                <li><a href="<?php echo DIR ?>mistalleres">Mis talleres <p class="badge">0</p></a></li>
                                <!--li><a href="<?php echo DIR ?>moodle">Moodle</a></li-->
                                <?php if (Session::get('rol') == 4) { ?>
                                    <li class="divider"></li>
                                    <li><a href="<?php echo DIR ?>administracion">Administración</a></li>
                                <?php } ?>
                                <?php if (Session::get('rol') == 4 || Session::get('rol') == 3)  { ?>
                                    <li><a href="<?php echo DIR ?>registroAsesorias">Registro de Asesorías</a></li>
                                <?php } ?>
                                <li class="divider"></li>
                                <li><a href="<?php echo DIR ?>configuracion">Configuración</a></li>
                                <li><a href="<?php echo DIR ?>logout">Cerrar sesión</a></li>
                      </ul>
        <?php } ?>

      </ul>



      </ul>
    </div>
  </nav>
</div>
<main>
