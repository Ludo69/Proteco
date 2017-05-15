
</main>
</body>
        <footer class="page-footer">
            <div class="row">
              <div class="col s12 offset-m1 m1">
                Mapa del sitio<br><br>
                <ul>
                    <li><a href="<?php echo DIR ?>">Inicio</a></li>
                    <li><a href="<?php echo DIR ?>nosotros">Nosotros</a></li>
                    <li><a href="<?php echo DIR ?>cursos">Cursos</a></li>
                    <li><a href="<?php echo DIR ?>talleres">Talleres</a></li>
                    <li><a href="<?php echo DIR ?>">Blog</a></li>
                    <li><a href="<?php echo DIR ?>unete">Únete</a></li>
                    <li><a href="<?php echo DIR ?>ayuda">Ayuda</a></li>
                    <li><a href="<?php echo DIR ?>contacto">Contacto</a></li>
                </ul>
              </div>
              <div class="col l3 s12 m3">
                <div class="fb-page" data-href="https://www.facebook.com/proteco" data-height="500" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true" data-show-posts="true"><div class="fb-xfbml-parse-ignore"><blockquote cite="https://www.facebook.com/proteco"><a href="https://www.facebook.com/proteco">PROTECO</a></blockquote></div></div>
              </div>
              <div class="col l3 s12 m3 tw">
                <a class="twitter-timeline" href="https://twitter.com/proteco" data-widget-id="600517093386158080">Tweets
                    por el @proteco.</a>
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
              <div class="col l3 s12 m3 tw">
                <address>
                    <b>PROTECO</b><br>
                    Edificio Q "Luis G. Valdés Vallejo", <br>
                    2do piso PROTECO, Anexo de Ingeniería. <br>
                    Ciudad Universitaria <br><br>
                    <abbr title="Phone">T:</abbr> (55) 56-22-30-45 y (55) 56-22-38-99 ext. 44174
                    Whatsapp: (55) 32-86-06-30
                </address>
                <address>
                    <b>Programa de Tecnología en Cómputo</b><br>
                    <a href="mailto:#">cursosproteco@gmail.com</a>
                </address>
                <a href="http://facebook.com/proteco" target="_blank">
                    <img src="<?php echo IMGTEMPLATE . "facebook.png"; ?>" alt="Facebook" width="36px" height="36px"/>
                </a>
                <a href="https://twitter.com/proteco" target="_blank">
                    <img src="<?php echo IMGTEMPLATE . "twitter.png"; ?>" alt="Twitter" width="36px" height="36px"/>
                </a>
                <a href="https://plus.google.com/+PROTECOCursos" target="_blank">
                    <img src="<?php echo IMGTEMPLATE . "google.png"; ?>" alt="Google" width="36px" height="36px"/>
                </a>
                <a href="https://www.linkedin.com/company/proteco" target="_blank">
                    <img src="<?php echo IMGTEMPLATE . "linkedin.png"; ?>" alt="LinkedIn" width="36px" height="36px"/>
                </a>
                <a href="https://www.instagram.com/protecounam" target="_blank">
                    <img src="<?php echo IMGTEMPLATE . "instagram.png"; ?>" alt="Instagram" width="36px" height="36px"/>
                </a>
                <a href="https://www.youtube.com/channel/UCSEngCSxjHdCDFxK-gzwsxw" target="_blank">
                    <img src="<?php echo IMGTEMPLATE . "youtube.png"; ?>" alt="Email" width="36px" height="36px"/>
                </a>
                <a href="mailto:?Subject=Cursos&amp;Body=Info%20Cursos%20Proteco%20">
                    <img src="<?php echo IMGTEMPLATE . "email.png"; ?>" alt="Email" width="36px" height="36px"/>
                </a>
              </div>

            </div>
          <div class="footer-copyright">
            <div class="container">
              <small>
              © 2016 Programa de Tecnología en Cómputo. Universidad Nacional Autónoma de México. Facultad de Ingeniería. Todos los derechos reservados.
              </small>
            </div>
          </div>
        </footer>

<!-- JS -->
<?php
helpers\assets::js(array(helpers\url::template_path() . 'js/jquery.js',
    helpers\url::template_path() . 'js/bootstrap.min.js',
    helpers\url::template_path() . 'js/script.js',
    helpers\url::template_path() . 'js/bootstrapValidator.js',
    helpers\url::template_path() . 'js/typed.js',
    helpers\url::template_path() . 'js/materialize.min.js'));
?>

<script>
    (function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r;
        i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
        a = s.createElement(o),
            m = s.getElementsByTagName(o)[0];
        a.async = 1;
        a.src = g;
        m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

    ga('create', 'UA-63195902-1', 'auto');
    ga('send', 'pageview');

</script>

<script type="text/javascript">
  $(document).ready(function(){
    $(".button-collapse").sideNav();
    $(".dropdown-button").dropdown();
  });
  </script>

</body>
</html>
