angular.module('employee.controllers', [])
.controller('employeeController',
['$scope', '$window', '$state', 'employeeService',
	function ($scope, $window, $state, employeeService) {
		$scope.addToList = function(item) {
			$scope.restockItems.push(item);
		}

		$scope.removeFromList = function(item) {
			var index = $scope.restockItems.indexOf(item);
			$scope.restockItems[index].splice(index, 1);
		}

		$scope.getOrders = function () {
			employeeService.getOrders().then(function(response) {
				$scope.orders = response.data;
			});
		}

		$scope.getItems = function () {
			employeeService.getItems().then(function (response) {
				$scope.items = response.data;
			});
		}

		$scope.updateOrder = function (order) {
			employeeService.updateOrder(order).then(function (response) {
				alert('Order is updated');
			});
		}

		$scope.restock = function () {
			employeeService.restock($scope.restockItems).then(function (response) {
				$window.location.reload();
			});
		}

		var getContent = function() {
			$scope.getOrders();
			$scope.getItems();
		}

		getContent();
	}])