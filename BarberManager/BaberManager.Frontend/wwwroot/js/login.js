$().ready(function () {
    $("#btnLogin").on("click", function () {
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
        var loginfo = new Object();
        loginfo.Usuario = usuario;
        loginfo.Password = password;
        // Enviar datos al servidor
        $.ajax({
            type: "POST",
            url: "/Login?handler=ValidateLogin",
            contentType: "application/json; charset=utf-8",
            dataType: "html",
            headers: {
                "RequestVerificationToken": $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            data: JSON.stringify(loginfo),
        })
            .done(function (result) {
                console.log(result);
                if (result != ""){
                    alert("Ingreso exitoso");
                    window.location.href = result; //redireccion
                } else {
                    alert("El usuario o el password son incorrectos");
                }
            })
            .fail(function (error) {
                console.log(error);
                alert("Código: " + error.status + ", Error: " + error.responseText);
            })
    })
})