define(["jqueryui"], function () {
    $.fn.extend({
        divChange: function (callback) {
            //get target to observer
            var target = document.querySelector(this.selector);
            // create an observer instance
            var observer = new MutationObserver(function (mutations) {
                mutations.forEach(function (mutation) {
                    if (callback && typeof callback === "function") {
                        callback();
                    }
                });
            });

            // configuration of the observer:
            var config = { attributes: false, childList: true, characterData: false };
            // pass in the target node, as well as the observer options
            observer.observe(target, config);
        }
    });
    var oldcr = $.ui.sortable.prototype._create;
    $.ui.sortable.prototype.options.divChange = null;
    $.ui.sortable.prototype._create = function () {
        var divChange = this.options.divChange;
        oldcr.apply(this, arguments);
        var target = document.querySelector("#"+this.element.attr("id"));
        // create an observer instance
        var observer = new MutationObserver(function (mutations) {
            mutations.forEach(function (mutation) {
                if (divChange && typeof divChange === "function") {
                    divChange();
                }
            });
        });

        // configuration of the observer:
        var config = { attributes: false, childList: true, characterData: false };
        // pass in the target node, as well as the observer options
        observer.observe(target, config);
    };
});