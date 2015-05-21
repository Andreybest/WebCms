var indexApp = indexApp || {};
(function (context) {
    var indexVM = {
        pages: ko.observableArray(),
        initPages: function () {
            $.ajax("api/PageApi", {
                type: "get",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        indexVM.pages.push(result[i]);
                    }
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when getting pages, probably you are not allowed to!", "error");
                }
            });
        }
    }

    context.indexVM = indexVM;
})(indexApp)