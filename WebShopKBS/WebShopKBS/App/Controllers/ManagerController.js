angular.module('manager.controllers', [])
.controller('managerController',
['$scope', '$window', '$state', 'customerCategoryService', 'itemCategoryService', 'itemService', 'saleService',
	function ($scope, $window, $state, customerCategoryService, itemCategoryService, itemService, saleService) {

		//CUSTOMER CATEGORY FUNCTIONS
		$scope.getCustomerCategories = function () {
			customerCategoryService.getCustomerCategories().then(function(response) {
				$scope.customerCategories = response.data;
			});
		}

		$scope.addCustomerCategory = function (category) {
			customerCategoryService.addCustomerCategory(category).then(function (response) {
				$scope.customerCategories.push(response.data);
			});
		}

		$scope.updateCustomerCategory = function (category) {
			customerCategoryService.updateCustomerCategory(category).then(function (response) {
				alert('Category updated.');
			});
		}

		$scope.deleteCustomerCategory = function (category) {
			customerCategoryService.deleteCustomerCategory(category).then(function (response) {
				var index = $scope.customerCategories.indexOf(category);
				$scope.customerCategories.splice(index, 1);
			});
		}

		//ITEM CATEGORY FUNCTIONS
		$scope.getItemCategories = function () {
			itemCategoryService.getItemCategories().then(function (response) {
				$scope.itemCategories = response.data;
			});
		}

		$scope.addItemCategory = function (category) {
			itemCategoryService.addItemCategory(category).then(function (response) {
				$scope.itemCategories.push(response.data);
			});
		}

		$scope.updateItemCategory = function (category) {
			itemCategoryService.updateItemCategory(category).then(function (response) {
				alert('Category updated.');
			});
		}

		$scope.deleteItemCategory = function (category) {
			itemCategoryService.deleteItemCategory(category).then(function (response) {
				var index = $scope.itemCategories.indexOf(category);
				$scope.itemCategories.splice(index, 1);
			});
		}

		//ITEM FUNCTIONS
		$scope.getItem = function () {
			itemService.getItem().then(function (response) {
				$scope.items = response.data;
			});
		}

		$scope.addItem = function (item) {
			itemService.addItem(item).then(function (response) {
				$scope.items.push(response.data);
			});
		}

		$scope.updateItem = function (item) {
			itemService.updateItem(item).then(function (response) {
				alert('Item updated.');
			});
		}

		$scope.deleteItem = function (item) {
			itemService.deleteItem(item).then(function (response) {
				var index = $scope.items.indexOf(item);
				$scope.items.splice(index, 1);
			});
		}

		//SALES FUNCTIONS
		$scope.getSale = function () {
			saleService.getSale().then(function (response) {
				$scope.sales = response.data;
			});
		}

		$scope.addSale = function (sale) {
			saleService.addSale(sale).then(function (response) {
				$scope.sales.push(response.data);
			});
		}

		$scope.updateSale = function (sale) {
			saleService.updateSale(sale).then(function (response) {
				alert('Sale updated.');
			});
		}

		$scope.deleteSale = function (sale) {
			saleService.deleteSale(sale).then(function (response) {
				var index = $scope.sales.indexOf(sale);
				$scope.sales.splice(1, index);
			});
		}
}])