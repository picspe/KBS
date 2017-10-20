angular.module('customerCategory.services', [])
.service('customerCategoryService',
['$http', function($http) {
	this.getCustomerCategories = function() {
		return $http.get('/customerCategory');
	}

	this.addCustomerCategory = function (category) {
		return $http.post('/customerCategory', category);
	}

	this.updateCustomerCategory = function (category) {
		return $http.put('/customerCategory', category);
	}

	this.deleteCustomerCategory = function (category) {
		return $http.delete('/customerCategory', category.id);
	}
}]);