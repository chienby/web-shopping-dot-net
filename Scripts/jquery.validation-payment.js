jQuery(function ($) { 

	$.fn.valid = function (msg) {
		this.addClass('is-valid');
		this.parent().find('.valid-feedback').text(msg);
		return this;
	}

	$.fn.invalid = function (msg) {
		this.addClass('is-invalid');
		this.parent().find('.invalid-feedback').text(msg);
		return this;
	}

	$('.cc-number').payment('formatCardNumber');
	$('.cc-exp').payment('formatCardExpiry');
	$('.cc-cvc').payment('formatCardCVC');

	$('form.validation-payment').submit(function (e) {
		let name = $('.cc-name').val();
		let num = $('.cc-number').val();
		let exp = $('.cc-exp').payment('cardExpiryVal');
		let ccv = $('.cc-cvv').val();
		let type = $.payment.cardType(num);


		if (!$.payment.validateCardName(name)) {
		  $('#Payment_FullName').invalid('Card name is invalid');
		}

		if (!$.payment.validateCardNumber(num)) {
		  $('#Payment_CardNumber').invalid('Card number is invalid');
		}

		if (!$.payment.validateCardExpiry(exp)) {
		  $('#Payment_ExpirationDate').invalid('Expiration date is invalid');
		}

		if (!$.payment.validateCardCVC(ccv, type)) {
		  $('#Payment_CardVerificationValue').invalid('CVV is invalid');
		}

		if (!$.payment.validateCardName(name) ||
		  !$.payment.validateCardNumber(num) ||
		  !$.payment.validateCardExpiry(exp) ||
		  !$.payment.validateCardCVC(ccv, type)) {
		  return false;
		}
	   
	});


});