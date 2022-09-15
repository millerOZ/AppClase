$(document).ready(function () {
    $("#btnActualizar").click(function() {
        procesarComando("Actualizar","POST")
        // pasar info por ajax al servidor
    })

    $("#btnRegistrar").click(function () {
        procesarComando("Insertar","POST")
        // pasar info por ajax al servidor
      

    });

    function procesarComando (comando,crud) {
        var Documento = $("#txtDocumento").val();
        var Nombre = $("#txtNombre").val();
        var PrimerApellido = $("#txtPrimerApellido").val();
        var SegundoApellido = $("#txtSegundoApellido").val();
        var Direccion = $("#txtDireccion").val();
        var Telefono = $("#txtTelefono").val();
        var FechaNacimiento = $("#txtFechaNacimiento").val();
        var Email = $("#txtEmail").val();
        var Comando = comando;

        var DatosCliente = {
            Documento: Documento,
            Nombre: Nombre,
            PrimerApellido: PrimerApellido,
            SegundoApellido: SegundoApellido,
            Direccion: Direccion,
            Telefono: Telefono,
            FechaNacimiento: FechaNacimiento,
            Email: Email,
            Comando: Comando
        }
        $.ajax({
            type: crud,
            url: "../Controladores/ControladorCliente.ashx",
            contentType: "json",
            data: JSON.stringify(DatosCliente),
            success: function (RespuestaCliente) {
                $("#dvMensaje").addClass("alert alert-success");
                $("#dvMensaje").html(RespuestaCliente);
            },
            error: function (resp) {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(resp);
            }

        });
    }
});