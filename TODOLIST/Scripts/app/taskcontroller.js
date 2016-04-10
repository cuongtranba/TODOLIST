define(["helper"], function () {
    "use strict";
    var changePositionTask = function () {
        var item = $("#sortable li");
        var itemPostion = [];
        item.each(function (key, value) {
            var itemData = $(item[key]).data();
            var data = { id: itemData.id, Order: key }
            itemPostion.push(data);
        });
        $.ajax({
            type: "POST",
            url: "/home/updateposition",
            contentType: 'application/json',
            data: JSON.stringify({ toDoItemViewModel: itemPostion })
        });
    };
    var markAllTaskDone = function () {
        function allDone() {
            var tasks = [];
            (function () {
                $('#sortable li').each(function () {
                    var taskData = { id: $(this).data().id, isdone: true, text: $(this).text() };
                    tasks.push(taskData);
                });
            })();

            var updateUi = function () {
                // add to done
                for (var i = 0; i < tasks.length; i++) {
                    $('#done-items').append('<li data-id=' + tasks[i].id + '>' + tasks[i].text + '<button class="btn btn-default btn-xs pull-right  remove-item"><span class="glyphicon glyphicon-remove"></span></button></li>');
                }

                // myArray
                $('#sortable li').remove();
            }
            var markTaskDone = function () {
                $.ajax({
                    type: "POST",
                    url: "/home/MarkAllTaskDone",
                    contentType: 'application/json',
                    data: JSON.stringify({ models: tasks }),
                    success: function (data) {
                        if (data.isSuccess) {
                            updateUi();
                        }
                    }
                });
            };
            markTaskDone();
        }
        $("#checkAll").click(function () {
            allDone();
        });
    };
    var countTask = function () {
        var count = $("#sortable li:not([style*='hidden'])").length;
        $(".count-todos").html(count);
    };
    var createTask = function () {
        function createTodo(text) {
            var order = $("#sortable li").length + 1;
            $.post("/home/Createtodo", { Description: text, Order: order }, function (data) {
                if (data.isSuccess) {
                    var markup = '<li data-id=' + data.id + ' class="ui-state-default"><div class="checkbox"><label><input type="checkbox" value="" />' + text + '</label></div></li>';
                    $('#sortable').append(markup);
                    $('.add-todo').val('');
                    $("#sortable").trigger("sortupdate", function (event, ui) {
                    });
                    $(".result").html(data);
                    //countTask();
                }
            }, "json");
        }
        $('.add-todo').on('keypress', function (e) {
            e.preventDefault;
            if (e.which === 13) {
                if ($(this).val()) {
                    var todo = $(this).val();
                    createTodo(todo);
                }
            }
        });
    };
    var initTask = function () {
        $("#sortable").sortable({
            start: function (e, ui) {
                $(this).attr('data-previndex', ui.item.index());
            },
            stop: function (event, ui) {
                changePositionTask();
            },
            divChange: function () {
                countTask();
            }
        });
        countTask();
    };
    var deleteTask = function () {
        function removeItem(element) {
            var id = $(element).closest('li').data().id;
            $.post("/home/deletetask", { id: id, isdeleted: true }, function (data) {
                if (data.isSuccess) {
                    $(element).parent().remove();
                }
            });
        }
        $(".todolist").on("click", ".remove-item", function () {
            removeItem(this);
        });
    };
    var markTaskDone = function () {
        function done(doneItem) {
            var itemId = $(doneItem).data().id;
            var tasklabel = $(doneItem).find('label').text();
            $.post("/home/MarkTaskDone", { id: itemId, isDone: true }, function (data) {
                if (data.isSuccess) {
                    var markup = '<li data-id=' + itemId + '>' + tasklabel + '<button class="btn btn-default btn-xs pull-right  remove-item"><span class="glyphicon glyphicon-remove"></span></button></li>';
                    $('#done-items').append(markup);
                    $('.remove').remove();
                }
            });
        }
        $('.todolist').on('change', '#sortable li input[type="checkbox"]', function () {
            if ($(this).prop('checked')) {
                var item = $(this).closest("li");
                $(this).closest("li").addClass('remove');
                done(item);
            }
        });
    };

    return {
        changePositionTask: changePositionTask,
        markAllTaskDone: markAllTaskDone,
        initTask: initTask,
        deleteTask: deleteTask,
        createTask: createTask,
        markTaskDone: markTaskDone
    };
});