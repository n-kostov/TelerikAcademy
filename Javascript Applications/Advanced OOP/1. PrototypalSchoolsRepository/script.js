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


var Person = {
    init: function (firstname, lastname, age) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
    },

    introduce: function () {
        return "Name: " + this.firstname + " " + this.lastname + ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (firstname, lastname, age, grade) {
        Person.init.apply(this, arguments);
        this.grade = grade;
    },
    introduce: function () {
        return Person.introduce.apply(this) + ", grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (firstname, lastname, age, specialty) {
        Person.init.apply(this, arguments);
        this.specialty = specialty;
    },
    introduce: function () {
        return Person.introduce.apply(this) + ", specialty: " + this.specialty;
    }
});

var Course = {
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    }
};

var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    }
};