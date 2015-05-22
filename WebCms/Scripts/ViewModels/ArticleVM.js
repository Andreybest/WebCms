var articleApp = articleApp || {};
(function (articleContext) {

    var articleVM = {
        articles: ko.observableArray(),
        article: function ( Type, PageId, ArticleOrder, AnswerText, IsApproved) {
           // this.id = ko.observable(id),
            this.type = Type, //ko.observable(Type),
                this.pageId = PageId, //ko.observable(PageId),
                this.articleOrder = ArticleOrder, //ko.observable(ArticleOrder),
                this.answerText = AnswerText, //ko.observable(AnswerText),
                this.isApproved = IsApproved; // ko.observable(IsApproved);
        },
        test: ko.observable("testItem"),
        pageId: window.location.href.substring(window.location.href.lastIndexOf('/') + 1),
        initArticlesForPage: function (id) {
            //TODO Hardcoded URL
            $.ajax("https://localhost:5555/api/ArticleApi/" + id, {
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
        }

    }
    articleContext.articleVM = articleVM;

    //init articles page
    articleVM.initArticlesForPage(articleVM.pageId);
})(articleApp)