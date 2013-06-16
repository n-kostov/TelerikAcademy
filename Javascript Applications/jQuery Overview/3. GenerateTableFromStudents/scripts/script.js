var Student = function (fname, lname, grade) {
    this.fname = fname;
    this.lname = lname;
    this.grade = grade;
};

var TableRenderer = function (students) {
    this.students = [];
    if (students) {
        this.students = students;
    }
};

TableRenderer.prototype.init = function () {
    var table = $("<table></table>");

    var firstRow = $("<tr></tr>");
    firstRow.append("<th>First name</th>");
    firstRow.append("<th>Last name</th>");
    firstRow.append("<th>Grade</th>");
    table.append(firstRow);

    for (var i = 0; i < this.students.length; i++) {
        var row = $("<tr></tr>");
        row.append("<td>" + this.students[i].fname + "</td>");
        row.append("<td>" + this.students[i].lname + "</td>");
        row.append("<td>" + this.students[i].grade + "</td>");
        table.append(row);
    }

    $("#content").append(table);
};