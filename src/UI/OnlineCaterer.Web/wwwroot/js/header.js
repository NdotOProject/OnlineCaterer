
var contentBox = $('#selected_option-content');
var searchOptionArrow = $("#search_option-arrow");
var searchForm = $('#search_form');
var userOptionsArrow = $('#user_options-arrow');
var userOptionList = $('#user_option-list');

$('#search_option').click(function () {
    invalidateIfActive(userOptionsArrow, userOptionList);

    searchOptionArrow.toggleClass('active');
    toggleBoxContent();

    toggleShow(searchOptionArrow, searchForm);
});

$('#user_options').click(function () {
    invalidateIfActive(searchOptionArrow, searchForm);

    userOptionsArrow.toggleClass('active');
    toggleBoxContent();

    toggleShow(userOptionsArrow, userOptionList);
});

function invalidateIfActive(arrow, boxContent) {
    if (arrow.hasClass('active')) {
        boxContent.removeClass('show');
        arrow.removeClass('active');
    }
}

function toggleShow(arrow, content) {
    if (arrow.hasClass('active')) {
        content.addClass('show');
    } else {
        content.removeClass('show');
    }
}

function toggleBoxContent() {
    if (userOptionsArrow.hasClass('active') || searchOptionArrow.hasClass('active')) {
        contentBox.addClass('show');
    } else {
        contentBox.removeClass('show');
    }

}