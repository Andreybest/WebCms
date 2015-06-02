$("#addTitle").click(function () {
    var newArt = new articleApp.articleVM.article(0,1, articleApp.articleVM.pageId, null, "TODO: write title text", null);
    pushToArticleArrays(newArt);
});
$("#addContent").click(function () {
    var newArt = new articleApp.articleVM.article(0,2, articleApp.articleVM.pageId, null, "TODO: write content text", null);
    pushToArticleArrays(newArt);
});

var pushToArticleArrays = function (newArt) {
    articleApp.articleVM.articles.push(newArt);
    articleApp.articleVM.newArticles.push(newArt);
}