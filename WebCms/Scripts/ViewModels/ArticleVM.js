var articleApp = articleApp || {};
(function (articleContext) {

    var articleVM = {
        articleNumber: 0,
        isSaveEnabled: ko.observable(false),
        articles: ko.observableArray(),
        article: function (Id, Type, PageId, ArticleOrder, AnswerText, IsApproved) {
                this.Id = Id,
                this.Type = Type,
                this.PageId = PageId,
                this.ArticleOrder = ArticleOrder,
                this.AnswerText = AnswerText,
                this.IsApproved = IsApproved;
        },
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
        },
        deleteArticle: function (selectedArticle) {
            $.ajax("https://localhost:5555/api/ArticleApi/", {
                type: "delete",
                data: JSON.stringify(
                    selectedArticle
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    articleVM.articles.remove(selectedArticle);
                    notyModule.notyMsg("Articles deleted successfully", "information");
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened when saving articles!", "error");
                }
            });
        }

    }
   /* var subscribe = articleVM.articles.subscribe(function (newValue) {
        if (newValue != undefined) {
            for (var i = 0; i < newValue.length; i++) {
                newValue[i].subscribe(function (values) {
                    alert("ssasss");
                });
            }
        }
    });*/

    /*rticleVM.articles.subscribe(function () {
        ko.utils.arrayForEach(articleVM.articles, function (item) {
            item.subscribe(function () {
                alert("da");
                //code to fire when selected changes
            });
        });
    });
*/
    articleContext.articleVM = articleVM;

    //init articles page
    articleVM.initArticlesForPage(articleVM.pageId);

})(articleApp)