function toastrValidated() {

    toastr.options = {
        "progressBar": true,
        "positionClass": "toast-top-right",
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

}

function EditOwnerItems() {

    toastrValidated();

    const Document = $("#Document").val();
    const FirstName = $("#FirstName").val();
  

    if ($.trim(Document) === "") {
        $("#Document").css('border-color', 'Red');
        toastr.error("El campo documento es obligatorio", "alerta!");
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
        toastr.error("El campo Nombre es obligatorio", "alerta!");
        $("#FirstName").focus();
        $("#FirstName").keydown(function () {
            $("#FirstName").css("border-color", "lightgrey");
        });
        $("#FirstName").keyup(function () {
            $("#FirstName").css("border-color", "lightgrey");
        });
        return false;
    } 


}

//Crud Controller Owner/Action

function CreateOwnerIndex() {
    location.href = '/Owners/Create/';
}

function CreateOwnerItem() {

    toastrValidated();

    const nombre = $("#Username").val();
    const Document = $("#Document").val();
    const FirstName = $("#FirstName").val();   
    const Password = $("#Password").val();
    const PasswordConfirm = $("#PasswordConfirm").val();

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
    }  else if ($.trim(Password) === "") {
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
    } else if ($.trim(Password) !== "" && $.trim(PasswordConfirm) !== "") {

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

        } else {

            toastr.success("Registro exitoso", "Sucess!");
        }

    }
}

function DeleteItem(Id) {
    var item_to_delete = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Owners/Delete/' + item_to_delete;
    });
}

function EditItem(Id) {
    var item_to_Edit = Id;
    if (Id !== null) {
        $(document).ready(function () {
            location.href = '/Owners/Edit/' + item_to_Edit;
        });
    }

}

function DetailsItem(Id) {
    var item_to_Details = Id;
    $(document).ready(function () {
        location.href = '/Owners/Details/' + item_to_Details;
    });
}

function AddpetItem(Id) {
    var item_to_Addpet = Id;
    $(document).ready(function () {
        location.href = '/Owners/AddPet/' + item_to_Addpet;
    });
}

function EditPetItem(Id) {

    var item_to_EditPet = Id;

    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Owners/EditPet/' + item_to_EditPet;
        });
    } else {
        toastr["warning"]("La variabe enviada esta llegando undefined", "Alerta");
    }
}

function DetailPetItem(Id) {
    var item_to_DetailPet = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Owners/DetailsPet/' + item_to_DetailPet;
        });
    } else {
        toastr["warning"]("La variabe enviada esta llegando undefined", "Alerta");
    }
}

function OwnerDetailItem(Id) {
    var item_to_DetailPet = Id;
    $(document).ready(function () {
        location.href = '/Owners/Details/' + item_to_DetailPet;
    });
}

function DeletePetItem(Id) {
    var item_to_deletePet = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Owners/DeletePet/' + item_to_deletePet;
    });
}

// validation AddPet

function CreateAddPet() {

    toastrValidated();

    const name = document.getElementById('Name').value;
    const born = document.getElementById('datepicker').value;
    const petType = document.getElementById('PetTypeId').value;
    const resul = parseInt(petType);

    if (name === '') {
        $("#Name").css('border-color', 'Red');
        toastr["error"]("El campo Nombre de mascota obligatorios", "Alerta");
        $("#Name").focus();
        $("#Name").keydown(function () {
            $("#Name").css("border-color", "lightgrey");
        });
        $("#Name").keyup(function () {
            $("#Name").css("border-color", "lightgrey");
        });
        return false;
    } else if (born === '') {
        $("#Born").css('border-color', 'Red');
        toastr["error"]("La fecha de nacimiento es obligatoria", "Alerta");
        $("#Born").focus();
        $("#Born").keydown(function () {
            $("#Born").css("border-color", "lightgrey");
        });
        $("#Born").keyup(function () {
            $("#Born").css("border-color", "lightgrey");
        });
        return false;
    } else if (born === '') {
        $("#Born").css('border-color', 'Red');
        toastr["error"]("La fecha de nacimiento es obligatoria", "Alerta");
        $("#Born").focus();
        $("#Born").keydown(function () {
            $("#Born").css("border-color", "lightgrey");
        });
        $("#Born").keyup(function () {
            $("#Born").css("border-color", "lightgrey");
        });
        return false;
    }

    else if (resul === 0) {
        toastr["error"]("Seleccion de tipo de mascota es obligatoria", "Alerta");
        $("#petType").focus();
        return false;
    }

    else {
        toastr["success"]("Registro exitoso!", "Felicitaciones");
    }

}

// Histories

function AddHistoryItem(Id) {
    var item_to_AddHistory = Id;
    $(document).ready(function () {
        location.href = '/Owners/AddHistory/' + item_to_AddHistory;
    });
}

function AddHistoryItemValidate() {

    toastrValidated();
          
    const description = document.getElementById('Description').value;
    const date = document.getElementById('Date').value;
    const serviceTypeId = document.getElementById('ServiceTypeId').value;
    const resul = parseInt(serviceTypeId);

    if (description === '') {
        $("#Description").css('border-color', 'Red');
        toastr["error"]("El campo descripción es Obligatorio", "Alerta");
        $("#Description").focus();       
        $("#Description").keydown(function () {
            $("#Description").css("border-color", "lightgrey");
        });
        $("#Description").keyup(function () {
            $("#Description").css("border-color", "lightgrey");
        });
        return false;
    } else if (date === '') {
        $("#Date").css('border-color', 'Red');
        toastr["error"]("La fecha de nacimiento es obligatoria", "Alerta");
        $("#Date").focus();
        $("#Date").keydown(function () {
            $("#Date").css("border-color", "lightgrey");
        });
        $("#Date").keyup(function () {
            $("#Date").css("border-color", "lightgrey");
        });
        return false;
    } else if (resul === 0) {
        $("#ServiceTypeId").css('border-color', 'Red');
        toastr["error"]("El tipo de servicio es Obligatorio", "Alerta");
        return false;
    }


}

function EditHistory(Id) {
    var item_to_AddHistory = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Owners/EditHistory/' + item_to_AddHistory;
        });
    }

}

function DeleteHistory(Id) {
    var item_to_AddHistory = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Owners/DeleteHistory/' + item_to_AddHistory;
    });
}

//PetType

function deletePetTypeItem(Id) {
    var item_to_deletePetType = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        window.location.href = '/PetTypes/Delete/' + item_to_deletePetType;
    });

}

function ReturnIndexPetTypes() {
    location.href = '/PetTypes/Index/';
}

function EditPetTypeItem(Id) {
    var item_to_EditPetType = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/PetTypes/Edit/' + item_to_EditPetType;
        });
    }
}

function DetailPetTypeItem(Id) {
    var item_to_DetailPetType = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/PetTypes/Details/' + item_to_DetailPetType;
        });
    }
}

function CreatePetTypeItem() {
    $(document).ready(function () {
        location.href = '/PetTypes/Create/';
    });
}

function CreatePetTypes() {

    //var name = document.getElementById('Name').value;
    
    //var parametros = {
    //    "Email": name
    //};

    //$.ajax({
    //    url: '/PetTypes/Createt/',
    //    type: 'POST',
    //    contentType: 'application/json;',
    //    data: parametros,
    //    success: function (data) {

    //        $('#resp').html(data);  
    //    }
    //});     

}

//ServiceType

function CreateServiceTypeItem() {
    location.href = '/ServiceTypes/Create/';
}

function EditServiceTypeItem(Id) {
    var item_to_EditPetType = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/ServiceTypes/Edit/' + item_to_EditPetType;
        });
    }
}

function DetailServiceTypeItem(Id) {
    var item_to_DetailPetType = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/ServiceTypes/Details/' + item_to_DetailPetType;
        });
    }
}

function deleteServiceTypeItem(Id) {
    var item_to_deletePetType = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        window.location.href = '/ServiceTypes/Delete/' + item_to_deletePetType;
    });

}

function SaveServiceTypeItem() {

    const nombre = $("#texto").val();

    var parametros = {
        "UserName": nombre
    };


    $.ajax({
        url: '/ServiceTypes/Create/',
        type: 'POST',
        contentType: 'application/json;',
        data: parametros,
        success: function (valid) {
            if (valid) {
                //show that id is valid 
            } else {
                //show that id is not valid 
            }
        }
    });   
}

function ServiceTypesIndex() {
    $(document).ready(function () {
        location.href = '/ServiceTypes/Index/';
    });
}

//Manager

function ManagerDetailsItem(Id) {
    var item_to_DetailsItem = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Managers/Details/' + item_to_DetailsItem;
        });
    }
}

function ManagerEditItem(Id) {
    var item_to_EditItem = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Managers/Edit/' + item_to_EditItem;
        });
    }

}

function ManagerCreateItem() {
    location.href = '/Managers/Create/';    
}

function ManagerDeleteItem(Id) {
    var item_to_deleteManager = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        window.location.href = '/Managers/Delete/' + item_to_deleteManager;
    });
}

function ManagerIndex() {
    $(document).ready(function () {
        location.href = '/Managers/Index/';
    });
}

//Pet
 function EditPetsItem(Id) {
    var item_to_EditPets = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Pets/Edit/' + item_to_EditPets;
        });
    }
}

function DetailPetsItem(Id) {
    var item_to_DetailPets = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Pets/Details/' + item_to_DetailPets;
        });
    }
}

function PetsIndex() {
    $(document).ready(function () {
        location.href = '/Pets/Index/';
    });
}

function AddHistorieItem(Id) {
    const item_to_AddHistorie = Id;
    $(document).ready(function () {
        location.href = '/Pets/AddHistory/' + item_to_AddHistorie;
    });
}

function PetDetailIndex() {
    $(document).ready(function () {
        location.href = '/Pets/Index/';
    });
}

function PetEdithistories(Id) {
    const item_to_EditHistorie = Id;
    $(document).ready(function () {
        location.href = '/Pets/EditHistory/' + item_to_EditHistorie;
    });

}

function PetDeleteIndex(Id) {
  var item_to_PetHistorie = Id;
  $('#deleteItem').click((e) => {
      item_to_delete = e.currentTarget.dataset.id;
  });
  $("#btnYesDelete").click(function () {
      location.href = '/Pets/Delete/' + item_to_PetHistorie;
  });
}

function PetDeleteDetail(Id) {
    var item_to_PetDetailHistorie = Id;
    $('#deleteItem').click((e) => {
        item_to_delete = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Pets/DeleteHistory/' + item_to_PetDetailHistorie;
    });   
}

//Agenda

function AddAgendaItem(Id) {
    const item_to_AddAgenda = Id;
    $(document).ready(function () {
        location.href = '/Agenda/Assing/' + item_to_AddAgenda;
    });
}

function DeleteAgendaItem(Id) {
    var item_to_AddAgenda = Id;
    $('#deleteItem').click((e) => {
        item_to_AddAgenda = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Agenda/Unassign/' + item_to_AddAgenda;
    });
}

function AgendaAddDaysItem() {
    $(document).ready(function () {
        location.href = '/Agenda/AddDays/';
    });
}

//Home
function HomeCreateMypet() {

    toastrValidated();

    const name = document.getElementById('Name').value;  
    const pettype = document.getElementById('PetTypeId').value;  
    const petsex = document.getElementById('PetSexId').value;  
    const resultpettype = parseInt(pettype);
    const resulpetsex = parseInt(petsex);

    if (name === '') {
        $("#Name").css('border-color', 'Red');
        toastr["error"]("Ingresa un nombre de mascota", "Alerta");
        $("#Name").focus();
        $("#Name").keydown(function () {
            $("#Name").css("border-color", "lightgrey");
        });
        $("#Name").keyup(function () {
            $("#Name").css("border-color", "lightgrey");
        });
        return false;
    } else if (resultpettype === 0) {  
        $("#PetTypeId").css('border-color', 'Red');
        toastr["error"]("Selección tipo de mascota", "Alerta");     
        $("#PetTypeId").keydown(function () {
            $("#PetTypeId").css("border-color", "lightgrey");
        });
        $("#PetTypeId").keyup(function () {
            $("#PetTypeId").css("border-color", "lightgrey");
        });
        return false;  
    } else if (resulpetsex === 0) {
        $("#PetSexId").css('border-color', 'Red');
        toastr["error"]("Tipo  sexo de mascota", "Alerta");
        $("#PetSexId").focus();
        return false;
    }

    else {

        return false;
    }

}

function HomeCreateItem() { 
   $(document).ready(function () {
       location.href = '/Home/Create/';
   });    
}

function HomeEditMyPet(Id) {
    var item_to_EditMyPet = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Home/Edit/' + item_to_EditMyPet;
        });
    }
}

function HomeDetailsMyPet(Id) {
    var item_to_DetailsMyPet = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/Home/Details/' + item_to_DetailsMyPet;
        });
    }
}

function HomeMyPetsIndex() {
    $(document).ready(function () {
        location.href = '/Home/MyPets/';
    });
}

function HomeDeleteIndex(Id) {
    var item_to_DeleteMyPets = Id;
    $('#deleteItem').click((e) => {
        item_to_DeleteMyPets = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Home/Delete/' + item_to_DeleteMyPets;
    });
}

function HomeAddAgendaitem(Id) {
    const item_to_AddAgenda = Id;
    $(document).ready(function () {
        location.href = '/Home/Assing/' + item_to_AddAgenda;
    });

}

function HomeDeleteAgendaItem(Id) {
    var item_to_DeleteAgenda = Id;
    $('#deleteItem').click((e) => {
        item_to_DeleteAgenda = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        location.href = '/Home/Unassign/' + item_to_DeleteAgenda;
    });

}

// Acount

function RecoverPassword() {
    $(document).ready(function () {
        location.href = '/Account/RecoverPassword/';
    });
}

function ChangePassword() {
    $(document).ready(function () {
        location.href = '/Account/ChangePassword/';
    });
}

//Pet Race

function PetRaceCreateItem() {
    $(document).ready(function () {
        location.href = '/PetRaces/Create/';
    });
}

function PetRaceIndexItem() {
    $(document).ready(function () {
        location.href = '/PetRaces/Index/';
    });
}

function PetRaceEditItem(Id) {
    var item_to_EditPetsRace = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/PetRaces/Edit/' + item_to_EditPetsRace;
        });
    }
}


function PetRaceDetailItem(Id) {
    var item_to_EditPetsRace = Id;
    if (Id !== undefined) {
        $(document).ready(function () {
            location.href = '/PetRaces/Details/' + item_to_EditPetsRace;
        });
    }
}


function deletePetRaceItem(Id) {
    var item_to_deletePetRace = Id;
    $('#deleteItem').click((e) => {
        item_to_deletePetRace = e.currentTarget.dataset.id;
    });
    $("#btnYesDelete").click(function () {
        window.location.href = '/PetRaces/Delete/' + item_to_deletePetRace;
    });

}

function SavePetRace() {   

    toastrValidated();

    $("#PetRace").submit(function (e) {
        e.preventDefault();   

        let name = document.getElementById('Name').value;

        let parametros =
        {
            "Name": name
        };

        $.ajax({
            data: parametros,
            type: "POST",
            dataType: "json",
            url: "/PetRaces/Create/"
        })

            .done(function (result) {

                try {

                    if (result === "Success") {
                        toastr.success("Mascota creada de forma correcta", "Felicitaciones!");
                        return false;
                    }
                    else if (result === "Exist") {
                        toastr.warning("Ya existe esa raza previamente creada", "Cuidado");
                        $("#Name").focus();                        
                        return false;
                    }
                    else
                    {
                        $("#Name").css('border-color', 'Red');
                        toastr.error("Ingresa una raza de mascota", "alerta!");
                        $("#Name").focus();

                        $("#Name").keyup(function () {
                            $("#Name").css("border-color", "lightgrey");
                        });

                        $("#Name").keydown(function () {
                            $("#Name").css("border-color", "lightgrey");

                        });                        
                       
                        return false;
                    } 

                    
                }
                catch (error) {
                    console.error(error);
                }

            })
            .fail(function (textStatus) {
                if (console && console.log) {
                    console.log("La solicitud a fallado: " + textStatus);
                }
          });
    });

}