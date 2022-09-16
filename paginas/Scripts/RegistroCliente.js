$(document).ready(function () {
    $("#btnActualizar").click(function() {
        procesarComando("Actualizar")
        // pasar info por ajax al servidor
    })

    $("#btnRegistrar").click(function () {
        procesarComando("Insertar")
        // pasar info por ajax al servidor
    });
    $("#btnEliminar").click(function () {
        procesarComando("Eliminar")
        // pasar info por ajax al servidor
    })
    $("#btnConsultar").click(function () {
        procesarComando("Consultar")
        // pasar info por ajax al servidor
    })
    function procesarComando (comando) {
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
            type: "POST",
            url: "../Controladores/ControladorCliente.ashx",
            contentType: "json",
            data: JSON.stringify(DatosCliente),
            success: function (RespuestaCliente) {
                if (Comando == "Consultar") {
                    var Cliente = JSON.parse(RespuestaCliente);
                    $("#txtNombre").val(Cliente.Nombre);
                    $("#txtPrimerApellido").val(Cliente.PrimerApellido);
                    $("#txtSegundoApellido").val(Cliente.SegundoApellido);
                    $("#txtDireccion").val(Cliente.Direccion);
                    $("#txtTelefono").val(Cliente.Telefono);
                    $("#txtFechaNacimiento").val(Cliente.FechaNacimiento.split('T')[0]);
                    $("#txtEmail").val(Cliente.Email);
                } else {
                    $("#dvMensaje").addClass("alert alert-success");
                    $("#dvMensaje").html(RespuestaCliente);
                }
                
            },
            error: function (resp) {
                $("#dvMensaje").addClass("alert alert-danger");
                $("#dvMensaje").html(resp);
            }

        });
    }
});