// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function updateTodo(el) {
    let todoId = el.dataset.todoId;

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: `api/${todoId}`,
    });
}

function changeCategory(el) {
    let categoryHref = el.dataset.href;
    location.href = categoryHref;
}