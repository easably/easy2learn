var dlm = ' ## ';

// variant for group (not all senetences)
//function parse() { 
//  external_result = ''; 
//  $('span.talk-transcript__para__text').each( 
//    function (i, d) { 
//      external_result += $(d).find('span.talk-transcript__fragment').last().attr('data-time') + dlm + d.innerText + dlm + dlm;
//    })
//};

// variant for all senetences
function parse() {
  external_result = '';
  // variant for custom arragment of subtitles
  //fragments = $('span.talk-transcript__fragment').toArray();
  //for (var i = 0; i < fragments.length; i++) {
  //  var $f = $(fragments[i]);
  //  external_result += $f.attr('data-time') + dlm + fragments[i].innerText + dlm + dlm;
  //}
  $('span.talk-transcript__fragment').each(
    function (i, d) {
      external_result += $(d).attr('data-time') + dlm + d.innerText + dlm + dlm;
    });
}