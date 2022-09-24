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


// $(document).onclick(function () {
//     $("#modalEditarServicios").modal('show');
// });
$(document).on('click', '#tableServicios tbody tr td a.btn.btn-primary', function () {
    $(this).parent().parent().find('td').each(function (index) {
        switch (index) {
            case 0:
                $('#Id').val($(this).text());
                break;
            case 1:
                $('#Nombre').val($(this).text());
                break;
            case 2:
                $('#Precio').val($(this).text());
                break;
        }
    });

    $('#modalEditarServicios').modal('show');

});

// Transformando tabla en DataTable
$(document).ready(function () {
    $('#tableServicios').DataTable();
});
// Inicializando tooltips
$(function () {
  $('[data-toggle="tooltip"]').tooltip()
})

$(document).on('click', '#tableServicios tbody tr td a.btn.btn-secondary', function () {
    // $(this).parent().parent().find("td").each(function (index) {
    //     switch (index) {
    //         case 0:
    //             $("#idServicioEliminar").val($(this).text());
    //             break;

    //     }
    // );
});