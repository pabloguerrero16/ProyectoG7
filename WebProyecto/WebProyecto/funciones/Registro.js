$(document).ready(function () {
    $("#Correo").keyup(function () {
        if (validarCorreo()) {
            $("#Correo").css("border", "2px solid green");
            $("#CorreoMsg").html("<p class = 'text-success'>Correo Válido</p>");
        } else {
            $("#Correo").css("border", "2px solid red");
            $("#CorreoMsg").html("<p class = 'text-danger'>Correo no válido</p>");
        }
    });

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
});

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

function validarCorreo() {
    var correo = $("#Correo").val();
    var reg = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/
    if (reg.test(correo)) {
        return true;
    } else {
        return false;
    } 
}