

$("#addTitle").click(function () {
    $("#rootElement").append("<h2 id='child'>Title element</h2>");
    debugger;
    var newArt = new articleApp.articleVM.article(1, articleApp.articleVM.pageId, null, "TODO: write text", false);
    articleApp.articleVM.articles.push(newArt);
});
$("#addContent").click(function () {
    $("#rootElement").append("<p id='child'>Paragraf element</p>");
    articleApp.articleVM.articles.push(new articleApp.articleVM.article(2, articleApp.articleVM.pageId, null, "TODO: write text", false));
});