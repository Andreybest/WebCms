var pageApp = pageApp || {};
(function (context) {





    var pageVM = {
         test: ko.observable("testtttt")
    }


    context.pageVM = pageVM;
    ko.applyBindings(pageVM);

})(pageApp)