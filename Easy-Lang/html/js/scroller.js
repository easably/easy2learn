/*global d3:false */
'use strict';

var sentenceses = [], video,
    // view
    hRect = 20, wMargin = 20, spaceStep = 1, scrollerWidth = spaceStep * 4 * 2,
             wWidth = 1000, allLength = 0, coefZoom = 0.1;
var svg = d3.select('svg'), scrollers, rects, gRects,
    // for editor
    gRectsEditor, rectsEditor, gRectsEditorRoot;

var varsLogic = { doForceReplay: true };
var varsView = { viewGantt: false, current: "nothing yet" };

function set_wWidth() { wWidth = window.innerWidth || window.document.clientWidth || window.document.body.clientWidth; }

//#region reSize
window.onresize = reSize;

function reSize() {
    set_wWidth();
    svg.attr("width", wWidth);
    svg.attr("height", 1000);
    //            coefZoom = allLength >= wWidth ? wWidth/allLength : allLength/wWidth;
    coefZoom = (wWidth - wMargin) / allLength;
    if (coefZoom > 1) spaceStep = 1;
    else spaceStep = 0; //coefZoom;

    //console.log('spaceStep - ' + spaceStep); console.log('coefZoom - ' + coefZoom); console.log('allLength - ' + allLength); console.log('wWidth - ' + wWidth);

    gRects.attr("transform", function (d) {
        return "translate(" + (d.startTime * coefZoom) + ", 1)";
    });
    rects.attr("width", function (d) {
        return d.length * coefZoom - spaceStep;
    });
  
    // scrollers
    scrollerWidth = 4 * spaceStep * 2;
    scrollers.attr("width", scrollerWidth);
    moveScrollers();
    if (varsView.viewGantt) reSizeEditor();
}
//#endregion

//#region generation
function generate() {
  gRects = svg.selectAll('.sent-block')
          .data(sentenceses).enter()
          .append('g')
          .attr("class", "sent-block")
  //                    .attr("transform", function (d) {
  //                        return "translate(" + d.ps*coefZoom + ", 1)";
  //                    })
  ;
  rects = gRects.append('rect')
      .attr("height", hRect)
      .on('click', playSentence)
  //.attr("width", function (d) { return d.ln*coefZoom - 3; })
  ;
  generateMovers();
  if (varsView.viewGantt) generateEditor();
}

function generateMovers() {
    scrollers = svg.selectAll('rect .scroller')
        .data([{ i: 1, x: 0 }, { i: 2, x: 0 }])
        //.data([{ i: 1, x: 0 }, { i: 2, x: 0 }, { i: 3, x: 0 }])
        .enter().append('rect')
        .on('mouseup', doCorrectionForLengths)
        .attr('class', 'scroller')
        .attr('y', 1).attr('x', 0).attr('height', hRect);

    var dragSentenceBehavior = d3.behavior.drag()
      //.on('dragstart', function () { d3.event.sourceEvent.stopPropagation(); })
      .on('drag', resizeSentHandler);
    scrollers.call(dragSentenceBehavior);
}
    
//#endregion

//#region behavior
var activeSent = null;

function switchActiveSentence(el) {
  if (!activeSent) activeSent = d3.selectAll(".active");
  if (activeSent) {
    activeSent.classed("active", false);
    activeSent = d3.select(el);
    activeSent.classed("active", true);
    moveScrollers();
    if (varsView.viewGantt) reSizeEditor();
  }
}

function moveScrollers() {
  if (activeSent) {
    var x1 = d3.transform(getActiveSentG().attr("transform")).translate[0],
       x2 = parseFloat(activeSent.attr("width")); //  parseFloat(activeSent[0][0].attributes.width.value);
    var xShiftForScroller = scrollerWidth / 2;
    var switcher = function (d) {
        switch (d.i) {
            case 1: return x1 - xShiftForScroller;
            case 2: return x1 + x2 - scrollerWidth + xShiftForScroller;
            case 3: return x1 + x2 + spaceStep; //  - xShiftForScroller; third variant for shift is not legal!!!
        }
    };
    scrollers.attr("x", function (d) { return d.x = switcher(d); });
  }
}

function resizeSentHandler(d) {
    d.x += d3.event.dx;
    d3.select(this).attr('x', d.x);
    var delta = d3.event.dx / coefZoom;
    //console.log(activeSent.datum().length);
    //console.log(d3.event.dx);
    //console.log(delta);
    var sent = activeSent.datum(), doMovingOfScrollers = true;
    switch (d.i) {
        case 1: 
            sent.changeLength(sent.length - delta, true); //sent.startTime += delta;
            doMovingOfScrollers = false;
            varsLogic.doForceReplay = true; 
            break;
        
        case 2:
            sent.changeLengthAndShiftOther(sent.length + delta);
            varsLogic.doForceReplay = false;
            break;
        
        case 3: 
            sent.changeLength(sent.length + delta, false); // sent.length += delta;
            break;
    }
    //console.log('End - ' + activeSent.datum().length);
    reSize();
    if (doMovingOfScrollers) moveScrollers();
}

function getActiveSentG() { return d3.select(activeSent[0][0].parentNode); }
//#endregion

//#region editor
var gRectsEditorRootX, gRectsEditorRootY;
function generateEditor() {
    // root
    gRectsEditorRootX = 0; gRectsEditorRootY = hRect * 1.3;
    gRectsEditorRoot = svg.append('g').attr("class", "editorRoot")
        .attr("transform", "translate(" + gRectsEditorRootX + ", " + gRectsEditorRootY + ")");
    var dragEditorRoot = d3.behavior.drag().on('drag', dragEditorRootHandler);
    gRectsEditorRoot.call(dragEditorRoot);

    // for senetences

    centeredSent = getSentencesForEditor();

    gRectsEditor = gRectsEditorRoot.selectAll(".sent-block .editor")
        //.data(centeredSent).enter()
        .data(sentenceses).enter()
        .append('g')
        .attr("class", "sent-block editor")
        .on('click', playSentenceFromEditor)
    ;
    rectsEditor = gRectsEditor.append('rect').attr("height", hRect);
  //  rectsEditor = gRectsEditor.append('text').attr("y", hRect).text("adfgkljsafjgks sad;lfkjsalkf adslfkjsadpfokj dfg");
    // not yet using
    var gRectsEditorTexts = gRectsEditorRoot.selectAll("text")
       // .data(sentenceses).enter()
        .data(centeredSent).enter()
        .append('text')
        .attr('style', "font-size:10px")
        .attr("y", function (d) {
            return hRect * (d.ind + 1) * 2 - hRect/2;
        })
        .text("adfgkljsafjgks sad;lfkjsalkf adslfkjsadpfokj dfg")
        .on('click', playSentenceFromEditor)
    ;
}

var centeredSent = [];

function reSizeEditor() {
   // centeredSent = getSentencesForEditor();
    centeredSent = sentenceses;
    var scaler = d3.scale.linear()
        .domain([0, d3.sum(centeredSent, function (d) { return d.length; })])
        .range([0, wWidth*1.0]);
    var startTime = 0;
    gRectsEditor
        .filter(function (d) { return centeredSent.indexOf(d) !== -1; })
        .attr("transform", function (d, i) {
            var res = "translate(" + scaler(startTime) + ", " + hRect * i * 2 + ")";
            startTime += d.length;
            return res;
        });
        rectsEditor.attr("width", function (d) {
            return scaler(d.length);
        });

 //   gRectsEditor
 //       .data(centeredSent)
 //       .update().enter().exit()
 //       .filter(function (d) { return centeredSent.indexOf(d) !== -1; })
 //       .attr("transform", function (d, i) {
 //           return "translate(" + scaler(d.startTime) + ", " + hRect * i * 2 + ")";
 //   });
 //   rectsEditor.attr("width", function (d) {
 //      return d.length;
 //   });
 //  gRectsEditor.exit().remove();
}

function moveEditorToActive() {
    //wWidth
}

function dragEditorRootHandler() {
    if (gRectsEditorRootX + d3.event.dx < 0) {
        gRectsEditorRootX += d3.event.dx;
        d3.select(this).attr("transform", "translate(" + gRectsEditorRootX + ", " + gRectsEditorRootY + ")");
        //   var delta = d3.event.dx / coefZoom;    
    }
}

function getSentencesForEditor() {
    var centeredSent = []; //TODO: if count of all sentences will be 4 or 3 ! ))
    var iCentr = getIndexesForEditor5();
    var edCoef = wWidth/2  ;
    for (var i = 0; i < iCentr.length; ++i) {
        centeredSent[i] = sentenceses[iCentr[i]];
    }
    return centeredSent;
}

function getIndexesForEditor3() {
    var i = (activeSent ? activeSent.datum().ind : 0), // center of sentences
        allL = sentenceses.length;
    if (i <= 1)
        return [0, 1, 2];
    else if (i >= allL - 2)
        return [allL - 4, allL - 3, allL - 2];
    else return [i - 1, i, i + 1];
}

function getIndexesForEditor5() {
    var i = (activeSent ? activeSent.datum().ind : 0), // center of sentences
        allL = sentenceses.length;
    if (i <= 2)
        return [0, 1, 2, 3, 4];
    else if (i >= allL - 2)
        return [allL - 5, allL - 4, allL - 3, allL - 2, allL - 1];
    else return [i - 2, i - 1, i, i + 1, i + 2];
}
//#endregion

//#region ======= OOP =======
function Sent(index, startTime, length) {
    this.ERROR_1 = function () { throw new Error("Problem: Length for sentence could not be 'undefined'"); };

    if (length === undefined) this.ERROR_1(); // throw new Error(ERROR_1);
    this.length = length;
    this.ind = index;
    this.startTime = startTime;
}

Sent.prototype.changeLength = function (newLength, changePrev) {
    if (newLength === undefined) this.ERROR_1(); // throw new Error(ERROR_1);
    var delta = this.length - newLength;
    if (delta !== 0 && changePrev !== undefined) {
        if (changePrev) {
            var prev = this.getPrev();
            prev.length += delta;
            this.startTime += delta;
        }
        else { // need to change the startTime
            var next = this.getNext();
            next.length += delta;
            next.startTime -= delta;
        }
    }
    this.length = newLength;
};

Sent.prototype.changeLengthAndShiftOther = function (newLength) {
    if (newLength === undefined) this.ERROR_1(); // throw new Error(ERROR_1);
    var delta = this.length - newLength;
    this.length = newLength;
    if (delta !== 0 ) {
        var nexts = this.getNexts();
        var allOtherTime = d3.sum(nexts, function (d) { return d.length; });
        var scaler = d3.scale.linear().domain([0, allOtherTime]).range([0, allOtherTime + delta]);
        nexts.map(function (d) {
            d.length = scaler(d.length);
            d.startTime = d.getPrev().startTime + d.getPrev().length;
        });
    }
};

Sent.prototype.getPrev = function () {
    return sentenceses[this.ind - 1];
};

Sent.prototype.getNext = function () {
    return sentenceses[this.ind + 1];
};

Sent.prototype.getNexts = function () {
    return sentenceses.slice(this.ind+1);
};

function Video(length) {
    this.length = length;
}
//#endregion

//#region ======= EXTERNAL =======

//#region window.cntrl
function playSentence(d) {
    switchActiveSentence(this);
    if (window.cntrl)
        window.cntrl.play(d.ind);
}

function playSentenceFromEditor(selectedSentence) {
    var d_el = rects.filter(function (d) { return d.ind === selectedSentence.ind; });
    if (d_el[0][0])
        playSentence.call(d_el[0][0], d_el[0][0]);
}

function doCorrectionForLengths() {
    if (window.cntrl) {
        var lengths = '';
        for (var i = sentenceses.length - 1; i >= 0; --i) { lengths = sentenceses[i].length + ', ' + lengths; }
        //for (var snt in sentenceses) { lengths += sentenceses[snt].length + ', '; }
        //sentenceses.map(function (snt) { lengths += snt.length + ', '; });
        window.cntrl.doCorrectionForLengths(lengths, varsLogic.doForceReplay);
    }
}
//#endregion

//#region functions for calling from external envoroment
function asignSentences(sections) {
  if (gRects) gRects.remove();
  sentenceses = [], allLength = 0;
  sections.forEach(function (sc, i) {
    sentenceses.push(new Sent(i, allLength, sc));
    allLength += sc;
  });
  video = new Video(allLength, sentenceses);
  generate();
  reSize();
  moveScrollers();
}

function selectSentence(ind) {
  ind = parseInt(ind, 10);
  var el = rects.filter(function (d) { return d.ind === ind; });
  if (el[0][0])
    switchActiveSentence(el[0][0]);
}
//#endregion

//#endregion