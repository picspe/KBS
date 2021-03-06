﻿angular.module('customer.services', [])
.service('customerService',
['$http', function($http) {
	this.getProfile = function(username) {
		return $http.get('/customer/' + username);
	}

	this.getBill = function(order) {
		return $http.post('/customer/order', order);
	}

	this.placeOrder = function(order) {
		return $http.post('/customer/confirm', order);
	}

	this.getCart = function() {
		return $http.get('/customer/cart');
	}

	this.removeFromCart = function(item) {
		return $http.post('/customer/removeFromCart', item);
	}
}]);