var SkillsController = function () {
    var element;

    var init = function () {
        $("span.delete").click(onDeleteSkill);
        $('#skill-form').submit(onSubmit);
    };

    var onSubmit = function (e) {
        e.preventDefault();
        var skillName = $('#skill-name').val();
        var categoryId = $('.category').val();

        validateAndSubmitSkill(skillName, categoryId);
    };
    var onDeleteSkill = function (e) {
        e.preventDefault();
        element = $(e.target);
        var skillId = element.attr("data-skill-id");
        var skillName = element.closest('td').prev().prev().text().trim();

        bootbox.confirm({
            message: "Are you sure you want to delete <strong>" + skillName + "</strong> skill?",
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
                deleteSkill(skillId);
            }
        });
    };

    var validateAndSubmitSkill = function (skillName, categoryId) {

        if (!skillName || !categoryId) return;

        $.ajax({
            url: `/api/skills/validateUnique?name=${skillName}&categoryId=${categoryId}`,
            method: 'GET'
        })
            .done(function (response) {
                if (!response) {
                    var message = $('<div class="alert alert-danger" role="alert">There is already a skill with such name.</div>')
                    $('.alert-info').after(message);
                    message.fadeOut(4000, function () { $(this).remove(); });
                } else {
                    $('#skill-form').off('submit');
                    $('#skill-form').submit();
                }
            })
            .fail(fail);
    }
    var deleteSkill = function (skillId) {
        $.ajax({
            url: "/skills/delete/" + skillId,
            method: "POST"
        })
            .done(function () {
                element.closest('tr')
                    .fadeOut(function () { $(this).remove(); })
            })
            .fail(fail);
    }

    var fail = function () { alert("Error!"); };

    return {
        init
    };
}();