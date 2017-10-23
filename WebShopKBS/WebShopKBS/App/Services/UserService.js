angular.module('user.services', [])
.service('userService',
['$http', function($http) {
	this.login = function(user) {
		return $http.post('/user/login', user);
	}

	this.logout = function (user) {
		return $http.post('/user/logout', user);
	}

	this.register = function (user) {
		return $http.post('/user/register', user);
	}

	this.isUserLoggedIn = function () {
		return $http.get('/user/isUserLoggedIn');
	}
	
	this.addToCart = function(item) {
		return $http.post('/customer/cart', item);
	}
}]);