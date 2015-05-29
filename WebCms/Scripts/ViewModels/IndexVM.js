var indexApp = indexApp || {};
(function (context) {
    var indexVM = {
        newPage: ko.observable(),
        page:  function (id, pageName, pageDescription) {
                this.id = ko.observable(id),
                this.pageName = ko.observable(pageName),
                this.pageDescription = ko.observable(pageDescription);
        },
        pages: ko.observableArray(),
        initPages: function () {
            $.ajax("api/PageApi", {
                type: "get",
                contentType: 'application/json; charset=utf-8',
                success: function(result) {
                    for (var i = 0; i < result.length; i++) {
                        indexVM.pages.push(result[i]);
                    }
                },
                error: function(result) {
                    notyModule.notyMsg("Something wrong happened when getting pages, probably you are not allowed to!", "error");
                }
            });
        },
        goToPageDetails: function (selectedPage) {
            window.location.assign(appUrl + "PageDetail/Index/" + selectedPage.id);
        },
        createNewPage: function() {
            var pgn = new indexVM.page();
            indexVM.newPage(pgn);
        },
        saveNewPage: function () {
            debugger;
            indexVM.pages.push(indexVM.newPage());
            $.ajax("https://localhost:5555/api/PageApi/", {
                type: "post",
                data: JSON.stringify(
                     indexApp.indexVM.newPage()
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    indexVM.newPage(null);
                    notyModule.notyMsg("Page saved successfully", "information");
                },
                error: function (result) {

                    notyModule.notyMsg("Something wrong happened when saving the new page!", "error");
                }
            });
        }

    }

    context.indexVM = indexVM;
})(indexApp)