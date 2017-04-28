var CategoriesController = function () {
    var element;

    var init = function () {
        $("span.delete").click(onDelete);
        $('#category-form').submit(onSubmit);
    };

    var onSubmit = function (e) {
        e.preventDefault();
        var categoryName = $('.category-name').val();
        validateAndSubmitCategory(categoryName);    
    };
    var onDelete = function (e) {
        e.preventDefault();
        element = $(e.target);
        var categoryId = element.attr("data-category-id");
        var categoryName = element.closest('td').prev().text().trim();

        bootbox.confirm({
            message: "Are you sure you want to delete <strong>" + categoryName + "</strong> category?",
            buttons: {
                cancel: {
                    label: 'No',
                    className: 'btn-default'
                },
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (!result) return;
                deleteCategory(categoryId);
            }
        });
    }

    var validateAndSubmitCategory = function (categoryName) {
        $.ajax({
            url: `/api/categories/validateUnique?name=${categoryName}`,
            method: 'GET'
        })
            .done(function (response) {
                if (!response) {
                    var message = $('<div class="alert alert-danger" role="alert">There is already a category with such name.</div>')
                    $('.alert-info').after(message);
                    message.fadeOut(4000);
                } else {
                    $('#category-form').off('submit');
                    $('#category-form').submit();
                }
            })
            .fail(fail);
    }
    var deleteCategory = function (categoryId) {
        $.ajax({
            url: "/categories/delete/" + categoryId,
            method: "POST"
        })
            .done(function () {
                element.closest('tr')
                    .fadeOut(function () {
                        $(this).remove();
                    })
            })
            .fail(fail);
    }

    var fail = function () { alert("Error!"); };

    return {
        init
    };
}();