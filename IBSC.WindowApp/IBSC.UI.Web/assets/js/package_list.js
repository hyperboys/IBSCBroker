$('.owl-card').owlCarousel({
	margin: 10,
	autoplayHoverPause: true,
	autoplay: true,
	mouseDrag: true,
	responsiveClass: true,
	responsive: {
	    0: {
	        items: 1,
	        loop: true
	    },
	    600: {
	        items: 2,
	        loop: true
	    },
	    1000: {
	        items: 3,
	        loop: false,
	        dots: false
	    }
	}
});

$(window).on('load', function () {
	if (window.innerWidth <= 768) {
		$('#cal_ins').removeClass('in')
		$('#cal_panel').addClass('collapsed')
	}
	else {
		$('#cal_ins').addClass('in')
		$('#cal_panel').removeClass('collapsed')
	}
})
