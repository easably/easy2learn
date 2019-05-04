function parse() {
    //  external_result = ($('div.themeBreadcrumb a:contains(hi-tech)').length > 0).toString();
    external_result = "anon";
    var element = $('div.themeBreadcrumb a:contains(hi-tech)')[0];
    if (element) {
        external_result = element.text;
    }
    return external_result;
}