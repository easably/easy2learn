'use strict';

//#region 
function openLink() {
   // console.log("openLink");
   // console.log(this.attributes.data.value);
    if (window.cntrl)
        window.cntrl.openVideoUnit(this.attributes.data.value);
    //else alert(this.attributes.data.value);
}

function openLinkLesson(event) {
    var path = this.parentElement.attributes.data.value;
    event.cancelBubble = true;
    if (window.cntrl)
        window.cntrl.openLessonUnit(path);
    //console.log(this.innerText + " for " + path);
    //console.log(event);
}
//#endregion

function fillWithClear(data) {
    window.document.body.innerText = '';
    fill(data);
}

function fill(data) {
    try {
        var dataObj = JSON.parse(data);
        for (var i = 0; i < dataObj.length; i++) {
            createItem(dataObj[i]);
        }
    }
    catch (e) {
        console.log("Problem with calling: JSON.parse(data);");
        console.log("function 'fill' was called with data:");
        console.log(data);
    }

}

function createItem(d) {
    var div = document.createElement("div");
    div.className = "vdItem";
    div.onclick = openLink;
    div.__data__ = d;
    div.setAttribute('data', d.path);
    if (d.img) {
        var img = document.createElement("img");
        img.src = d.path + d.img;
        div.appendChild(img);
    }
    var h = document.createElement("h3");
    h.innerText = (d.title && d.title !== '') ? d.title : 'Title for article not found';
    div.appendChild(h);

    var prefix = window.location.origin !== "file://" ? "/" : "";

    if (d.lesson) {
        var divLess = document.createElement("div");
        divLess.className = "lesson";
        divLess.onclick = openLinkLesson;

        var imgIcon = document.createElement("img");
        imgIcon.className = "icon";
        imgIcon.src = prefix + "html/assets/img/tutor.png";
        divLess.appendChild(imgIcon);

        h = document.createElement("h4");
        h.innerText = 'Run lesson';
        div.appendChild(h);
        divLess.appendChild(h);

        div.appendChild(divLess);
    }
    window.document.body.appendChild(div);
}

function fade(stl) {
    (stl.opacity -= 0.05) < 0 ? stl.display = "none" : setTimeout(fade, 20, stl);
}
