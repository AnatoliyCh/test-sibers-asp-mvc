$(document).ready(function () {
    let allTd = $('[data-toggle="tooltip"]');
    let columTitle = $('[data-title]').data("title");
    console.log(allTd)
    for (var i = 0; i < allTd.length; i++) {
        if (allTd[i].innerText.length > 10)
            allTd[i].title = $(allTd[i]).data("title") ? columTitle : allTd[i].innerText;
    }
    allTd.tooltip();
})