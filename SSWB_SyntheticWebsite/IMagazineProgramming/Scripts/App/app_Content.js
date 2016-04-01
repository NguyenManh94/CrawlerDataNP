/*chú ý postId lấy được từ request ở trang PostContent
var app = angular.module('PageContent', []);

app.controller('PageContentView', function ($scope, $http) {
    $scope.postcontent = []; //declare an empty array
    $http.get(window.location.origin + "/PrImz/GetPostContent?postId=" + postId).success(function (response) {
        $scope.postcontent = response;  //ajax request to fetch data into $scope.data
    });
})*/


var app = angular.module('PageContent', ['ngSanitize']);

app.controller('PageUnit', function ($scope, $http) {
    //$scope.postcontent = []; //declare an empty array
    $http.get(window.location.origin + "/api/PostContent/" + postId).success(function (response) {
        $scope.postcontent = response;  //ajax request to fetch data into $scope.data

        ///*Code excute binding Data type HTML .... Same same Html_Decode*/
        //var html = response.ContentView;  //ajax request to fetch data into $scope.data
        //var txt = document.createElement("textarea");
        //txt.innerHTML = html;
        //$scope.content_view = txt.value;
        $scope.content_view = response.ContentView;
    });
    $http.get(window.location.origin + "/api/CommentCvrt/" + postId).success(function (responsex) {
        $scope.datacm = responsex;
        $scope.comment_view = responsex[postId].ContentComment;
        //$scope.bindingComment = responsex.ContentComment;
    });
    //Get 5 Post New
    $http.get(window.location.origin + "/PrImz/GetNewPosts").success(function (response1) {
        $scope.newposts = response1;
    });
    //Get Top 5 Post Max Viewd
    $http.get(window.location.origin + "/PrImz/GetTopPost").success(function (response2) {
        $scope.topposts = response2;
    });
    $http.get(window.location.origin + "/CateData/GetCate").success(function (response3) {
        $scope.catemenu = response3;
    });
    $http.get(window.location.origin + "/PrImz/GetTopMember").success(function (responsem) {
        $scope.topmb = responsem;
    });
})

app.filter('trusted', ['$sce', function ($sce) {
    var div = document.createElement('div');
    return function (text) {
        div.innerHTML = text;
        return $sce.trustAsHtml(div.textContent);
    };
}])