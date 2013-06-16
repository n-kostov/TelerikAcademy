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

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype; // Set prototype of derived class
        var parentPrototype = new parent(); // Get copy of parent class
        this.prototype = Object.create(parentPrototype); // Set to derived class all parent prototypes
        this.prototype._super = parent; // Set to _super property parent class prototypes
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop]; // Add all derived class prototypes to the derived class
        }
    }

    return {
        create: createClass,
    };
}());

var Person = Class.create({
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },
    introduce: function () {
        return "Name:" + this.fname + " " + this.lname + ", Age: " + this.age;
    }
});

var Student = Class.create({
    init: function (firstname, lastname, age, grade) {
        this._super = new this._super(arguments);
        this._super.init(firstname, lastname, age);
        this.grade = grade;
    },
    introduce: function () {
        return this._super.introduce() + ", grade: " + this.grade;
    }
});

Student.inherit(Person);

var Teacher = Class.create({
    init: function (firstname, lastname, age, speciality) {
        this._super = new this._super(arguments);
        this._super.init(firstname, lastname, age);
        this.speciality = speciality;
    },
    introduce: function () {
        return this._super.introduce() + ", speciality: " + this.speciality;
    }
});

Teacher.inherit(Person);

var School = Class.create({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    }
});

var Course = Class.create({
    init: function (name, capacity, students, formTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.formTeacher = formTeacher;
    }
});