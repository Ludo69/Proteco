//otra manera inicializar los elementos
(function($){
  $(function(){

    $('.button-collapse').sideNav();//inicializar pestaña cuando se hace pequeño
    $('.carousel.carousel-slider').carousel({full_width: true}); //inicializar carrusel
    $('.parallax').parallax();//inicializar parallax



  }); // end of document ready
})(jQuery); // end of jQuery name space