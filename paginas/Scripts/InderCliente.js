$(document).ready(function () {
    $("#btnRegistrar").click(function () {
        procesarComando("Insertar")
    });
   
    function procesarComando (comando) {
        var Documento = $("#txtDocumento").val();
        var Nombre = $("#txtNombre").val();
        var CantHorasReserva = $("#txtCantHorasReserva").val();
        var DiaSemana = $("#txtDiaSemana").val();
        var ReservaSinDescuento = $("#txtReservaSinDescuento").val();
        var ValorDescuento = $("#txtValorDescuento").val();
        var ValorPagar = $("#txtValorPagar").val();
        var Comando = comando;

        var DatosCliente = {
            Documento: Documento,
            Nombre: Nombre,
            CantHorasReserva: CantHorasReserva,
            DiaSemana: DiaSemana,
            ReservaSinDescuento: ReservaSinDescuento,
            ValorDescuento: ValorDescuento,
            ValorPagar: ValorPagar,
            Comando: Comando
        }
        $.ajax({
            type: "POST",
            url: "../Controladores/ControladorInder.ashx",
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