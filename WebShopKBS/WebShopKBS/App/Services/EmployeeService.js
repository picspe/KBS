angular.module('employee.services', [])
.service('employeeService',
['$http', function($http) {
	this.getOrders = function() {
		return $http.get('/employee/orders');
	}

	this.getItems = function() {
		return $http.get('/employee/items');
	}

	this.updateOrder = function(order) {
		return $http.post('/employee/updateOrder', order);
	}

	this.restock = function(list) {
		return $http.post('/employee/restock', list);
	}
}]);