﻿
const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButton.addEventListener('click', () => {
    container.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
    container.classList.remove("right-panel-active");
});



function deleteItem(Id) {
    var item_to_delete = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        window.location.href = '/Owners/Delete/' + item_to_delete;
    });
}

function EditItem(Id) {
    $(document).ready(function () {
        var item_to_Edit = Id;
        location.href = '/Owners/Edit/' + item_to_Edit;
    });
}

function DetailsItem(Id) {
    $(document).ready(function () {       
        var item_to_Details = Id;    
        location.href = '/Owners/Details/' + item_to_Details;       
    });
}

