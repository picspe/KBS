angular.module('employee.controllers', [])
.controller('customerController',
['$scope', '$window', '$state', 'employeeService',
	function ($scope, $window, $state, employeeService) {
		$scope.getOrders = function () {
			employeeService.getOrders().then(function(response) {

			});
		}

		$scope.getItems = function () {
			employeeService.getItems().then(function (response) {

			});
		}

		$scope.updateOrder = function (order) {
			employeeService.updateOrder(order).then(function (response) {

			});
		}

		$scope.restock = function (list) {
			employeeService.restock(list).then(function (response) {

			});
		}
}])