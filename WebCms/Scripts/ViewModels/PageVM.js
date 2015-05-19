var pageApp = pageApp || {};
(function (context) {


    var pageVM = {
        test: ko.observable("testtttt"),
        pages: ko.observableArray(),

        initPages: function() {
            $.ajax("api/Page", {
               type: "get",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                  for (var i = 0; i < result.length; i++) {
                      pageVM.pages.push(result[i]);
                  }
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when getting pages, probably you are not allowed to!", "error");
                }
            });
        }
    }


    context.pageVM = pageVM;
    ko.applyBindings(pageVM);

})(pageApp)