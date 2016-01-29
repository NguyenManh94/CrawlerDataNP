//Lọc theo từng cate để lấy ra từng bài riêng biết;
var app = angular.module('PageContent', ['angularUtils.directives.dirPagination', 'ngSanitize']);
var sc = "";
if (Request.QueryString("scate").Count > 0) {
    sc = Request.QueryString("scate");
}
else {
    window.location.assign(window.location.origin + "/Home/Index");
}
app.controller('PageUnit', function ($scope, $http) {
    $scope.posts = []; //declare an empty array
    $http.get(window.location.origin + "/CateData/GetCateCdt/" + sc).success(function (response) {
        $scope.posts = response;  //ajax request to fetch data into $scope.data
    });
    $http.get(window.location.origin + "/PrImz/GetNewPosts").success(function (response1) {
        $scope.newposts = response1;
    });
    $http.get(window.location.origin + "/PrImz/GetTopPost").success(function (response2) {
        $scope.topposts = response2;
    });
    $http.get(window.location.origin + "/PrImz/GetTopMember").success(function (responsem) {
        $scope.topmb = responsem;
    });
});