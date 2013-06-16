if (!Object.create) {
    Object.create = function (obj) {
        function f() { };
        f.prototype = obj;
        return new f();
    }
}


Object.prototype.extend = function (properties) {
    function f() { };
    f.prototype = Object.create(this);
    for (var prop in properties) {
        f.prototype[prop] = properties[prop];
    }

    f.prototype._super = this;
    return new f();
}

var Image = {
    init: function (title, thumbnailURL, largeImageURL) {
        this.title = title;
        this.thumbnailURL = thumbnailURL;
        this.largeImageURL = largeImageURL;
    }
};

var Slider = {
    init: function (images) {
        var self = this;
        self.images = images;
        self.enlarged = images[0];
        self.current = 0;
        var content = document.querySelector("#content");
        var enlargedImage = document.createElement("img");
        enlargedImage.src = this.enlarged.largeImageURL;
        enlargedImage.style.width = "520px";
        enlargedImage.style.height = "300px";
        enlargedImage.style.display = "block";
        enlargedImage.style.margin = "0 auto";
        content.appendChild(enlargedImage);

        var sliderControl = document.querySelector("#slider");
        sliderControl.style.height = "200px";
        var prevButton = document.createElement("button");
        prevButton.id = "prev";
        prevButton.textContent = "<";
        prevButton.style.cssFloat = "left";
        prevButton.addEventListener("click", function () {
            if (self.current !== 0) {
                self.current -= 1;
                var currentImage = document.querySelector("#thumbnail");
                currentImage.src = self.images[self.current].thumbnailURL;
            }
        }, false);
        sliderControl.appendChild(prevButton);

        var initialImage = document.createElement("img");
        initialImage.id = "thumbnail";
        initialImage.src = images[0].thumbnailURL;
        initialImage.style.cssFloat = "left";
        initialImage.addEventListener("click", function () {
            var enlargedImage = document.querySelector("#content img");
            self.enlarged = self.images[self.current];
            enlargedImage.src = self.enlarged.largeImageURL;
        }, false);
        sliderControl.appendChild(initialImage);

        var nextButton = document.createElement("button");
        nextButton.id = "next";
        nextButton.textContent = ">";
        nextButton.addEventListener("click", function () {
            if (self.current < self.images.length - 1) {
                self.current += 1;
                var currentImage = document.querySelector("#thumbnail");
                currentImage.src = self.images[self.current].thumbnailURL;
            }
        }, false);
        sliderControl.appendChild(nextButton);
    }
};