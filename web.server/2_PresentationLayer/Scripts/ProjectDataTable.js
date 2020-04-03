$(document).ready(function () {
    let allTd = $('[data-toggle="tooltip"]');
    console.log(allTd)
    for (var i = 0; i < allTd.length; i++) {
        if (allTd[i].innerText.length > 15)
            allTd[i].title = allTd[i].innerText;
    }
    allTd.tooltip();
})