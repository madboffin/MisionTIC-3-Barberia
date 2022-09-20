// muestra el contenido del modal
$("#crearServiciosModal").click(function () {
    $("#modalRegistrarServicios").modal('show');
});

//redirige a la creacion del objeto con ajax
$("#registrarServicios").click(function () {
    //Validar datos
    var servicio = {
        "Nombre": $("#nombreServicio").val(),
        "Precio": $("#costoServicio").val()
    }
    $.ajax({
        type: "POST",
        url: "/Servicios/Servicios?handler=Create",
        contentType: "application/json; charset=utf-8",
        dataType: "html",  //la respuesta que espera recibir
        headers: {
            "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        data: JSON.stringify(servicio)
    })
        .done(function (result) {
            alert(result);
            console.log(result);
            location.reload();
        })
        .fail(function (error) {
            console.log(result);
            alert(error);
        });
});


$("#editarServicios").click(function () {
    alert("Editar");
});

$("#eliminarServicios").click(function () {
    if (confirm("Eliminar el registro") == true) {
        alert("TODO eliminar");
    } else {
        alert("Cancelado");
    };
});