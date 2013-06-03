if (typeof window.localStorage === 'undefined' || typeof window.sessionStorage === 'undefined') {
    var Storage = function (type) {
    function createCookie(name, value, days) {
        var date, expires;

        if (days) {
            date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString();
        } else {
            expires = "";
        }

        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function readCookie(name) {
        var nameEQ = name + "=",
        allCookies = document.cookie.split(';'),
        i,
        cookie;

        for (i = 0; i < allCookies.length; i++) {
            cookie = allCookies[i];
            while (cookie.charAt(0) === ' ') {
                cookie = cookie.substring(1,cookie.length);
            }

            if (cookie.indexOf(nameEQ) === 0) {
                return cookie.substring(nameEQ.length, cookie.length);
            }
        }

        return null;
    }

    function setData(data) {
        data = JSON.stringify(data);

        if (type === 'session') {
            window.name = data;
        } else {
            createCookie('localStorage', data, 365);
        }
    }

    function clearData() {
        if (type === 'session') {
            window.name = '';
        } else {
            createCookie('localStorage', '', 365);
        }
    }

    function getData() {
        var data = type === 'session' ? window.name : readCookie('localStorage');
        return data ? JSON.parse(data) : {};
    }

    var data = getData();

    return {
        length: 0,
        clear: function () {
            data = {};
            this.length = 0;
            clearData();
        },
        getItem: function (key) {
            return data[key] === undefined ? null : data[key];
        },
        key: function (index) {
            var i = 0;
            for (var key in data) {
                if (i === index) {
                    return k;
                } else {
                    i++;
                }
            }

            return null;
        },
        removeItem: function (key) {
            delete data[key];
            this.length--;
            setData(data);
        },
        setItem: function (key, value) {
            data[key] = value + '';
            this.length++;
            setData(data);
        }
    };
    };

    if(!document.localStorage) document.localStorage = new Storage('local');
    if(!document.sessionStorage) document.sessionStorage = new Storage('session');
}