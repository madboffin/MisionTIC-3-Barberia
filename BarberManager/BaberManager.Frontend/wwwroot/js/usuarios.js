
$(document).ready(function () {
    // Transformando tabla en DataTable
    $('#tableData').DataTable();
    // Inicializando tooltips
    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    });

    // ==== REGISTRAR ====
    // Muestra el contenido del modal
    $("#btnModal").click(function () {
        $("#modalRegistrar").modal('show');
    });
    //redirige a la creacion del objeto con ajax
    $("#btnRegistrar").click(function () {
        alert("test");
        //Validar datos
        // var nombre = $("#nombreServicio").val();
        // var precio = $("#costoServicio").val();
        // if (nombre.trim() == "") {
        //     alert("nombre vacio");
        //     return;
        // }
        // if (precio.trim() == "") {
        //     alert("precio vacio");
        //     return;
        // }
        // var servicio = {
        //     "Nombre": nombre,
        //     "Precio": precio
        // }
        // $.ajax({
        //     type: "POST",
        //     url: "/Servicios/Servicios?handler=Create",
        //     contentType: "application/json; charset=utf-8",
        //     dataType: "html",  //la respuesta que espera recibir
        //     headers: {
        //         "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
        //     },
        //     data: JSON.stringify(servicio)
        // })
        //     .done(function (result) {
        //         alert(result);
        //         console.log(result);
        //         location.reload();
        //     })
        //     .fail(function (error) {
        //         console.log(result);
        //         alert(error);
    });
    // });

    // // ==== EDITAR ====
    // // Anota los valores correspondientes en los contenedores asignados
    // $(document).on('click', '#tableServicios tbody tr td a.btn.btn-primary', function () {
    //     $(this).parent().parent().find('td').each(function (index) {
    //         switch (index) {
    //             case 0:
    //                 $('#idServicioEditar').val($(this).text());
    //                 break;
    //             case 1:
    //                 $('#nombreServicioEditar').val($(this).text());
    //                 break;
    //             case 2:
    //                 $('#precioServicioEditar').val($(this).text());
    //                 break;
    //         }
    //     });

    //     $('#modalEditarServicios').modal('show');
    // });
    // // Ejecuta la funcion de editar servicios al dar click al confirmar
    // $('#btnEditarServicios').click(function () {
    //     var id = $("#idServicioEditar").val();
    //     var nombre = $("#nombreServicioEditar").val();
    //     var precio = $("#precioServicioEditar").val();
    //     var servicio = {
    //         "Id": id,
    //         "Nombre": nombre,
    //         "Precio": precio
    //     };
    //     $.ajax({
    //         type: "POST",
    //         url: "/Servicios/Servicios?handler=Edit",
    //         contentType: "application/json; charset=utf-8",
    //         dataType: "html",
    //         headers: {
    //             "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
    //         },
    //         data: JSON.stringify(servicio),
    //     })
    //         .done(function (result) {
    //             console.log(result);
    //             alert(result);
    //             location.reload();
    //         })
    //         .fail(function (error) {
    //             console.log(error);
    //             alert("Código: " + error.status + ", Error: " + error.responseText);
    //         });
    // });

    // ==== ELIMINAR ====
    // Anota el Id correspondiente a la fila en el contenedor asignado
    $(document).on('click', '#tableData tbody tr td a.btn.btn-secondary', function () {
        // revisando cada fila
        $(this).parent().parent().find('td').each(function (index) {
            // la columna 1 contiene el Id
            switch (index) {
                case 0:
                    $('#idEliminar').val($(this).text());
                    break;
            }
        });

        $('#modalEliminar').modal('show');
    });
    // Ejecuta la funcion de eliminar servicios al dar click al confirmar
    $('#btnEliminarSi').click(function () {
        var id = $("#idEliminar").val();
        $.ajax({
            type: "POST",
            url: "/Usuarios/Usuarios?handler=Delete",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            headers: {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            data: JSON.stringify(id),
        })
            .done(function (result) {
                console.log(result);
                alert(result);
                location.reload();
            })
            .fail(function (error) {
                console.log(error);
                alert("Código: " + error.status + ", Error: " + error.responseText);
            });
    });
});