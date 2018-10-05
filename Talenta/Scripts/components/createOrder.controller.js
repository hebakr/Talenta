(function () {
    "use strict";

    var app = angular.module('order-app');

    var orderEditorCtrl = function ($http) {
        var vm = this;

        vm.orderData = {
            date: new Date(),
            vendorId: '',
            items: [],
            discount: 0
        };

        vm.newItem = {
            product: null,
            unitPrice: 0,
            quantity: 1
        };

        vm.validItem = function() {
            return vm.newItem.product !== '' && vm.newItem.unitPrice > 0 && vm.newItem.quantity > 0;
        };

        vm.validForm = function() {
            return vm.orderData.date != null && vm.orderData.vendorId !== '' && vm.orderData.items.length > 0;
        };

        vm.addItem = function() {
            vm.orderData.items.push({
                productId: vm.newItem.product.id,
                productTitle: vm.newItem.product.title,
                unitPrice: vm.newItem.unitPrice,
                quantity: vm.newItem.quantity
            });

            vm.newItem = {
                product: null,
                unitPrice: 0,
                quantity: 1
            };

        };

        vm.calcTotal = function() {
            var sum = 0;
            for (var i = 0; i < vm.orderData.items.length; i++) {
                sum += vm.orderData.items[i].unitPrice * vm.orderData.items[i].quantity;
            }

            return sum - (vm.orderData.discount / 100 * sum);
        };

        vm.productSelected = function () {
            vm.newItem.unitPrice = vm.newItem.product.price;
        };

        vm.saveOrder = function () {
            console.log('saving....');
            $http.post('/home/CreateOrder',
                vm.orderData).then(
                function () {
                    location.href = '/';
                });
        };
    };

    orderEditorCtrl.$inject = ['$http'];

    app.component('createOrder', {
        templateUrl: '/Scripts/components/createOrder.component.html',
        controller: orderEditorCtrl,
        controllerAs: 'vm',
        bindings: {
            model: '<'
        }
    });

})();
