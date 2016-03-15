var numberCate = global;
var app = angular.module('photoShow', ['angularUtils.directives.dirPagination']);

app.controller('photoList', function ($scope, $http) {
    $scope.images = []; //declare an empty array
    $http.get(window.location.origin + "/api/cate/" + numberCate).success(function (response) {
        $scope.images = response;  //ajax request to fetch data into $scope.data
    });
});