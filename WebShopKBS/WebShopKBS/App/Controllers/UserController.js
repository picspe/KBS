angular.module('user.controllers', [])
.controller('userController',
['$scope', '$rootScope', '$window', '$state', 'userService', 'itemCategoryService', 'itemService', 'saleService',
	function ($scope, $rootScope, $window, $state, userService, itemCategoryService, itemService, saleService) {
		$scope.getContent();

		$scope.login = function (user) {
			userService.login(user).then(function(response) {
				$rootScope.user = response.data;
				switch ($rootScope.user.type) {
				case 0:
					$state.transitionTo('customer');
					break;
				case 1:
					$state.transitionTo('employee');
					break;
				case 2:
					$state.transitionTo('manager');
					break;
				default:
					$state.transitionTo('login');
					break;
				}
			});
		}

		$scope.logout = function (user) {
			userService.logout(user).then(function (response) {
				$rootScope.user = undefined;
				$state.transitionTo('login');
			});
		}

		$scope.register = function (user) {
			userService.register(user).then(function (response) {
				$state.transitionTo('login');
			});
		}

		$scope.isUserLoggedIn = function (user) {
			userService.isUserLoggedIn(user).then(function (response) {
				$rootScope.user = response.data;
			}, function() {
				$rootScope.user = undefined;
				$state.transitionTo('login');
			});
		}

		$scope.getContent = function() {
			itemCategoryService.getItemCategories().then(function(response) {
				$rootScope.itemCategories = response.data;
			});
			itemService.getItems().then(function (response) {
				$rootScope.items = response.data;
			});
			saleService.getSale().then(function (response) {
				$rootScope.sales = response.data;
			});
		}
	}])