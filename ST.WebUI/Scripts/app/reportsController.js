var ReportsController = function () {

    var counter = 1;

    var init = function () {
        $('.categories[data-wired="false"]').change(onCategoryChange);
        $('.begin-search').on('click', onBeginSearch);
        $('.add-filter').on('click', onAddFilter);
    };

    var onCategoryChange = function (e) {
        var id = $(e.target).closest('.filter').attr('id');
        var categoryId = $(e.target).find(':selected').val();
        var skills = $(`.skills[id="${id}"]`);

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


        $(this).attr('data-wired', true);
    };
    var onBeginSearch = function () {
        var filterDtos = [];
        var filters = $('.filter');

        $.each(filters, function (index, item) {
            var categoryId = $(item).find('.categories').val();
            var skillId = $(item).find('.skills').val();
            var comparer = $(item).find('.comparer').val();
            var rating = $(item).find('.rating').val();

            filterDtos.push({
                categoryId,
                skillId,
                comparer,
                rating
            });
        });

        var data = JSON.stringify(filterDtos);
        localStorage.setItem('filterDtos', data);

        $.ajax({
            url: '/api/reports/search/',
            data: data,
            contentType: 'application/json',
            method: 'POST'
        })
            .done(function (response) {
                var results = $('#results').empty();

                $.each(response, function (key, dev) {

                    var skills = $('<div class="skills-container"></div>')

                    $.each(dev.SkillRatings, function (key, entry) {
                        var categoryGroup = $('<p></p>')
                            .append($(`<strong>${key}: </strong>`));

                        $.each(entry, function (key, skill) {
                            categoryGroup.append($(`<span> ${skill.SkillName} (${skill.Rating}/5) </span>`));
                        })

                        skills.append(categoryGroup);
                    });

                    var devDesc = $('<div class="dev-description"></div>')
                        .append($('<h3></h3>')
                            .append($(`<a href="/managers/developerprofile?email=${dev.Email}">${dev.FirstName} ${dev.LastName} </a>`))
                            .append($(`<small>${dev.Email}</small>`))
                        )
                        .append(skills);

                    results.append(devDesc);
                });

                if (response.length) {
                    localStorage.setItem('searchResults', JSON.stringify(response));
                    $('.save-report').removeClass('disabled');
                } else {
                    $('.save-report').addClass('disabled');
                    results.empty().append($('<p class="text-info">No matches found.</p>'));
                }
            })
            .fail(fail);
    }
    var onAddFilter = function () {
        var filters = $('.filters');

        var categories = $('<select class="form-control categories" data-wired="false"></select>');

        populateCategories(categories);

        var filter = $(`<div id="filter-${counter}" class="filter"></div>`)
            .append($('<div class="form-group"></div>')
                .append(categories)
            )
            .append($('<div class="form-group"></div>')
                .append($(`<select id="filter-${counter}" class="form-control skills"></select>`))
            )
            .append($('<div class="form-group comparer-container"></div>')
                .append($('<select class="form-control comparer"></select>')
                    .append($('<option value="0">>=</option>'))
                    .append($('<option value="1"><=</option>'))
                    .append($('<option value="2">==</option>'))
                )
            )
            .append($('<div class="form-group rating-container"></div>')
                .append($('<select class="form-control rating"></select>')
                    .append($('<option value="1">1</option>'))
                    .append($('<option value="2">2</option>'))
                    .append($('<option value="3">3</option>'))
                    .append($('<option value="4">4</option>'))
                    .append($('<option value="5">5</option>'))
                )
            );

        filters.append(filter);
        $('.categories[data-wired="false"]').change(onCategoryChange);
        counter++;
    };

    var populateCategories = function (categories) {
        $.ajax({
            url: '/api/categories/GetAll',
            method: 'POST'
        })
            .done(function (response) {

                var emptyOption = `<option selected disabled>Select category</option>`;
                categories.append(emptyOption);

                $.each(response, function (index, item) {
                    var option = `<option value="${item.Id}">${item.Name}</option>`;
                    categories.append(option);
                });
            })
            .fail(fail);
    };
    var fail = function () {
        alert('Error');
    }

    return {
        init
    };
}();