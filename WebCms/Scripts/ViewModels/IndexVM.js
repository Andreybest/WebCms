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
            window.location.assign(appUrl + "PageDetail/Index/" + selectedPage.Id);
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
        },
        deletePage: function (selectedPage) {
            noty({
                layout: 'center',
                text: 'Are you sure?',
                buttons: [
                    {
                        addClass: 'btn btn-primary', text: 'Yes', onClick: function ($noty) {

                            $.ajax("https://localhost:5555/api/PageApi/", {
                                type: "delete",
                                data: JSON.stringify(
                                    selectedPage
                                ),
                                contentType: 'application/json; charset=utf-8',
                                success: function (result) {
                                    indexVM.pages.remove(selectedPage);
                                    notyModule.notyMsg("Page deleted successfully", "information");
                                },
                                error: function (result) {
                                    notyModule.notyMsg("Something wrong happened when deleting the page!", "error");
                                }
                            });

                            $noty.close();
                           
                        }
                    },
                    {
                        addClass: 'btn btn-danger', text: 'Cancel', onClick: function ($noty) {
                            $noty.close();
                            
                        }
                    }
                ]
            });
       
        },
        savePage:function(selectedPage) {
            $.ajax("https://localhost:5555/api/PageApi/" + selectedPage.Id, {
                type: "put",
                data: JSON.stringify(
                    selectedPage
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    notyModule.notyMsg("Page updated successfully", "information");
                },
                error: function (result) {

                    notyModule.notyMsg("Something wrong happened when saving page!", "error");
                }
            });
        }

    }

    context.indexVM = indexVM;
})(indexApp)