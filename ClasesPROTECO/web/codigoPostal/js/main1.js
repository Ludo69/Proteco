$("button").click(function(event){

	event.preventDefault();
  var lugar = $("#lugar").val().replace('','+');
  var url = 'https://maps.googleapis.com/maps/api/geocode/xml?address='+lugar+'&key=AIzaSyBcB3prPmtrG4VulmikJqQ3ewpSk-LsEtA';
  $.ajax({
    type: "GET",
    url: url,
    dataType: "xml",
    success: lugarcp
  });

});

  function lugarcp(xml){
  /*al poner la direccion aparecera un alert con el codigo postal*/

        alert($(xml).find("address_component").each(function() {
          if($(this).find("type").text() == "postal_code"){
            alert("El codigo postal es " + $(this).find("long_name").text());
          }
        }));
}