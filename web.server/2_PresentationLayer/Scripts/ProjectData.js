$(document).ready(function () {
    // тултипы в таблицах
    let allTd = $('[data-toggle="tooltip"]');
    let columTitle = $('[data-title]').data("title");
    for (var i = 0; i < allTd.length; i++) {
        if (allTd[i].innerText.length > 10)
            allTd[i].title = $(allTd[i]).data("title") ? columTitle : allTd[i].innerText;
    }
    allTd.tooltip();

    // uncheck radio кнопок
    $("[type='radio']").click(function (e) {
        if (e.ctrlKey) this.checked = false;
    })
})