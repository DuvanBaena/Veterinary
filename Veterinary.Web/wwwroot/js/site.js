
function BtnCreate() {

    var nombre = $("#Username").val();
    var Document = $("#Document").val();
    var FirstName = $("#FirstName").val();
    var LastName = $("#LastName").val();
    const Password = $("#Password").val();
    const PasswordConfirm = $("#PasswordConfirm").val();

    toastr.options = {
        "debug": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    if ($.trim(nombre) === "") {
        $("#Username").css('border-color', 'Red');
        toastr.error("No ha ingresado Username", "alerta!");
        $("#Username").focus();
        $("#Username").keydown(function () {
            $("#Username").css("border-color", "lightgrey");
        });
        $("#Username").keyup(function () {
            $("#Username").css("border-color", "lightgrey");
        });
        return false;
    } else if ($.trim(Document) === "") {
        $("#Document").css('border-color', 'Red');
        toastr.error("No ha ingresado Document", "alerta!");
        $("#Document").focus();
        $("#Document").keydown(function () {
            $("#Document").css("border-color", "lightgrey");
        });
        $("#Username").keyup(function () {
            $("#Username").css("border-color", "lightgrey");
        });
        return false;
    } else if ($.trim(FirstName) === "") {
        $("#FirstName").css('border-color', 'Red');
        toastr.error("No ha ingresado Nombre", "alerta!");
        $("#FirstName").focus();
        $("#FirstName").keydown(function () {
            $("#FirstName").css("border-color", "lightgrey");
        });
        $("#FirstName").keyup(function () {
            $("#FirstName").css("border-color", "lightgrey");
        });
        return false;
    } else if ($.trim(LastName) === "") {
        $("#LastName").css('border-color', 'Red');
        toastr.error("No ha ingresado Apellido", "alerta!");
        $("#LastName").focus();
        $("#LastName").keydown(function () {
            $("#LastName").css("border-color", "lightgrey");
        });
        $("#LastName").keyup(function () {
            $("#LastName").css("border-color", "lightgrey");
        });
        return false;
    } else if ($.trim(Password) === "") {
        $("#Password").css('border-color', 'Red');
        toastr.error("No ha ingresado Password", "alerta!");
        $("#Password").focus();
        $("#Password").keydown(function () {
            $("#Password").css("border-color", "lightgrey");
        });
        $("#Password").keyup(function () {
            $("#Password").css("border-color", "lightgrey");
        });
        return false;
    } else if ($.trim(PasswordConfirm) === "") {
        $('#PasswordConfirm').css('border-color', 'Red');      
        toastr.error("No ha ingresado PasswordConfirm", "alerta!");
        $("#PasswordConfirm").focus();
        $("#PasswordConfirm").keydown(function () {
            $("#PasswordConfirm").css("border-color", "lightgrey");
        });
        $("#PasswordConfirm").keyup(function () {
            $("#PasswordConfirm").css("border-color", "lightgrey");
        });
        return false;
    } else if ($.trim(Password) !== "" && $.trim(PasswordConfirm) !== "")

        {       

            if (Password !== PasswordConfirm) {        
                $('#PasswordConfirm').css('border-color', 'Red');
                toastr.error("Las contraseñas no Coinciden!", "alerta!");
                $("#PasswordConfirm").focus();
                return false;
            } else if ($("#Password").val().length < 6 && $("#PasswordConfirm").val().length < 6) { 
                $("#Password").css('border-color', 'Red');
                $('#PasswordConfirm').css('border-color', 'Red');
                toastr.error("La complejidad de contraseña son minimo 6 caracteres", "alerta!");
                $("#PasswordConfirm").focus();
                $("#PasswordConfirm").keydown(function () {
                    $("#PasswordConfirm").css("border-color", "lightgrey");
                });
                $("#PasswordConfirm").keyup(function () {
                    $("#PasswordConfirm").css("border-color", "lightgrey");
                });
                $("#Password").keydown(function () {
                    $("#Password").css("border-color", "lightgrey");
                });
                $("#Password").keyup(function () {
                    $("#Password").css("border-color", "lightgrey");
                });
                return false;
            }      
        
            return false;
        }


    else {
      
        toastr.error("La complejidad de contraseña son minimo 6 caracteres", "alerta!").sleep(1000);
        Command: toastr["success"]("Registro guardado exitosamente!", "Felicitaciones");
        return false; 
    }


}


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

