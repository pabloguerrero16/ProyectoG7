$(document).ready(function () {
    //FUNCIÓN PARA VALIDAR CORREO 1
    $("#Correo").keyup(function () {
        if (validarCorreo()) {
            $("#Correo").css("border", "2px solid green");
            $("#CorreoMsg").html("<p class = 'text-success'>Correo Válido</p>");
        } else {
            $("#Correo").css("border", "2px solid red");
            $("#CorreoMsg").html("<p class = 'text-danger'>Correo no válido</p>");
        }
    });

    //FUNCIÓN PARA VALIDAR CONTRASEÑA
    $("#con2").keyup(function () {
        var con1 = $("#con1").val();
        var con2 = $("#con2").val();

        if (con1 != con2) {
            $("#error").html("La contraseña no coincide");
            $("#error").css("color", "red");
            $("#enviar").prop('disabled', true);
        } else {
            $("#error").html("");
            $("#enviar").prop('disabled', false);
        }
    })

    //FUNCIÓN PARA LLENAR DROPDOWN DE CANTONES

    $("#ddlProvincia").change(function () {
        var provincia = $(this).val();

        $.ajax({
            type: "GET",
            url: "/Usuario/ConsultarCantones",
            data: { q: provincia },
            dataType: "json",
            success: function (data) {
                $("#ddlCanton").empty();
                $.each(data, function (index, item) {
                    $("#ddlCanton").append($('<option>', {
                        value: item.Value,
                        text: item.Text
                    }));
                });
                console.log(data);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });

    $('#tableData').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
        }
    });

});



//FUNCIÓN PARA AUTOCOMPLEMENTAR NOMBRE
function ConsultarNombre() {
    let identificacion = $("#Identificacion").val();
    if (identificacion.length > 0) {
        $.ajax({
            url: 'https://apis.gometa.org/cedulas/' + identificacion,
            type: "GET",
            success: function (data) {
                $("#Nombre").val(data.nombre);
            }
        });
    } else {
        $("#Nombre").val("");
    }
}


//FUNCIÓN PARA VALIDAR CORREO 2
function validarCorreo() {
    var correo = $("#Correo").val();
    var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
    if (reg.test(correo)) {
        return true;
    } else {
        return false;
    } 
}