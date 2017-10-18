angular.module('user.controllers', [])
.controller('userController',
['$scope', '$rootScope', '$window', '$state', 'userService', 'saleService', 'itemService','itemCategoryService',
function ($scope, $rootScope, $window, $state, userService, saleService, itemService, itemCategoryService) {
	$scope.login = function (user) {
		userService.login(user).then(function (response) {
			$rootScope.user = response.data;
			switch ($rootScope.user.type) {
				case 0:
					$state.go('customer');
					break;
				case 1:
					$state.go('employee');
					break;
				case 2:
					$state.go('manager');
					break;
				case OTHER:
					$state.go('login');
			}
		});
	}

	$scope.logout = function (user) {
		userService.logout(user).then(function (response) {
			$rootScope.user = undefined;
			$window.location.reload();
			$state.go('login');
			
		});
	}

	$scope.register = function (user) {
		userService.register(user).then(function (response) {
			$state.go('login');
		});
	}

	$scope.isUserLoggedIn = function (user) {
		userService.isUserLoggedIn(user).then(function (response) {
			$rootScope.user = response.data;
		}, function () {
			$rootScope.user = undefined;
			$state.go('login');
		});
	}

	var getContent = function() {
		userService.isUserLoggedIn().then(function(response) {
			$rootScope.user = response.data;
		}, function() {
			$rootScope.user = undefined;
		});
		itemCategoryService.getItemCategories().then(function (response) {
			$rootScope.itemCategories = response.data;
		});
		itemService.getItem().then(function (response) {
			$rootScope.items = response.data;
		});
		saleService.getSale().then(function (response) {
			$rootScope.sales = response.data;
		});
	}

	getContent();
}])