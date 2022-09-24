$().ready(function () {
    $("btnLogin").on("click", function (e) {
        // validar los datos
        var usuario = $("#usuario").val();
        var password = $("#password").val();
        if (usuario.trim() == "") {
            alert("Debe diligenciar el usuario");
            return;
        }
        if (password.trim() == "") {
            alert("Debe diligenciar el password");
            return;
        }
        // Enviar datos al servidor
        $.ajax({
            type: "POST",
            url: "",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            headers: {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            data: JSON.stringify(servicio)
        })
            .done(function (result) {
                alert(result);
                console.log(result);
            })
            .error(function (error) {
                console.log(error);
                alert(error);
            })

        // Recibir la respuesta del servidor
    })
})