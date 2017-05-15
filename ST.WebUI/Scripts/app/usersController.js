var UsersController = function () {

    var init = function () {
        $(".delete-user").click(onDeleteUser);
    };

    var onDeleteUser = function (e) {
        e.preventDefault();
        var element = $(e.target);
        var userEmail = element.closest('td').prev().prev().text().trim();
        var userName = element.closest('td').prev().prev().prev().text().trim();

        bootbox.confirm({
            message: "Are you sure you want to delete <strong>" + userName + "</strong> user?",
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

                $.ajax({
                    url: `/users/delete/?email=${userEmail}`,
                    method: "POST"
                })
                    .done(function () {
                        element.closest('tr')
                            .fadeOut(function () {
                                $(this).remove();
                            });
                    })
                    .fail(fail);
            }
        });
    };

    var fail = function () {
        alert("Error!");
    }

    return {
        init
    };
}();