var articleApp = articleApp || {};
(function (articleContext) {

    var articleVM = {
        articles: ko.observableArray(),
        test: ko.observable("testItem"),
        pageId: window.location.href.substring(window.location.href.lastIndexOf('/') + 1),
        initArticlesForPage: function (id) {
            $.ajax("http://localhost:64593/api/ArticleApi/" + id, {
                type: "get",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    for (var i = 0; i < result.length; i++) {
                        articleVM.articles.push(result[i]);
                    }
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when getting articles!", "error");
                }
            });
        },
        goToPageDetails: function (selectedPage) {
            window.location.assign(appUrl + "PageDetail/Index/" + selectedPage.id);
        }
    }
    articleContext.articleVM = articleVM;

    //init articles page
    articleVM.initArticlesForPage(articleVM.pageId);
})(articleApp)