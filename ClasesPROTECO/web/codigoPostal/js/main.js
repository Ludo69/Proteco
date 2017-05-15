$(document).ready(function(){
	var images = ['img/img1.jpg',
				        'img/img2.jpg',
                'img/img3.jpg', 
                'img/img4.jpg',
                'img/img5.jpg',
                'img/img6.jpg',
                'img/img7.jpg'];

	$("#imagen").css('background-image', 'url('+images[Math.floor(Math.random()*images.length)]+')'
    );
});
