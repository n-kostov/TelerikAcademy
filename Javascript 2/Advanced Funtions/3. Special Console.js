var specialConsole  = (function () {

	function formatString(value, optionalParams) {
		var result = "", i = 0, length = 0;

        if (value) {
            result = value.toString();

            if (optionalParams) {
                for (i = 0, length = arguments.length; i < length - 1; i += 1) {
                    var pattern = "\\{" + i + "\\}";
                    var regex = new RegExp(pattern, "g");

                    result = result.replace(regex, arguments[i + 1].toString());
                }
            }
        }

        return result;
    }

    function writeLine(value, optionalParams) {
        var result = formatString.apply(null, arguments);
        console.log(result);
    }

    function writeError(value, optionalParams) {
        var result = formatString.apply(null, arguments);
        console.error(result);
    }

    function writeWarning(value, optionalParams) {
        var result = formatString.apply(null, arguments);
        console.warn(result);
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
})();