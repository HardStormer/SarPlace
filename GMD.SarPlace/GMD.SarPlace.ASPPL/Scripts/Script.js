$('#areYouSure').click(function (e) {
    if (confirm("Вы уверены?")) {
    }
    else {
        e.preventDefault();
    }
});

window.addEventListener('error', function (e) {
    var error = e.error;
    location.href = '/Pages/ErrorPage';
});

