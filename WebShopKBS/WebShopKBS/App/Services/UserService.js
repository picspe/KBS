angular.module('user.services', [])
.service('userService',
['$http', function($http) {
	this.login = function(user) {
		$http.post('/user/login', user);
	}

	this.logout = function (user) {
		$http.post('/user/logout', user);
	}

	this.register = function (user) {
		$http.post('/user/register', user);
	}

	this.isUserLoggedIn = function (user) {
		$http.post('/user/isUserLoggedIn', user);
	}
}]);