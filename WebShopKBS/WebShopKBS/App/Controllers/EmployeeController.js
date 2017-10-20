angular.module('employee.controllers', [])
.controller('customerController',
['$scope', '$window', '$state', 'employeeService',
	function ($scope, $window, $state, employeeService) {
		$scope.addToList = function(item) {
			$scope.restockItems.push(item);
		}

		$scope.removeFromList = function(item) {
			var index = $scope.restockItems.indexOf(item);
			$scope.restockItems[index].splice(1, index);
		}

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

		$scope.restock = function () {
			employeeService.restock($scope.restockItems).then(function (response) {

			});
		}
}])