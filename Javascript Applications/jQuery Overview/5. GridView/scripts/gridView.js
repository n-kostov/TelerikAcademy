var gridViewController = (function () {

    function GridView(selector) {

        var rows = [];
        var header = [];
        if (selector) {
            var container = $(selector);
        }

        var itemsTable = $("<table/>");
        if (container) {
            function onRowClicked(ev) {
                if (!ev) {
                    ev = window.event;
                }

                ev.stopPropagation();
                ev.preventDefault();

                var clickedItem = ev.target;

                var nextRow = $(clickedItem).parent().next();
                if (!nextRow) {
                    return;
                }
                var contentCell = nextRow.children().first();
                var contentTable = contentCell.children().first();
                if (!(contentTable.is("table"))) {
                    return
                }

                nextRow.fadeToggle("slow");
            };
            container.on('click', "td", onRowClicked);
        }

        this.addRow = function () {
            var cells = [];
            for (var i = 0; i < arguments.length; i++) {
                cells.push(arguments[i]);
            }

            var newRow = new Row(cells);
            rows.push(newRow);
            return newRow;
        };

        this.addHeader = function () {
            if (header.length > 0) {
                return;
            }

            var cells = [];
            for (var i = 0; i < arguments.length; i++) {
                cells.push(arguments[i]);
            }

            var newHeader = new Header(cells);
            header.push(newHeader);
            return newHeader;
        };

        this.render = function () {
            if (container) {
                while (container.firstChild) {
                    container.removeChild(container.firstChild);
                }
            }

            var thisTable = itemsTable.html('');

            if (header.length > 0) {
                var domHeader = header[0].render();
                thisTable.append(domHeader);
            }

            for (var i = 0; i < rows.length; i++) {
                var row = rows[i].render();
                thisTable.append(row);
                if (rows[i].getnested() !== 0) {
                    row.attr('class', 'parent');
                    var ngrid = rows[i].getnested();
                    var newCell = $('<td/>');
                    var cellsCount = rows[i].getCellsCount();
                    newCell.attr('colspan', cellsCount);
                    newCell.append(ngrid.render());
                    thisTable.append($('<tr/>').append(newCell).hide());
                }
            }
            if (container) {
                container.append(thisTable);
            }
            else {
                return thisTable;
            }

            return this;
        };
    }

    function Row(cells) {

        var nestedGrids = [];
        var nestedGridView;

        this.getnested = function () {
            if (nestedGrids.length > 0) {
                return nestedGrids[0];
            }
            else {
                return 0;
            }
        }

        this.getCellsCount = function () {
            return cells.length;
        }

        this.NestedGridView = function (selector) {
            if (nestedGridView) {
                return;
            }

            nestedGridView = new GridView();
            nestedGrids.push(nestedGridView);
            return nestedGridView;
        };


        this.render = function () {
            var currentRow = $('<tr/>');
            for (var i = 0; i < cells.length; i++) {
                var currentCell = $('<td/>');
                currentCell.text(cells[i]);
                currentRow.append(currentCell);
            };

            return currentRow;
        }
    }

    function Header(cells) {

        this.render = function () {
            var currentRow = $('<tr/>');
            for (var i = 0; i < cells.length; i++) {
                var currentCell = $('<th/>');
                currentCell.text(cells[i]);
                currentRow.append(currentCell);
            };

            return currentRow;
        }
    }

    return {
        GridView: function (selector) {
            return new GridView(selector);
        }
    };

}());