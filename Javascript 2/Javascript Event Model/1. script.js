window.onload = function () {
    var slide = document.getElementById("slide-img");
    var imgArray = ["images/pic1.jpg", "images/pic2.jpg", "images/pic3.jpg", "images/pic4.jpg"];
    var i = 0;
    var l = imgArray.length;
    var left = document.getElementById("left-arrow");
    var right = document.getElementById("right-arrow");
    console.log(slide.getAttribute("src"));


    attachEventHandler(left, 'click', prev)
    attachEventHandler(right, 'click', next)

    function prev() {
        var src = slide.getAttribute("src");
        var index = imgArray.indexOf(src);
        if (index == 0) {
            index = l
        };
        slide.setAttribute("src", imgArray[index - 1]);
    }

    function next() {
        var src = slide.getAttribute("src");
        var index = imgArray.indexOf(src);
        if (index == l - 1) {
            index = -1
        };
        slide.setAttribute("src", imgArray[index + 1]);
    }

    setInterval(next, 3000);
}

function attachEventHandler(element, eventType, eventHandler) {
    if (document.attachEvent) {
        element.attachEvent("on" + eventType, eventHandler);
    } else if (document.addEventListener) {
        element.addEventListener(eventType, eventHandler, false);
    } else {
        element["on" + eventType] = eventHandler;
    }
}