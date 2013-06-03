var school = (function () {

    function School(name, location, numberOfCourses, specialty) {
        var courses = [];

        this.addCourse = function (title, startDate, totalStudents) {
            var newItem = new Course(title, startDate, totalStudents);
            courses.push(newItem);
            return newItem;
        };

        this.serialize = function () {
            var thisItem = {
                name: name,
                location: location,
                numberOfCourses: numberOfCourses,
                specialty: specialty,
                courses: courses
            };
            if (courses.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < courses.length; i += 1) {
                    var serItem = courses[i].serialize();
                    serializedItems.push(serItem);
                }
                thisItem.courses = serializedItems;
            }
            return thisItem;
        }
    }

    function Course(title, startDate, totalStudents) {
        var students = [];

        this.addStudent = function (firstname, lastname, grade, mark) {
            var newItem = new Student(firstname, lastname, grade, mark);
            students.push(newItem);
            return newItem;
        };

        this.serialize = function () {
            var thisItem = {
                title: title,
                startDate: startDate,
                totalStudents: totalStudents,
                students: students
            };
            if (students.length > 0) {
                var serializedItems = [];
                for (var i = 0; i < students.length; i += 1) {
                    var serItem = students[i].serialize();
                    serializedItems.push(serItem);
                }
                thisItem.students = serializedItems;
            }
            return thisItem;
        }
    }

    function Student(firstname, lastname, grade, mark) {

        this.serialize = function () {
            var thisItem = {
                firstname: firstname,
                lastname: lastname,
                grade: grade,
                mark: mark
            };
            return thisItem;
        }
    }

    return {
        getSchool: function (name, location, numberOfCourse, specialty) {
            return new School(name, location, numberOfCourse, specialty);
        },
        //buildAccordion: function (selector, data) {
        //    var accordion = this.getAccordion(selector);

        //    if (data) {
        //        for (var i = 0; i < data.length; i++) {
        //            addItem(accordion, data[i]);
        //        }
        //    }

        //    return accordion;
        //}
    }
}());