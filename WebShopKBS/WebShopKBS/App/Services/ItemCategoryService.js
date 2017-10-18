angular.module('managerItemCategory.services', [])
.service('itemCategoryService',
['$http', function ($http) {
	this.getItemCategories = function () {
		return $http.get('/itemCategory');
	}

	this.addItemCategory = function (category) {
		return $http.post('/itemCategory', category);
	}

	this.updateItemCategory = function (category) {
		return $http.put('/itemCategory', category);
	}

	this.deleteItemCategory = function (category) {
		return $http.delete('/itemCategory', category.id);
	}
}]);