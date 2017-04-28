var SkillRatingsController = function () {

    var init = function () {
        $('.categories').on('change', onCategoriesChange);
        $('#skill-rating-form').submit(onSkillRatingSubmit);
    };

    onCategoriesChange = function (e) {

        var categoryId = $(e.target).find(':selected').val();
        var skills = $('.skills');

        $.ajax({
            url: `/api/skills/GetSkillsByCategory/${categoryId}`,
            method: 'POST'
        })
            .done(function (response) {
                skills.empty();

                $.each(response, function (index, item) {
                    var option = `<option value="${item.Id}">${item.Name}</option>`;
                    skills.append(option);
                });
            })
            .fail(fail);
    };

    onSkillRatingSubmit = function (e) {

        e.preventDefault();
        var skillId = $('.skills').val();

        $.ajax({
            url: `/api/skillratings/validateUnique?skillId=${skillId}`,
            method: 'GET'
        })
            .done(function (response) {
                if (response) {
                    $('#skill-rating-form').off('submit');
                    $('#skill-rating-form').submit();
                } else {
                    var message = $('<div class="alert alert-danger" role="alert">You have already added this skill to your profile.</div>')
                    $('.alerts').append(message);
                    message.fadeOut(4000, function () { $(this).remove(); });
                }
            })
            .fail(fail);
    };

    fail = function () {
        alert('Error');
    };

    return {
        init
    };

}();