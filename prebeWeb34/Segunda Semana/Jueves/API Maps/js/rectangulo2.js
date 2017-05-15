// Rectangulo editable

var rectangulo;
var map;
var ventana;

function initMap() {
  map = new google.maps.Map(document.getElementById('mapa'), {
    zoom: 13,
    center: {lat: 33.678, lng: -116.243},
    mapTypeId: google.maps.MapTypeId.TERRAIN
  });

  var bounds = {
    north: 33.685, 
    south: 33.671, 
    east: -116.234, 
    west: -116.251 
  };

  // Definiendo el rectangulo con la propiedad de editable y arrastrable.
  rectangulo = new google.maps.Rectangle({
    strokeColor: '#FF0000',
    strokeOpacity: 0.8,
    strokeWeight: 2,
    fillColor: '#FF0000',
    fillOpacity: 0.35,
    bounds: bounds,
    editable: true,
    draggable: true
  });

  rectangulo.setMap(map);

//}
//HASTA AQUÍ!!!!!!!!!!!!!!!!!
//-------------------------------------------------------------------------------------------------------------------------------
  
//Listener para coordenadas


//AGREGA LISTENER AL CUADRADO.
  rectangulo.addListener('bounds_changed', mostrarVentana);

  // Definiendo un OnfoWindow en el mapa.
  ventana = new google.maps.InfoWindow();
}



// Show the new coordinates for the rectangle in an info window.


function mostrarVentana(event) {
  var ne = rectangulo.getBounds().getNorthEast();
  var so = rectangulo.getBounds().getSouthWest();

  var nuevasCoordenadas = '<b>Las nuevas coordenadas son:</b><br>' +
      'Norte-Este: ' + ne.lat() + ', ' + ne.lng() + '<br>' +
      'Sur-Oeste: ' + so.lat() + ', ' + so.lng();

  // Manda a la ventana la información con las nuevas coordenadas
  ventana.setContent(nuevasCoordenadas);
  ventana.setPosition(ne); //coordenadas de donde sale la ventana

  ventana.open(map);
}