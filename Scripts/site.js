$(document).ready(function () {
    var currentFilter = $('#CurrentCategory').text();
    var option = "";
    if (currentFilter === "" || currentFilter === "All") {
        option = '<option value="All" selected="selected">All</option>';
    } else {
        option = '<option value="All">All</option>';
    }

    $('#Category').prepend(option);
})