</div>

<header class="header-image">
    <div class="headline">
        <div class="row">
            <div class="col-md-7 col-sm-12 col-md-offset-1  col-sm-offset-1 text-left">
                <div class="header-title">
                    Complementa tu <b>educación</b> y aprende todo lo que necesitas para <b>mejorar</b> tu vida
                    <b>académica</b> y <b>profesional</b>
                </div>
            </div>
        </div>
        <br><br>

        <div class="row">
            <div class="col-md-12 text-center">
                <div class="type-wrap">
                    cursos:~ proteco$ <span id="typed"></span>
                </div>
            </div>
        </div><br><br>

    </div>
</header>

<div class="container">

    <br><br><br>

    <?php

    use \helpers\session as Session; ?>

    <div class="row">
        <div class="col-md-9">
            <h1><?php echo "Últimas publicaciones"; ?></h1>
            <hr/>
            <?php if ($data['posts']) { ?><?php foreach ($data['posts'] as $row) { ?>
                    <div class="row">
                        <div class="col-md-5">
                            <div class="thumbnail">
                                <a href="<?php echo DIR . $row->slug; ?>" class="hover-menu footer-a"><img src="<?php echo DIR . $row->imagen; ?>" class="img-responsive"></a>
                            </div>
                        </div>
                        <div class="col-md-7">
                            <h2>
                                <a href="<?php echo DIR . $row->slug; ?>" class="hover-menu footer-a"><?php echo $row->titulo; ?></a>
                            </h2>

                            <p>
                                <small>Publicado el <?php echo date('d M Y H:i:s', strtotime($row->fechaHora)); ?>
                                    por <?php echo $row->nombres . " " . $row->apellidoP . " " . $row->apellidoM; ?></small>
                            </p>
                            <?php echo stripslashes($row->descripcion); ?>
                        </div>
                    </div><br>
                <?php } ?><?php } ?>
            <?php echo $data['page_links']; ?>
        </div>
        <div class="col-md-3">
            <h1><?php echo "Twitter" ?></h1>
            <hr/>
            <div class="text-center">
                <a class="twitter-timeline" href="https://twitter.com/proteco" data-widget-id="600517093386158080">Tweets por el @proteco.</a>
                <script>
                    !function (d, s, id) {
                        var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https';
                        if (!d.getElementById(id)) {
                            js = d.createElement(s);
                            js.id = id;
                            js.src = p + "://platform.twitter.com/widgets.js";
                            fjs.parentNode.insertBefore(js, fjs);
                        }
                    }(document, "script", "twitter-wjs");
                </script>
            </div>
            <h1><?php echo "Cursos" ?></h1>
            <hr/>
            <div class="text-center">
                <?php
                if ($data['paquetesRows']) {
                    $i = 1;
                    foreach ($data['paquetesRows'] as $row) {
                        ?>
                        <a href="<?php echo DIR . "cursos/" . $row->idpaquete; ?>" class="hover-menu footer-a"><?php echo $row->nombre; ?></a>
                        <?php
                        if (count($data['paquetesRows']) == $i) {
                            continue;
                        } else {
                            echo " | ";
                        }
                        $i++;
                    }
                }
                ?>
            </div>
            <h1><?php echo "Material" ?></h1>
            <hr/>
            <div class="text-center">
                <?php if ($data['materialRows']) { ?>
                    <ol class="list-group">
                        <?php foreach ($data['materialRows'] as $row) {
                            ?>
                            <li class="list-group-item"><?php echo $row->nombre; ?> - $<?php echo $row->precio; ?><?php if (!Session::get('loggedin') && !Session::get('id')) { ?>
                                    Para comprar tienes que <a href="<?php echo DIR ?>registro" class="hover-menu">
                                        <strong class="alert-link">registrarte</strong></a>
                                <?php } else { ?>
                                    <a target="_blank" href="<?php echo DIR . $row->compra ?>" class="hover-menu"><strong class="alert-link">comprar</strong></a></li>
                                <?php
                            }
                        }
                        ?>
                    </ol>
                <?php } ?>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 text-center">
            <img style="display: inline; margin-right: 10%;" class="img-responsive" alt="UNAM" src="<?php echo helpers\url::template_path(); ?>img/unam.png" height="10%" width="10%">
            <img style="display: inline; margin-right: 10%;" class="img-responsive" alt="FACULTAD DE INGENIARI" src="<?php echo helpers\url::template_path(); ?>img/fi.png" height="10%" width="10%">
            <img style="display: inline;" class="img-responsive" alt="PROTECO" src="<?php echo helpers\url::template_path(); ?>img/protecobn.png" height="15%" width="15%">
        </div>
    </div>
    <br>

    <div class="row">
        <div class="col-md-4">
            <h4 class="well well-sm text-center">Comunidad UNAM</h4>
            <ol class="list-group">
                <li class="list-group-item">1 curso = $750</li>
                <li class="list-group-item">2 cursos = $1,500</li>
                <li class="list-group-item">3 cursos = $1,500</li>
            </ol>
        </div>
        <div class="col-md-4">
            <h4 class="well well-sm text-center">Estudiantes Externos</h4>
            <ol class="list-group">
                <li class="list-group-item">1 curso = $1700</li>
                <li class="list-group-item">2 cursos = $3,300</li>
                <li class="list-group-item">3 cursos = $3,300</li>
            </ol>
        </div>
        <div class="col-md-4">
            <h4 class="well well-sm text-center">Público en General</h4>
            <ol class="list-group">
                <li class="list-group-item">1 curso = $2,400</li>
                <li class="list-group-item">2 cursos = $4,800</li>
                <li class="list-group-item">3 cursos = $4,800</li>
            </ol>
        </div>
    </div>