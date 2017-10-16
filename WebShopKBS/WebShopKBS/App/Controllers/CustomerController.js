angular.module('customer.controllers', [])
.controller('customerController',
['$scope', '$window', '$state', 'customerService',
	function ($scope, $window, $state, customerService) {
		$scope.getProfile = function (username) {
			customerService.getProfile(username).then(function(response) {

			});
		}

		$scope.getBill = function (order) {
			customerService.getBill(order).then(function(response) {

			});
		}

		$scope.placeOrder = function (order) {
			customerService.placeOrder(order).then(function(response) {

			});
		}
}])