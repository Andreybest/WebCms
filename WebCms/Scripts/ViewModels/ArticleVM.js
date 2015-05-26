var articleApp = articleApp || {};
(function (articleContext) {

    var articleVM = {
        articleNumber: 0,
        articles: ko.observableArray(),
        article: function (Type, PageId, ArticleOrder, AnswerText, IsApproved) {
            // this.id = ko.observable(id),
            this.Type = Type,//ko.observable(Type),
            this.PageId = PageId,// ko.observable(PageId),
            this.ArticleOrder = ArticleOrder,//ko.observable(ArticleOrder),
            this.AnswerText = AnswerText,//ko.observable(AnswerText),
            this.IsApproved = IsApproved; // ko.observable(IsApproved);
        },
        test: ko.observable("testItem"),
        pageId: window.location.href.substring(window.location.href.lastIndexOf('/') + 1),
        initArticlesForPage: function (id) {
            //TODO Hardcoded URL
            $.ajax("https://localhost:5555/api/ArticleApi/" + id, {
                type: "get",
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    articleVM.articles([]);
                    for (var i = 0; i < result.length; i++) {
                        articleVM.articles.push(result[i]);
                    }
                    articleVM.articleNumber = articleVM.articles.length;
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when getting articles!", "error");
                }
            });
        },
        saveArticle: function (id) {
            $.ajax("https://localhost:5555/api/ArticleApi/" + id, {
                type: "put",
                data: JSON.stringify(
                     articleApp.articleVM.articles()
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    //   articleVM.newArticles([]);
                    notyModule.notyMsg("Articles updated successfully", "information");
                },
                error: function (result) {

                    notyModule.notyMsg("Something wrong happened when saving articles!", "error");
                }
            });
        }

    }
    articleContext.articleVM = articleVM;

    //init articles page
    articleVM.initArticlesForPage(articleVM.pageId);
})(articleApp)