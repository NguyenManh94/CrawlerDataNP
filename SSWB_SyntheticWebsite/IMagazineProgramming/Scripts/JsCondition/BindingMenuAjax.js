$(document).ready(function () {
    $.getJSON(window.location.origin + '/CateData/GetCate', function (data) {
        var content = "";
        var content = "";
        for (var i = 0; i < data.length; i++) {
            content += "<li><a href='#' class='dropdown-toggle' data-toggle='dropdown' data-hover='dropdown' data-delay='100'>" + data[i].NameXCategory + "<b class='caret'></b></a><ul class='dropdown-menu'>";
            for (var j = 0; j < data[i].lstScate.length; j++) {
                var xx = parseInt(data[i].lstScate[j].IdScate);
                content += "<li><a href='" + window.location.origin + "/Home/ViewHaveCate?scate=" + xx + "'>" + data[i].lstScate[j].NameSCategory + "</a></li>";
                if (j == 2) {
                    content += "<li class='divider'></li>";
                }
            }
            content += "</ul></li>";
        }
        $('#bindMenu').html(content);
    });
});
























//$.ajax({
//    type: 'GET',
//    url: window.location.origin + '/CateData/GetCate',
//    success: function (data) {
//        var content = "";
//        $.each(data, function (key, val) {
//            content += "<li><a href='#' class='dropdown-toggle' data-toggle='dropdown' data-hover='dropdown' data-delay='100'>" + val.NameXCategory + "<b class='caret'></b></a><ul class='dropdown-menu'>";
//            $.each(data.lstScate, function (key2, val2) {
//                content += "<li><a href='#'>" + val2.NameSCategory + "</a></li>";
//            });
//            content += "</ul></li>";
//        });
//        content += "";
//        $('#bindMenu').html(content);
//    }
//});
