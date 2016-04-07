define(["jquery"],
    function ($) {
        "use strict";

        var init = function () {
            // Common app code run on every page can go here
            $("#sortable").text("hahah");
        };

        return {
            init: init
        };
    }
);