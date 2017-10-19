angular.module('manager.services', [])
.service('saleService',
['$http', function ($http) {
	this.getSale = function (id) {
		return $http.get('/sale/'+id);
	}
	this.getSales = function () {
		return $http.get('/sale');
	}

	this.addSale = function (sale) {
		return $http.post('/sale', sale);
	}

	this.updateSale = function (sale) {
		return $http.put('/sale', sale);
	}

	this.deleteSale = function (sale) {
		return $http.delete('/sale', sale.id);
	}
}]);