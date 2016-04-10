require.config({
    baseUrl: "/Scripts/app",
    paths: {
        jquery: "../lib/jquery-1.10.2.min",
        jqueryValidate: "../lib/jquery.validate",
        jqueryValidateUnobtrusive: "../lib/jquery.validate.unobtrusive",
        bootstrap: "../lib/bootstrap",
        jqueryui: "../lib/jquery-ui-1.11.4.min",
        helper:"../lib/helper"
    },
    shim: {
        jqueryValidate: ["jquery"],
        jqueryValidateUnobtrusive: ["jquery", "jqueryValidate"],
        jqueryui: {
            deps: ["jquery"]
        },
        helper:["jqueryui"]
    }
});
