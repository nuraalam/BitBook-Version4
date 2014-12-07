var app = angular.module('myApp', ['ngResource']);
app.controller('CalculatorController', ['$scope', function ($scope) {
    $scope.name = 'myApp';
    $scope.add = function () {
        $scope.sum = $scope.firstNumber + $scope.seccondNumber;
    };
}
]);