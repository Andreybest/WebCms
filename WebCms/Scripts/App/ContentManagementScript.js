$("#addTitle").click(function () {
    var newArt = new articleApp.articleVM.article(1, articleApp.articleVM.pageId, null, "TODO: write title text", false);
    pushToArticleArrays(newArt);
});
$("#addContent").click(function () {
    var newArt = new articleApp.articleVM.article(2, articleApp.articleVM.pageId, null, "TODO: write content text", false);
    pushToArticleArrays(newArt);
    
});

var pushToArticleArrays = function (newArt) {
    articleApp.articleVM.articles.push(newArt);
   // articleApp.articleVM.newArticles.push(newArt);
}