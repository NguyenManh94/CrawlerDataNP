//var numberCate = global;
var app = angular.module('PageContent', ['angularUtils.directives.dirPagination', 'ngSanitize']);

app.controller('PageUnit', function ($scope, $http) {
    $scope.posts = []; //declare an empty array
    $http.get(window.location.origin + "/api/PostContent").success(function (response) {
        $scope.posts = response;  //ajax request to fetch data into $scope.data
    });
    $http.get(window.location.origin + "/PrImz/GetNewPosts").success(function (response1) {
        $scope.newposts = response1;
    });
    $http.get(window.location.origin + "/PrImz/GetTopPost").success(function (response2) {
        $scope.topposts = response2;
    });
    $http.get(window.location.origin + "/CateData/GetCate").success(function (response3) {
        $scope.catedemo = response3;
    });
    $http.get(window.location.origin + "/PrImz/GetTopMember").success(function (responsem) {
        $scope.topmb = responsem;
    });
});