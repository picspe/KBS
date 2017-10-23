angular.module('user.controllers', [])
.controller('userController',
['$scope', '$rootScope', '$window', '$state', 'userService', 'saleService', 'itemService','itemCategoryService', 'customerCategoryService',
	function ($scope, $rootScope, $window, $state, userService, saleService, itemService, itemCategoryService, customerCategoryService) {
		$scope.login = function (user, type) {
			user.type = type;
		userService.login(user).then(function (response) {
			$rootScope.user = response.data;
			switch ($rootScope.user.type) {
				case 0:
					$state.go('home');
					break;
				case 1:
					$state.go('employee');
					break;
				case 2:
					$state.go('manager');
					break;
				case OTHER:
					$state.go('login');
			}
		});
	}

	$scope.logout = function (user) {
		userService.logout(user).then(function (response) {
			$rootScope.user = undefined;
			$window.location.reload();
			$state.go('login');
			
		});
	}

	$scope.register = function (user) {
		userService.register(user).then(function (response) {
			$state.go('login');
		});
	}

	$scope.isUserLoggedIn = function (user) {
		userService.isUserLoggedIn(user).then(function (response) {
			$rootScope.user = response.data;
		}, function () {
			$rootScope.user = undefined;
			$state.go('login');
		});
	}

	$scope.getSubcategories = function (category, event) {
		if ($(event.target).hasClass("open")) {
			category.subcategorieshtml = "";
			$(event.target).removeClass("open");
			return;
		}
		console.log(event);
		console.log(category);
		category.subcategorieshtml = "<ul class='nav navbar-nav'>";
		for (var i = 0; i < category.childCategories.length; i++) {
			category.subcategorieshtml += "<li><a ng-click='setCategoryFilter(category.childCategories[" + i + "].id)'>" + category.childCategories[i].name;
			if (category.childCategories[i].childCategories.length > 0)
				category.subcategorieshtml += "<span ng-click='getSubcategories(category.childCategories[" + i + "], $event)'" +
					" style='font-size: 16px;' class='pull-right hidden-xs glyphicon glyphicon-plus-sign'></span>";
			category.subcategorieshtml += "</a></li>";
			category.subcategorieshtml += "<div compile='category.childCategories[" + i + "].subcategorieshtml'></div>";
		}
		category.subcategorieshtml += "</ul>";
		$(event.target).addClass("open");
		
	}


	var getContent = function() {
		userService.isUserLoggedIn().then(function(response) {
			$rootScope.user = response.data;
		}, function() {
			$rootScope.user = undefined;
		});
		customerCategoryService.getCustomerCategories().then(function (response) {
			$rootScope.customerCategories = response.data;
		});
		itemCategoryService.getItemCategories().then(function (response) {
			$rootScope.itemCategories = response.data;
		});
		itemService.getItems().then(function (response) {
			$rootScope.items = response.data;
		});
		saleService.getSales().then(function (response) {
			$rootScope.sales = response.data;
		});
	}

	getContent();

	$scope.setCategoryFilter = function (category) {
		$scope.categoryFilter = category;
	}

	$scope.addToCart = function (item) {
		item.count = 1;
		userService.addToCart(item).then(function(response) {
			alert('Added to cart.');
			console.log(response.data);
		});
	}
}])