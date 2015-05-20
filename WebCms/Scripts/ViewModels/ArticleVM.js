var articleApp = articleApp || {};
(function (articleContext) {

    var articleVM = {
        articles: ko.observableArray(),
        test: ko.observable("testItem"),
        initArticlesForPage: function(id) {
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
        }
    }

    articleContext.articleVM = articleVM;

})(articleApp)