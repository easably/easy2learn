function parse() {
  external_result = '';
  $('#articleTranscript p').each(
  function (i, d) {
    external_result += $(d).text() + ' ';
  });
  return external_result;
 // having problem with the end of sentence external_result = $('#articleTranscript').text();
}