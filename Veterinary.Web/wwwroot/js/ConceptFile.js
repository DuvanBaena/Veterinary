

function Test() {

    //const document = $("#Documento").val();
   

    //$("#AjaxForm").submit(function (e) {
    //    e.preventDefault();
    //    alert("Hola " + Document);
    //});



    //1. capturar las variables
    var document = $("#Documento").val();    

    //2. las propiedas del modelo se le asignan cada variable que viene del formulario
    var parametros = {
        "Documento": document
       
    };

    $.ajax({
        // 3.1. data del ajax
        data: parametros,
        // 3.2. hacia donde enviamos estos parametros
        url: "/Account/Register/",
        // 3.3. el tipo de envio de los datos
        type: "Post",
        // 3.4. Que se desea hacer antes de enviar los parametros
        beforeSend: function () {
           
        },
        //  3.5 cuando responda el script destino se usa success
        success: function (result) {

            if (result === "Fail") {
                toastr["info"]("Usuario y/o Contraseña incorrectos", "Verifica los datos ");

                toastr.options = {
                    "progressBar": true
                };                   

            } else {
                location.href = "/Login/BeforeLogin/";
            }
        },
        // 3.6 cuando se presente el error
        error: function (jqXHR, textStatus, errorThrown) {
            $("#capa").html("Se presento un problema al carga la peticion: " + textStatus + " - " + errorThrown);
        }
    });


}


