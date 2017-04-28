var DevelopersController = function () {

    var skillElement;
    var skillId;
    var skillName;
    var rating;
    var actions;
    var acceptChangesEl;

    var init = function () {
        drawRatings();
        $('.skills-item-edit').on('click', onSkillRatingEdit);
        $('.skills-item-delete').on('click', onSkillRatingDelete);
    };

    var onSkillRatingEdit = function (e) {
        skillElement = $(e.target).closest('li');

        skillId = skillElement.attr('data-skill-id');
        rating = skillElement.attr('data-skill-rating');
        actions = skillElement.find('.actions');

        switchToEditorMode();

        $('.edit-rating').on('blur', onEditFinish);
    };

    var onEditFinish = function (e) {
        var targetElement = $(e.target);
        var parentElement = targetElement.closest('li');
        var newRating = targetElement.val();

        if (newRating != rating) {
            $.post('/api/skillratings/update',
                {
                    skillId: skillId,
                    rating: newRating
                })
                .done(function () {
                    rating = newRating;
                    switchToViewMode(targetElement, parentElement);
                })
                .fail(fail);
        } else {
            switchToViewMode(targetElement, parentElement);
        }
    };
    var switchToEditorMode = function () {
        skillElement.find('.glyphicon-star').remove();
        actions.toggleClass('actions').css('display', 'none');
        var editor = $(`<input class="form-control edit-rating" type="number" value="${rating}" min="1" max="5" />`);
        acceptChangesEl = $('<span class="skills-item-update glyphicon glyphicon-ok"></span>');
        skillElement.find('section').append(editor).append(acceptChangesEl);
        editor.focus();
    };
    var switchToViewMode = function (targetElement, parentElement) {
        actions.toggleClass('actions').css('display', '');
        targetElement.remove();
        acceptChangesEl.remove();

        for (var i = 0; i < rating; i++) {
            parentElement.find('section').append('<span class="glyphicon glyphicon-star"></span>');
        }
    };

    var onSkillRatingDelete = function (e) {
        skillElement = $(e.target).closest('li');
        skillName = skillElement.attr('data-skill-name');
        skillId = skillElement.attr('data-skill-id');

        bootbox.confirm({
            message: `Are you sure you want to delete <strong>${skillName}</strong> skill?`,
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
                    url: `/api/skillratings/Delete/${skillId}`,
                    method: "POST"
                })
                    .done(function () {
                        skillElement.fadeOut(function () {
                            $(this).remove();
                        })
                    })
                    .fail(fail);
            }
        });
    };

    var drawRatings = function () {
        var skillElements = $('.skills-item');
        $.each(skillElements, function (index, item) {
            var rating = $(this).attr('data-skill-rating')
            for (var i = 0; i < rating; i++) {
                $(item).find('section').append('<span class="glyphicon glyphicon-star"></span>');
            }
        });
    };

    var fail = function () {
        alert('Error');
    };

    return {
        init
    };
}();