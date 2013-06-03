var controls = (function () {

    function GridView(selector) {
        var header;
        var rows = [];
        var gridCells;
        //var gridItem = document.querySelector(selector);
        var gridItem;
        if (typeof selector === "object") {
            gridItem = selector.cloneNode();
        } else {
            gridItem = document.querySelector(selector);
        }
        //gridItem = document.querySelector(selector);
        //if (!gridItem) {
        //    gridItem = selector;
        //}

        gridItem.addEventListener("click",
        function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            var clickedItem = ev.target;

            var sublist = clickedItem.parentNode;
            sublist = sublist.querySelector("tr");
            if (!sublist) {
                return;
            }
            if (sublist.style.display === "none") {
                sublist.style.display = "";
            } else {
                sublist.style.display = "none";
            }
        }, false);

        var itemsList = document.createElement("table");
        itemsList.style.cellPadding = "0";
        itemsList.style.cellSpacing = "0";

        this.addHeader = function () {
            var newItem;
            if (header) {
                if (arguments.length !== gridCells) {
                    return header;
                }

                newItem = new GridViewRow(true, arguments);
                header = newItem;
                return newItem;
            }
            else {
                gridCells = arguments.length;
                newItem = new GridViewRow(true, arguments);
                header = newItem;
                return newItem;
            }
        };

        this.addRow = function () {
            if (arguments.length === gridCells) {
                var newItem = new GridViewRow(false, arguments);
                rows.push(newItem);
                return newItem;
            }
        };

        this.render = function () {
            while (gridItem.firstChild) {
                gridItem.removeChild(gridItem.firstChild);
            }

            while (itemsList.firstChild) {
                itemsList.removeChild(itemsList.firstChild);
            }

            if (header) {
                var head = header.render();
                itemsList.appendChild(head);
            }

            for (var i = 0, len = rows.length; i < len; i += 1) {
                var domItem = rows[i].render();
                itemsList.appendChild(domItem);
            }

            gridItem.appendChild(itemsList);
            return gridItem.cloneNode();
        };

        this.serialize = function () {
            var serializedItems = [];
            for (var i = 0; i < rows.length; i += 1) {
                serializedItems.push(rows[i].serialize());
            }
            return serializedItems;
        }
    };

    function GridViewRow(isHeader) {
        var headers = [];
        var isHeader = isHeader;
        var self = this;
        var columns = [];
        var nestedGrid;
        var itemNode = document.createElement("tr");
        arguments = arguments[1];

        this.init = function () {
            arguments = arguments[0];
            for (var i = 0, len = arguments.length; i < len; i += 1) {
                columns.push(arguments[i]);
            }
            if (isHeader) {
                for (var i = 0; i < columns.length; i++) {
                    headers.push(columns[i]);
                }
            }

            return self;
        };

        self.init(arguments);

        this.render = function () {

            if (columns.length > 0) {
                var sublist = document.createElement("td");
                for (var i = 0, len = columns.length; i < len; i += 1) {
                    var subItem;
                    if (isHeader) {
                        subItem = document.createElement("th");

                    } else {
                        subItem = document.createElement("td");
                    }

                    subItem.innerHTML = columns[i];
                    itemNode.appendChild(subItem);
                }

                if (nestedGrid) {
                    var grid = nestedGrid.render();
                    grid = grid.cloneNode();
                    grid.style.display = "none";
                    itemNode.appendChild(grid);
                }
            };

            return itemNode.cloneNode();
        };

        this.serialize = function () {
            var thisItem = {};
            for (var i = 0; i < headers.length; i++) {
                thisItem.header[i] = headers[i];
            }
            if (nestedGrid) {
                var serItem = nestedGrid.serialize();
                thisItem.nestedGrid = serItem;
            }
            return thisItem;
        }

        this.getNestedGridView = function () {
            nestedGrid = new GridView(itemNode);
            return nestedGrid;
        }
    }

    function addItem(item, dataItem) {
        var accItem;
        if (dataItem.items) {
            for (var i = 0; i < dataItem.items.length; i++) {
                addItem(accItem, dataItem.items[i]);
            }
        }
    }

    return {
        getGridView: function (selector) {
            return new GridView(selector);
        },
        buildGrid: function (selector, data) {
            var grid = this.getGridView(selector);

            if (data) {
                for (var i = 0; i < data.length; i++) {
                    addItem(grid, data[i]);
                }
            }

            return grid;
        }
    }
}());