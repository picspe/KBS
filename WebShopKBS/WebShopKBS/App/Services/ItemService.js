angular.module('managerItem.services', [])
.service('itemService',
['$http', function ($http) {
	this.getItem = function (id) {
		return $http.get('/item/'+id);
	}

	this.getItems = function () {
		return $http.get('/item');
	}

	this.addItem = function (item) {
		return $http.post('/item', item);
	}

	this.updateItem = function (item) {
		return $http.put('/item', item);
	}

	this.deleteItem = function (item) {
		return $http.delete('/item', item.id);
	}
}]);