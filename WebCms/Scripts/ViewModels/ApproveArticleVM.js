var approveArticleApp = approveArticleApp || {};
(function (approveArticleContext) {

    var approveArticleVM = {
        articlesToApprove: ko.observableArray(),
        articleNumber: ko.observable(),
        initArticlesForPage: function () {
            $.ajax("https://localhost:5555/api/ArticleApi/", {
                type: "get",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    approveArticleVM.articlesToApprove([]);
                    for (var i = 0; i < result.length; i++) {
                        approveArticleVM.articlesToApprove.push(result[i]);
                    }
                    approveArticleVM.articleNumber(approveArticleVM.articlesToApprove().length);
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when getting articles!", "error");
                }
            });
        },
        approveArticle: function (selectedArticle) {
            selectedArticle.IsApproved = true;
            $.ajax("https://localhost:5555/api/ArticleApi/" + selectedArticle.Id, {
                type: "put",
                data: JSON.stringify(
                    selectedArticle
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    approveArticleVM.articlesToApprove.remove(selectedArticle);
                    notyModule.notyMsg("Approved successfully, now that article will be public.", "information");
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when approving that article!", "error");
                }
            });
        },
        rejectArticle: function (selectedArticle) {
            selectedArticle.IsApproved = false;
            $.ajax("https://localhost:5555/api/ArticleApi/" + selectedArticle.Id, {
                type: "put",
                data: JSON.stringify(
                    selectedArticle
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    approveArticleVM.articlesToApprove.remove(selectedArticle);
                    notyModule.notyMsg("Rejected successfully, that article will never be published.", "information");
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when rejecting that article!", "error");
                }
            });
        }
    }

    approveArticleContext.approveArticleVM = approveArticleVM;

    //init articles page
    approveArticleVM.initArticlesForPage();
})(approveArticleApp)