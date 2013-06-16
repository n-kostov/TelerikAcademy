var Class = (function () {
    function createClass(properties) {
        var createFunction = function () {
            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            createFunction.prototype[prop] = properties[prop];
        }

        if (!createFunction.prototype.init) {
            createFunction.prototype.init = function () { }
        }

        return createFunction;
    }

    return {
        create: createClass,
    };
}());

var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    }
});

var FavoriteSitesBar = Class.create({
    init: function (folders, urls) {
        this.folders = folders;
        this.urls = urls;
    },

    render: function () {
        var container = document.querySelector("#sitesbar");
        var fragment = document.createDocumentFragment();
        var list = document.createElement("ul");
        var listItem;
        var currentUrl;

        for (var i = 0; i < this.urls.length; i++) {
            listItem = document.createElement("li");
            currentUrl = document.createElement("a");
            currentUrl.target = "_blank";
            currentUrl.textContent = this.urls[i].title;
            currentUrl.href = this.urls[i].url;
            listItem.appendChild(currentUrl);
            list.appendChild(listItem);
        }

        for (var i = 0; i < this.folders.length; i++) {
            var folderItem = document.createElement("li");
            folderItem.textContent = this.folders[i].title;
            var folderList = document.createElement("ul");

            for (var j = 0; j < this.folders[i].urls.length; j++) {
                listItem = document.createElement("li");
                currentUrl = document.createElement("a");
                currentUrl.target = "_blank";
                currentUrl.textContent = this.folders[i].urls[j].title;
                currentUrl.href = this.folders[i].urls[j].url;
                listItem.appendChild(currentUrl);
                folderList.appendChild(listItem);
                folderList.style.display = "none";
            }

            folderItem.appendChild(folderList);
            list.appendChild(folderItem);
        }

        list.addEventListener("click", function (ev) {
            if (ev.target.nodeName == "LI") {
                var insideList;
                var sibling = ev.target.previousElementSibling;
                while (sibling) {
                    insideList = sibling.children[0];
                    if (insideList.nodeName == "UL") {
                        insideList.style.display = "none";
                    }

                    sibling = sibling.previousElementSibling;
                }

                var sibling = ev.target.nextElementSibling;
                while (sibling) {
                    insideList = sibling.children[0];
                    if (insideList.nodeName == "UL") {
                        insideList.style.display = "none";
                    }

                    sibling = sibling.nextElementSibling;
                }

                insideList = ev.target.children[0];
                if (insideList) {
                    if (insideList.style.display == "none") {
                        insideList.style.display = "";
                        insideList.style.position = "absolute";
                        insideList.style.left = ev.clientX + "px";
                    }
                    else {
                        insideList.style.display = "none";
                    }
                }
            }
        }, false);

        fragment.appendChild(list);
        container.appendChild(fragment);
    }
});