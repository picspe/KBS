angular.module('webShopApp', ['ui.router', 'ngSanitize',
	'employee.services', 'employee.controllers',
	'manager.services', 'managerItem.services', 'managerItemCategory.services', 'customerCategory.services', 'manager.controllers', 
	'user.services', 'user.controllers',
	'customer.services', 'customer.controllers'])
.config(function($stateProvider, $urlRouterProvider) {

	$urlRouterProvider.otherwise('/');

	$stateProvider
		.state('home',
		{
			url: '/',
			templateUrl: 'app/Templates/index.html',
			controller: 'userController'
		})
		.state('login',
		{
			url: '/login',
			templateUrl: 'app/Templates/login.html',
			controller: 'userController'
		})
		.state('register',
		{
			url: '/register',
			templateUrl: 'app/Templates/register.html',
			controller: 'userController'
		})
		.state('customer',
		{
			url: '/customer',
			templateUrl: 'app/Templates/customer.html',
			controller: 'customerController'
		})
		.state('customer.profile',
		{
			url: '/customer/profile',
			templateUrl: 'app/Templates/Customer/profile.html',
			controller: 'customerController'
		})
		.state('customer.cart',
		{
			url: '/cart',
			templateUrl: 'app/Templates/Customer/cart.html',
			controller: 'customerController'
		})
		.state('customer.bill',
		{
			url: '/order',
			templateUrl: 'app/Templates/Customer/order.html',
			controller: 'customerController'
		})
		.state('employee',
		{
			url: '/employee',
			templateUrl: 'app/Templates/employee.html',
			controller: 'employeeController'
		})
		.state('employee.updateOrder',
		{
			url: '/orders',
			templateUrl: 'app/Templates/Employee/order.html',
			controller: 'employeeController'
		})
		.state('employee.restock',
		{
			url: '/restock',
			templateUrl: 'app/Templates/Employee/restock.html',
			controller: 'employeeController'
		})
		.state('manager',
		{
			url: '/manager',
			templateUrl: 'app/Templates/manager.html',
			controller: 'managerController'
		})
		.state('manager.itemCategories',
			{
				url: '/itemCategories',
				templateUrl: 'app/Templates/Manager/itemCategories.html',
				controller: 'managerController'
		})
		.state('manager.customerCategories',
			{
				url: '/customerCategories',
				templateUrl: 'app/Templates/Manager/customerCategories.html',
				controller: 'managerController'
		})
		.state('manager.items',
			{
				url: '/items',
				templateUrl: 'app/Templates/Manager/items.html',
				controller: 'managerController'
		})
		.state('manager.sales',
			{
				url: '/sales',
				templateUrl: 'app/Templates/Manager/sales.html',
				controller: 'managerController'
		})
		;
	})
	.directive('compile', ['$compile', function ($compile) {
		return function (scope, element, attrs) {
			scope.$watch(
				function (scope) {
					// watch the 'compile' expression for changes
					return scope.$eval(attrs.compile);
				},
				function (value) {
					// when the 'compile' expression changes
					// assign it into the current DOM
					element.html(value);

					// compile the new DOM and link it to the current
					// scope.
					// NOTE: we only compile .childNodes so that
					// we don't get into infinite loop compiling ourselves
					$compile(element.contents())(scope);
				}
			);
		};
	}]);