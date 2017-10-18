angular.module('webShopApp', ['ui.router',
	'customer.services', 'customer.controllers',
	'employee.services', 'employee.controllers',
	'manager.services', 'managerItem.services', 'managerItemCategory.services', 'manager.controllers',
	'user.services', 'user.controllers'])
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
			templateUrl: 'app/Templates/index.html',
			controller: 'customerController'
		})
		.state('customer.shop',
		{
			url: '/customer/shop',
			templateUrl: 'app/Templates/index.html',
			controller: 'customerController'
		})
		.state('customer.cart',
		{
			url: '/customer/cart',
			templateUrl: 'app/Templates/index.html',
			controller: 'customerController'
		})
		.state('employee',
		{
			url: '/employee',
			templateUrl: 'app/Templates/index.html',
			controller: 'employeeController'
		})
		.state('manager',
		{
			url: '/manager',
			templateUrl: 'app/Templates/index.html',
			controller: 'managerController'
		});
});