<?php $slug = "" ?>
<div class="row">
    <?php if ($data['post']) { ?>
        <?php foreach ($data['post'] as $row) { ?>
            <div class="col-md-12">
                <h1><?php echo $row->titulo; ?></h1>
                <hr/>
                <p class="pull-right">
                    <small>Publicado el <?php echo date('d M Y H:i:s', strtotime($row->fechaHora)); ?>
                        por <?php echo $row->nombres . " " . $row->apellidoP . " " . $row->apellidoM; ?></small>
                </p>
                <br><br>
            </div>
            <div class="col-md-4 col-md-offset-4">
                <div class="thumbnail">
                    <img src="<?php echo DIR . $row->imagen; ?>" class="img-responsive">
                </div>
            </div>
            <div class="col-md-12">
                <?php echo stripslashes($row->contenido); ?>
                <div class="text-right">
                    <p><a href="javascript:history.go(-1)" class="hover-menu">Regresar</a></p>
                </div>
            </div>
            <?php $slug = $row->slug; ?>
        <?php } ?>
    <?php } ?>
</div>
<div class="row">
    <div class="col-md-12">
        <div class="fb-share-button" data-href="<?php echo "http://proteco.mx/" . $slug; ?>" data-layout="button_count"></div>
        <div class="fb-like" data-href="https://facebook.com/proteco" data-layout="standard" data-action="like" data-show-faces="false" data-share="false"></div>
        <a class="twitter-share-button" href="<?php echo "http://proteco.mx/" . $slug; ?>" data-counturl="<?php echo "http://proteco.mx/" . $slug; ?>">Tweet</a>
        <div id="disqus_thread"></div>
        <script>
            /**
             * RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
             * LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables
             */
             var disqus_config = function () {
             this.page.url = '<?php echo "http://proteco.mx/" . $slug; ?>'; // Replace PAGE_URL with your page's canonical URL variable
             //this.page.identifier = PAGE_IDENTIFIER; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
             };
            (function () { // DON'T EDIT BELOW THIS LINE
                var d = document, s = d.createElement('script');

                s.src = '//proteco.disqus.com/embed.js';

                s.setAttribute('data-timestamp', +new Date());
                (d.head || d.body).appendChild(s);
            })();
        </script>
        <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript" rel="nofollow">comments
                powered by Disqus.</a></noscript>
    </div>
</div>