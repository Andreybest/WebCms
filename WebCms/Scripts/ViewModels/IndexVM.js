var indexApp = indexApp || {};
(function (context) {
    var indexVM = {
        newPage: ko.observable(),
        page:  function (id, pageName, pageDescription) {
            this.id = id, // ko.observable(id),
                this.pageName = pageName, // ko.observable(pageName),
                this.pageDescription = pageDescription; // ko.observable(pageDescription);
        },
        pages: ko.observableArray(),
        initPages: function () {
            $("#savePageBtn").prop('disabled', true);
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
        emptyPageCreationForm: function () {
            $("#savePageBtn").prop('disabled', true);
            $("#pageTitle").val(null);
            $("#pageDescription").val(null);
        },
        createNewPage: function () {
            var pageTitle = $("#pageTitle").val();
            var pageDescription = $("#pageDescription").val();
            var pgn = new indexVM.page(0 , pageTitle, pageDescription);
            indexVM.newPage(pgn);
        },
        saveNewPage: function () {
            indexVM.createNewPage();
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