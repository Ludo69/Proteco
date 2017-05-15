//Archivo de configuración de angular
(function(){
  'use strict';
        //Nombre de la aplicación
                //Dependencias que nuestra aplicacion podría necesitar
angular
.module("myApp",[])
.controller("movieCtrl", movieCtrl);
//Un controlador es el encargado de manejar alguna funcionalidad de la página
function movieCtrl(){
  var movie = this;

  movie.nombre = [{'nombre' : 'Luis'},{'nombre':'Donaldo'}];
  
  movie.collection = [
    {
        'img': 'http://ia.media-imdb.com/images/M/MV5BMTkxNDYxOTA4M15BMl5BanBnXkFtZTgwNTk0NzQxMTE@._V1_UX182_CR0,0,182,268_AL_.jpg',
        'name': 'Matrix',
        'cast' : ['NEO','TRINITY','MORFEO'],
        'year' :  1999,
        'category': 'Sci-Fi'
      },
      {
        'img': 'http://ia.media-imdb.com/images/M/MV5BMTkyNzY5MDA5MV5BMl5BanBnXkFtZTcwMjg4MzI3MQ@@._V1_UY268_CR4,0,182,268_AL_.jpg',
        'name': 'American Gangster',
        'cast' : ['Jhonny deep','Al pachino','Cara cortada'],
        'year' :  1990,
        'category': 'Sci-Fi'
      },
      {
        'img': 'http://ia.media-imdb.com/images/M/MV5BMTYwOTEzMDMzMl5BMl5BanBnXkFtZTgwNzExODIzNzE@._V1_UX182_CR0,0,182,268_AL_.jpg',
        'name': 'Game of Thrones',
        'cast' : ['Caleshy','TRINITY','MORFEO'],
        'year' :  2014,
        'category': 'Sci-Fi'
      },
      {
        'img': 'http://ia.media-imdb.com/images/M/MV5BNDA5NDAzMzg1MF5BMl5BanBnXkFtZTgwOTY2MjU2NzE@._V1_UY268_CR2,0,182,268_AL_.jpg',
        'name': 'Batman',
        'cast' : ['Robin','Guasón','Harley Queen'],
        'year' :  2015,
        'category': 'Sci-Fi'
      },
      {
        'img': 'http://ia.media-imdb.com/images/M/MV5BMjU4NDExNDM1NF5BMl5BanBnXkFtZTgwMDIyMTgxNzE@._V1_UX182_CR0,0,182,268_AL_.jpg',
        'name': 'The revenant',
        'cast' : ['Leo','Iññarritú','Oso'],
        'year' :  1996,
        'category': 'Sci-Fi'
      },
      {
        'img': 'http://ia.media-imdb.com/images/M/MV5BMTk2NTI1MTU4N15BMl5BanBnXkFtZTcwODg0OTY0Nw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg',
        'name': 'The Avengers',
        'cast' : ['Iron Man','Captain America','Hulk'],
        'year' :  2016,
        'category': 'Sci-Fi'
      },

  ];
  
}

})();

