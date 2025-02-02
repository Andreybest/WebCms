﻿var articleApp = articleApp || {};
(function (articleContext) {

    var articleVM = {
        articleNumber: 0,
        articles: ko.observableArray(),
        newArticles: ko.observableArray(),
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
        saveArticle: function () {
            $.ajax("https://localhost:5555/api/ArticleApi/", {
                type: "post",
                data: JSON.stringify(
                    articleApp.articleVM.newArticles()
                    //  articleApp.articleVM.articles()
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    articleVM.newArticles([]);
                    //logic to deactivate the intem save button
                    for (var i = 0; i < articleVM.articles().length; i++) {
                        articleVM.articles()[i].ArticleOrder = null;

                    }
                    $(".btn").prop('disabled', false);
                    $("#saveArticlesBtn").hide();

                    notyModule.notyMsg("Articles updated successfully", "information");
                },
                error: function (result) {

                    notyModule.notyMsg("Something wrong happened when saving articles!", "error");
                }
            });
        },
        saveThisArticle: function (selectedArticle) {
            $.ajax("https://localhost:5555/api/ArticleEditApi/" + selectedArticle.Id, {
                type: "put",
                data: JSON.stringify(
                   selectedArticle
                ),
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    notyModule.notyMsg("Article updated successfully", "information");
                },
                error: function (result) {

                    notyModule.notyMsg("Something wrong happened when saving this article!", "error");
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
                    if (articleVM.newArticles().length > 0) {
                        for (var i = 0; i < articleVM.newArticles().length; i++) {
                            if (articleVM.newArticles()[i] == selectedArticle) {
                                articleVM.newArticles.remove(selectedArticle);
                                if (articleVM.newArticles().length === 0) {
                                    $("#saveArticlesBtn").hide();
                                }
                            }
                        }
                    }

                    notyModule.notyMsg("Articles deleted successfully", "information");
                },
                error: function (result) {
                    notyModule.notyMsg("Something wrong happened while deleting the article!", "error");
                }
            });
        }

    }

    articleContext.articleVM = articleVM;

    //init articles page
    articleVM.initArticlesForPage(articleVM.pageId);

})(articleApp)