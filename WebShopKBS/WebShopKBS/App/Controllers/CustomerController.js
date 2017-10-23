angular.module('customer.controllers', [])
.controller('customerController',
		['$scope','$rootScope', '$window', '$state', 'customerService',
			function ($scope, $rootScope, $window, $state, customerService) {
				console.log('customer controller');

				$scope.getProfile = function (username) {
					customerService.getProfile(username).then(function (response) {
						$scope.profile = response.data;
					});
				}

				$scope.getBill = function (order) {
					customerService.getBill(order).then(function (response) {
						$scope.bill = response.data;
					});
				}

				$scope.placeOrder = function (order) {
					customerService.placeOrder(order).then(function (response) {
						console.log(response.data);
					});
				}

				$scope.removeFromCart = function(item) {
					var index = $scope.cart.items.indexOf(item);
					$scope.cart.items.splice(index, 1);
					customerService.removeFromCart(item).then(function(response) {
						$scope.cart = response.data;
						console.log(response.data);
					});
				}

				$scope.getBill = function (creditsSpent) {
					console.log('check');
					var order = {};
					order.customerId = $rootScope.user.username;
					order.items = [];
					order.bill = 0;
					for (var i = 0; i < $scope.cart.items.length; i++) {
						var orderItem = {};
						orderItem.ItemId = $scope.cart.items[i].id;
						orderItem.index = i;
						orderItem.item = $scope.cart.items[i];
						orderItem.price = $scope.cart.items[i].price;
						orderItem.count = $scope.cart.items[i].count;
						orderItem.totalPrice = $scope.cart.items[i].price * $scope.cart.items[i].count;
						order.items.push(orderItem);
						order.bill += orderItem.totalPrice;
					}
					customerService.getBill(order, creditsSpent).then(function(response) {
						$rootScope.finalBill = response.data;
						$state.go('customer.bill');
					});
				}

				var getContent = function () {
					customerService.getCart().then(function (response) {
						$scope.cart = response.data;
						console.log(response.data);
					});
				}
				getContent();


			}])