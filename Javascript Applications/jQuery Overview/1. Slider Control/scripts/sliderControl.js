var sliderControl = function () {
    this.slides = [];
    this.currentSlide = 0;
    var self = this;

    $("#prev").on("click", function () {
        if (self.currentSlide > 0) {
            self.currentSlide -= 1;
            self.render();
        }
    });

    $("#next").on("click", function () {
        if (self.currentSlide < self.slides.length) {
            self.currentSlide += 1;
            self.render();
        }
    });

    setInterval(function () {
        $("#next").click();
    }, 5000);
};

sliderControl.prototype.addSlide = function (slide) {
    this.slides.push(slide);
};

sliderControl.prototype.render = function () {
    $("#currentSlide").html(this.slides[this.currentSlide]);
};

