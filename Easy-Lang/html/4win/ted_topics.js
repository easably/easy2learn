var dlm = ' ## ';

external_result = '';
$('.topics__list__topic').each(function (i, e) {
  var $e = $(e);
  var $a = $e.find('a');
  var txt = $a.text();
  var hrf = $a.attr('href');
  var allCount = $e.text().substr(txt.length); //  + 2);
  var count = allCount.split(' ')[0];

  external_result += hrf + dlm + txt + ' (' + count + ')' + dlm + dlm;
});


/*
var $e = $(e);

var $e = $($('.topics__list__topic')[0]);

var $a = $e.find('a');
var txt = $a.text();
var hrf = $a.attr('href');
var allCount = $e.text().substr(txt.length + 2); // !!! in .net ......substr(txt.length);
var count = allCount.split(' ')[0];

count;

*/

