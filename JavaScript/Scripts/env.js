var window = {},sys = {
    debug: function () { }
}, process = {
    argv: [],
    exit: function () { }
},
require = (function () {
    var exported = {};
    var files = {};

    return function (file) {
        file = getFullFilename(file);
        var key = file.toLowerCase();

        if (files[key]) {
            return exported[key];
        }

        var js = getContents(file);
        exported[key] = {}
        files[key] = true;
        (new Function('var exports = arguments[0]; ' + js + ';'))(exported[key]);
        return exported[key];
    }
})();