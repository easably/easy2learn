$('a').each(function (i, e) {
  //console.log(e);
  $(e).attr('href', 'null')
  $(e).click(function (ob) {
    console.log($(ob).attr('href'))
  })
})