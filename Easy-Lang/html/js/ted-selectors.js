;

var external_result = '';
var dlm = ' ## '; function parse() { $('span.talk-transcript__para__text').each(function (i, d) { external_result += $(d).find('span.talk-transcript__fragment').last().attr('data-time') + dlm + d.innerText + dlm; }) };
parse(); external_result;


var $all = $('span.talk-transcript__para__text'), $one = $all.first(), data = $one.find('span.talk-transcript__fragment').last().attr('data-time');
data;

//$('p.talk-transcript__para').each(
//$('span.talk-transcript__fragment').each(

//function parse() {  $('p.talk-transcript__para').each(function(i, item) { external_result += item.innerText; }) }



//$('span.talk-transcript__para__text').each(
//	function (i, d) {
//		res += $('span.talk-transcript__fragment').first().attr('data-time') + 
//			$('span.talk-transcript__fragment').last().attr('data-time') + 
//			d.innerText + '    ';
//	});
